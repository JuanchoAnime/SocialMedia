namespace SocialMedia.Core.Services
{
    using Microsoft.Extensions.Options;
    using SocialMedia.Core.Custom;
    using SocialMedia.Core.Entities;
    using SocialMedia.Core.Exceptions;
    using SocialMedia.Core.Interfaces;
    using SocialMedia.Core.Interfaces.Service;
    using SocialMedia.Core.QueryFilter;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class PublicationService : IPublicationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly PaginationOptions paginationOptions;

        public PublicationService(IUnitOfWork unitOfWork, IOptions<PaginationOptions> options)
        {
            this._unitOfWork = unitOfWork;
            this.paginationOptions = options.Value;
        }

        public IEnumerable<Publication> Get()
        {
            return _unitOfWork.PostRepository.Get();
        }

        public PageList<Publication> GetWithFilters(GetQueryFilter queryFilter)
        {
            queryFilter.PageNumber = queryFilter.PageNumber == 0 ? paginationOptions.DefaultNumber : queryFilter.PageNumber;
            queryFilter.PageSize = queryFilter.PageSize == 0 ? paginationOptions.DefaultPageSize : queryFilter.PageSize;

            var list = _unitOfWork.PostRepository.Get();
            if (queryFilter.IdUser.HasValue)
                list = list.Where(p => p.IdUser.Equals(queryFilter.IdUser.Value));
            if (!string.IsNullOrEmpty(queryFilter.Description))
                list = list.Where(p => p.Description.ToLower().Contains(queryFilter.Description.ToLower()));
            if (queryFilter.Date.HasValue)
                list = list.Where(p => p.Date.ToShortDateString().Equals(queryFilter.Date.Value.ToShortDateString()));
            return PageList<Publication>.Create(list, queryFilter.PageNumber, queryFilter.PageSize);
        }

        public async Task<Publication> GetById(int id)
        {
            return await _unitOfWork.PostRepository.GetById(id);
        }

        public async Task<Publication> Save(Publication publication)
        {
            var user = await _unitOfWork.UserRepository.GetById(publication.IdUser);
            if (user == null)
                throw new BusinessException("User doesn't exists");
            if (publication.Description.ToLower().Contains("sexo"))
                throw new BusinessException("Content not allowed");

            var userPost = await _unitOfWork.PostRepository.GetPostsByUser(publication.IdUser);
            if (userPost.Count() < 10)
            {
                var lastPost = userPost.OrderByDescending(post => post.Date).FirstOrDefault();
                if (lastPost != null && (publication.Date - lastPost.Date).TotalDays < 7)
                    throw new BusinessException("You are not available to publish");
            }
            publication.Description = publication.Description.Trim();
            var post = await _unitOfWork.PostRepository.Save(publication);
            await _unitOfWork.SaveChangesAsync();
            return post;
        }

        public async Task<bool> Update(Publication publication)
        {
            var post = await _unitOfWork.PostRepository.Update(publication);
            await _unitOfWork.SaveChangesAsync();
            return post;
        }

        public async Task<bool> Delete(int id)
        {
            var post = await _unitOfWork.PostRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return post;
        }
    }
}

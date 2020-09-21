namespace SocialMedia.Core.Services
{
    using SocialMedia.Core.Entities;
    using SocialMedia.Core.Interfaces;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class PublicationService : IPublicationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PublicationService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Publication>> Get()
        {
            var list = await _unitOfWork.PostRepository.Get();
            return list;
        }

        public async Task<Publication> GetById(int id)
        {
            var post = await _unitOfWork.PostRepository.GetById(id);
            return post;
        }

        public async Task<Publication> Save(Publication publication) 
        {
            var user = await _unitOfWork.PostRepository.GetById(publication.IdUser);
            if (user == null)
                throw new System.Exception("User doesn't exists");
            if(publication.Description.ToLower().Contains("sexo"))
                throw new System.Exception("Content not allowed");
            var post = await _unitOfWork.PostRepository.Save(publication);
            return post;
        }

        public async Task<bool> Update(Publication publication)
        {
            var post = await _unitOfWork.PostRepository.Update(publication);
            return post;
        }

        public async Task<bool> Delete(int id)
        {
            var post = await _unitOfWork.PostRepository.Delete(id);
            return post;
        }
    }
}

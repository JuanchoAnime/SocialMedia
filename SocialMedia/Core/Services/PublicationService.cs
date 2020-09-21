﻿namespace SocialMedia.Core.Services
{
    using SocialMedia.Core.Entities;
    using SocialMedia.Core.Exceptions;
    using SocialMedia.Core.Interfaces;
    using SocialMedia.Core.Interfaces.Service;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class PublicationService : IPublicationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PublicationService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public IEnumerable<Publication> Get()
        {
            return _unitOfWork.PostRepository.Get();
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
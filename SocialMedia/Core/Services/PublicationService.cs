namespace SocialMedia.Core.Services
{
    using SocialMedia.Core.Entities;
    using SocialMedia.Core.Interfaces;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class PublicationService : IPublicationService
    {
        private readonly IPublishRepository _publishRepository;
        private readonly IUserRepository _userRepository;

        public PublicationService(IPublishRepository publishRepository,
            IUserRepository userRepository)
        {
            this._publishRepository = publishRepository;
            this._userRepository = userRepository;
        }

        public async Task<IEnumerable<Publication>> Get()
        {
            var list = await _publishRepository.Get();
            return list;
        }

        public async Task<Publication> GetById(int id)
        {
            var post = await _publishRepository.GetById(id);
            return post;
        }

        public async Task<Publication> Save(Publication publication) 
        {
            var user = await _userRepository.GetById(publication.IdUser);
            if (user == null)
                throw new System.Exception("User doesn't exists");
            if(publication.Description.ToLower().Contains("sexo"))
                throw new System.Exception("Content not allowed");
            var post = await _publishRepository.Save(publication);
            return post;
        }

        public async Task<bool> Update(Publication publication)
        {
            var post = await _publishRepository.Update(publication);
            return post;
        }

        public async Task<bool> Delete(int id)
        {
            var post = await _publishRepository.Delete(id);
            return post;
        }
    }
}

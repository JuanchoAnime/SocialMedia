namespace SocialMedia.Core.Services
{
    using SocialMedia.Core.Entities;
    using SocialMedia.Core.Interfaces;
    using SocialMedia.Core.Interfaces.Service;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class SecurityService : ISecurityService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IPasswordService passwordService;

        public SecurityService(IUnitOfWork unitOfWork, IPasswordService passwordService)
        {
            this.unitOfWork = unitOfWork;
            this.passwordService = passwordService;
        }

        public Task<bool> Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Security> Get()
        {
            throw new System.NotImplementedException();
        }

        public Task<Security> GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Security> GetLoginByCredentials(UserLogin userLogin)
        {
            var security = await unitOfWork.SecurityRepository.GetLoginByCredentials(userLogin);
            if(!passwordService.Check(security.Password, userLogin.Password)) {
                return null;
            }
            return security;
        }

        public async Task<Security> Save(Security model)
        {
            model.Password = passwordService.HasPassword(model.Password);
            var security = await unitOfWork.SecurityRepository.Save(model);
            await unitOfWork.SaveChangesAsync();
            return security;
        }

        public Task<bool> Update(Security model)
        {
            throw new System.NotImplementedException();
        }
    }
}

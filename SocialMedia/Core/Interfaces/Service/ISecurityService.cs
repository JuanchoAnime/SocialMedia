namespace SocialMedia.Core.Interfaces.Service
{
    using SocialMedia.Core.Entities;
    using SocialMedia.Core.Interfaces.Generic;
    using System.Threading.Tasks;

    public interface ISecurityService : IGenericService<Security>
    {
        Task<Security> GetLoginByCredentials(UserLogin userLogin);
    }
}

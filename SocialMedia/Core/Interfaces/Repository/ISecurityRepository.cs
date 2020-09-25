namespace SocialMedia.Core.Interfaces.Repository
{
    using SocialMedia.Core.Entities;
    using SocialMedia.Core.Interfaces.Generic;
    using System.Threading.Tasks;

    public interface ISecurityRepository : IDataRepository<Security>
    {
        Task<Security> GetLoginByCredentials(UserLogin userLogin);
    }
}

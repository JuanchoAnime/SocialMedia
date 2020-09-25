namespace SocialMedia.Infrastructure.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using SocialMedia.Core.Entities;
    using SocialMedia.Core.Interfaces.Repository;
    using SocialMedia.Infrastructure.Data;
    using System.Threading.Tasks;

    public class SecurityRepository : CrudRepository<Security>, ISecurityRepository
    {
        public SecurityRepository(SocialMediaContext context) : base(context)
        {
        }

        public async Task<Security> GetLoginByCredentials(UserLogin userLogin) 
        {
            var user = await _entity.FirstOrDefaultAsync(x => x.UserSM.Equals(userLogin.User));
            return user;
        }
    }
}

﻿namespace SocialMedia.Infrastructure.Repositories
{
    using SocialMedia.Core.Entities;
    using SocialMedia.Core.Interfaces.Repository;
    using SocialMedia.Infrastructure.Data;

    public class UserRepository : CrudRepository<User>, IUserRepository
    {
        public UserRepository(SocialMediaContext context) : base(context)
        {
        }
    }
}

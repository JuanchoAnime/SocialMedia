namespace SocialMedia.Core.Entities
{
    using SocialMedia.Core.Enums;

    public class Security: BaseEntity
    {
        public string UserSM { get; set; }

        public string UserName { get; set; }

        public string Password  { get; set; }

        public RolType Rol { get; set; }
    }
}

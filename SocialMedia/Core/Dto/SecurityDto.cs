using SocialMedia.Core.Enums;

namespace SocialMedia.Core.Dto
{
    public class SecurityDto
    {
        public int Id { get; set; }

        public string UserSM { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public RolType? Rol { get; set; }
    }
}

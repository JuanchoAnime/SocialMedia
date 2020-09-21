using System;

namespace SocialMedia.Core.Entities
{
    public partial class Comentary: BaseEntity
    {
        public int IdPublication { get; set; }

        public int IdUser { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }

        public bool Active { get; set; }

        public virtual Publication IdPublicationNavigation { get; set; }

        public virtual User IdUserNavigation { get; set; }
    }
}

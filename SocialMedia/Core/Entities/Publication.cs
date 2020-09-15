using System;
using System.Collections.Generic;

namespace SocialMedia.Core.Entities
{
    public partial class Publication
    {
        public Publication()
        {
            Comentary = new HashSet<Comentary>();
        }

        public int IdPublication { get; set; }

        public int IdUser { get; set; }

        public DateTime Date { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public virtual User IdUserNavigation { get; set; }

        public virtual ICollection<Comentary> Comentary { get; set; }
    }
}

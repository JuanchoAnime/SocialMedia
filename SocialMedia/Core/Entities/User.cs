using System;
using System.Collections.Generic;

namespace SocialMedia.Core.Entities
{
    public partial class User: BaseEntity
    {
        public User()
        {
            Comentary = new HashSet<Comentary>();
            Publication = new HashSet<Publication>();
        }

        public string Names { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public DateTime DateNatal { get; set; }

        public string Cellphone { get; set; }

        public bool Active { get; set; }

        public virtual ICollection<Comentary> Comentary { get; set; }

        public virtual ICollection<Publication> Publication { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace SocialMedia.Core.Entities
{
    public partial class User
    {
        public User()
        {
            Comentary = new HashSet<Comentary>();
            Publication = new HashSet<Publication>();
        }

        public int IdUser { get; set; }

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

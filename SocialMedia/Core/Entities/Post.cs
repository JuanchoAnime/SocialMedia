namespace SocialMedia.Core.Entities
{
    using System;

    public class Post
    {
        public int IdPost { get; set; }

        public int UserId { get; set; }

        public DateTime Date { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }
    }
}

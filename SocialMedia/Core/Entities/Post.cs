namespace SocialMedia.Core.Entities
{
    public class Post: BaseEntity
    {
        public int UserId { get; set; }

        public System.DateTime Date { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }
    }
}

namespace SocialMedia.Core.Dto
{
    public class PublicationDto
    {
        public int Id { get; set; }

        public int IdUser { get; set; }

        public System.DateTime? Date { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }
    }
}

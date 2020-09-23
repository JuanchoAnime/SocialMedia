namespace SocialMedia.Core.QueryFilter
{
    public class GetQueryFilter
    {
        public int? IdUser { get; set; }

        public string Description { get; set; }

        public System.DateTime? Date { get; set; }

        public int PageSize { get; set; }

        public int PageNumber { get; set; }
    }
}

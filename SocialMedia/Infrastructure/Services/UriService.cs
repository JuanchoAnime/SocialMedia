namespace SocialMedia.Infrastructure.Services
{
    using SocialMedia.Core.QueryFilter;
    using SocialMedia.Infrastructure.Interfaces;
    using System;

    public class UriService : IUriService
    {
        private readonly string _baseUri;

        public UriService(string baseUri)
        {
            this._baseUri = baseUri;
        }

        public Uri GetPostPaginaUrl(GetQueryFilter filter, string actionurl)
        {
            string baseUri = $"{_baseUri}{actionurl}";
            return new Uri(baseUri);
        }
    }
}

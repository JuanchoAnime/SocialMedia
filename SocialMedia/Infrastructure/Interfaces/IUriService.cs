using SocialMedia.Core.QueryFilter;
using System;

namespace SocialMedia.Infrastructure.Interfaces
{
    public interface IUriService
    {
        Uri GetPostPaginaUrl(GetQueryFilter filter, string actionurl);
    }
}
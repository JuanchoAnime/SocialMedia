using SocialMedia.Core.Custom;

namespace SocialMedia.Infrastructure.Response
{
    public class ApiResponse<T>
    {
        public ApiResponse(T data)
        {
            Data = data;
        }

        public T Data { get; set; }

        public MetaData MetaData { get; set; }
    }
}

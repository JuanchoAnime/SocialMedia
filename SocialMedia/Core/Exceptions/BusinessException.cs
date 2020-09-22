namespace SocialMedia.Core.Exceptions
{
    using System;

    public class BusinessException : Exception
    {
        public BusinessException(): base("Internal Server Error")
        {
        }

        public BusinessException(string msg) : base(msg) { }
    }
}

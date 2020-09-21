namespace SocialMedia.Core.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class BusinessException: Exception
    {
        public BusinessException()
        {       
        }

        public BusinessException(string msg): base(msg)
        {

        }
    }
}

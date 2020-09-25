namespace SocialMedia.Infrastructure.Services
{
    using Microsoft.Extensions.Options;
    using SocialMedia.Core.Interfaces;
    using SocialMedia.Infrastructure.Option;
    using System;
    using System.Linq;
    using System.Security.Cryptography;

    public class PasswordService : IPasswordService
    {
        private readonly PasswordOptions options;

        public PasswordService(IOptions<PasswordOptions> passwordOptions)
        {
            this.options = passwordOptions.Value;
        }

        public bool Check(string hash, string password)
        {
            var part = hash.Split(".", 3);
            if (!part.Length.Equals(3))
                throw new FormatException("Unexpected Hash Format");

            var iteration = Convert.ToInt32(part[0]);
            var salt = Convert.FromBase64String(part[1]);
            var key = Convert.FromBase64String(part[2]);


            using (var algorithm = new Rfc2898DeriveBytes(password, salt,
                   iteration, HashAlgorithmName.SHA512))
            {
                var keyCheck = algorithm.GetBytes(options.KeySize);
                return keyCheck.SequenceEqual(key);
            }
        }

        public string HasPassword(string password)
        {
            using (var algorithm = new Rfc2898DeriveBytes(password, options.SaltSize,
                   options.Iterations, HashAlgorithmName.SHA512))
            {
                var key = Convert.ToBase64String(algorithm.GetBytes(options.KeySize));
                var salt = Convert.ToBase64String(algorithm.Salt);
                return $"{options.Iterations}.{salt}.{key}";
            }
        }
    }
}

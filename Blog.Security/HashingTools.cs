using Blog.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Security
{
    public static class HashingTools
    {
        private const int SaltMaxLength = 32;

        public static byte[] Salt { get; private set; }

        public static byte[] Hash(this string password, byte[] salt = null)
        {
            if (!string.IsNullOrEmpty(password))
            {
                if (salt == null)
                {
                    salt = GenerateSalt();
                }
                var pwd = Encoding.UTF8.GetBytes(password);

                return SHA256Hash(pwd, salt);
            }
            else
                throw new PasswordFormatException();
        }

        #region Private Methods

        private static byte[] GenerateSalt()
        {
            Salt = new byte[SaltMaxLength];

            using (var rnd = new RNGCryptoServiceProvider())
            {
                rnd.GetNonZeroBytes(Salt);
            }

            return Salt;
        }
        
        private static byte[] SHA256Hash(byte[] password, byte[] salt)
        {
            using (var algorithm = new SHA256Managed())
            {
                var saltedPwd = new byte[password.Length + salt.Length];

                for (int i = 0; i < password.Length; i++)
                    saltedPwd[i] = password[i];

                for (int i = 0; i < salt.Length; i++)
                    saltedPwd[i + password.Length] = salt[i];

                return algorithm.ComputeHash(saltedPwd);
            }
        }

        #endregion 
    }
}

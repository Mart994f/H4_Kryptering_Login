using System;
using System.Security.Cryptography;
using System.Text;

namespace BusinessLogic.Library.Services
{
    public class Sha256HashService : ISha256HashService
    {
        #region Private Fields

        private SHA256 _sha256;

        #endregion

        #region Constructors

        public Sha256HashService()
        {
            _sha256 = SHA256.Create();
        }

        #endregion

        #region Public Methods

        public string GetSalt()
        {
            byte[] saltBytes = new byte[4];

            using (RNGCryptoServiceProvider serviceProvider = new RNGCryptoServiceProvider())
            {
                serviceProvider.GetBytes(saltBytes);
            }

            return Convert.ToBase64String(saltBytes);
        }

        public string ComputeHashWithSalt(string password, string salt)
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] saltBytes = Convert.FromBase64String(salt);

            return Convert.ToBase64String(Combine(passwordBytes, saltBytes));
        }

        #endregion

        #region Private Helper Methods

        private byte[] Combine(byte[] password, byte[] salt)
        {
            byte[] combinedBytes = new byte[password.Length + salt.Length];

            Buffer.BlockCopy(salt, 0, combinedBytes, 0, salt.Length);
            Buffer.BlockCopy(password, 0, combinedBytes, salt.Length, password.Length);

            return combinedBytes;
        }

        #endregion
    }
}


using System.Security.Cryptography;

namespace TFA.Domain.Authentication
{
    internal class AesEncryptordDecryptor : IEncryptor
    {
        private readonly Lazy<Aes> aes = new(Aes.Create());
        
        public Task<string> Encrypt(string password, string salt)
        {
            throw new NotImplementedException();
        }
    }
}


using System.Security.Cryptography;
using System.Text;

namespace TFA.Domain.Authentication
{
    public class AesEncryptordDecryptor : IEncryptor
    {
        private const int IvSize = 16; 
        private readonly Lazy<Aes> aes = new(Aes.Create());
        
        public async Task<string> Encrypt(string password,byte[] key, CancellationToken cancellationToken)
        {
            var iv = RandomNumberGenerator.GetBytes(IvSize); 
            
            using var encriptodStream = new MemoryStream();

            await encriptodStream.WriteAsync(iv, cancellationToken);

            var encryptor = aes.Value.CreateEncryptor(key, iv); 

            using(var stream = new CryptoStream(encriptodStream, encryptor, CryptoStreamMode.Write))
            {
                await stream.WriteAsync(Encoding.UTF8.GetBytes(password), cancellationToken);
            }

            return Convert.ToBase64String(encriptodStream.ToArray());
        }
    }
}

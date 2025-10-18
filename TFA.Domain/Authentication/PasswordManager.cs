using System.Security.Cryptography;
using System.Text;

namespace TFA.Domain.Authentication
{
    public class PasswordManager : IPasswordManager
    {
        private const int saltLength = 100;
        private Lazy<SHA256> sha256 = new(SHA256.Create);

        public bool ComparePassword(byte[] salt, string plainText, byte[] passwordHash)
        {
            return ComputeHash(salt, plainText).SequenceEqual(passwordHash); 
        }

        public (byte[] salt, byte[] hash) GeneratePasswordHash(string password)
        {
            var salt = RandomNumberGenerator.GetBytes(saltLength);

            var hash = ComputeHash(salt, password);

            return (salt, hash.ToArray()); 
        }

        private ReadOnlySpan<byte> ComputeHash(byte[] salt, string password)
        {
            var passwordBytes = Encoding.UTF8.GetBytes(password);

            var buffer = new byte[passwordBytes.Length+salt.Length];

            Array.Copy(passwordBytes, buffer, passwordBytes.Length);

            Array.Copy(salt, 0, buffer, passwordBytes.Length, salt.Length);

            lock (sha256)
            {
                return sha256.Value.ComputeHash(buffer);
            }

        }
    }
}

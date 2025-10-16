using System.Security.Cryptography;
using System.Text;

namespace TFA.Domain.Authentication
{
    public class PasswordManager : IPasswordManager
    {
        private int saltLength = 60;
        private Lazy<SHA256> sha256;

        public bool ComparePassword(byte[] salt, string password, byte[] passwordHash)
        {
            return ComputeHash(salt, password).SequenceEqual(passwordHash); 
        }

        public (byte[] salt, byte[] hash) GeneratePassword(string password)
        {
            var salt = RandomNumberGenerator.GetBytes(saltLength);
            var hash = ComputeHash(salt, password);
            return (salt, hash.ToArray()); 
        }

        private ReadOnlySpan<byte> ComputeHash(byte[] salt, string password)
        {
            var passwordBytes = Encoding.UTF8.GetBytes(password);

            var buffer = new byte[passwordBytes.Length+salt.Length];

            Array.Copy(passwordBytes, buffer, password.Length);
            Array.Copy(salt, 0, buffer, passwordBytes.Length, salt.Length);

            lock (sha256)
            {
                return sha256.Value.ComputeHash(buffer);
            }

        }
    }
}

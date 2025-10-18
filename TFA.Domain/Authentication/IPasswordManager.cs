namespace TFA.Domain.Authentication
{
    public interface IPasswordManager
    {
        (byte[] salt, byte[] hash) GeneratePasswordHash(string password);

        bool ComparePassword(byte[] salt, string plainText, byte[] passwordHash); 
    }
}

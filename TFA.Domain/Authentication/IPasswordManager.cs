namespace TFA.Domain.Authentication
{
    public interface IPasswordManager
    {
        (byte[] salt, byte[] hash) GeneratePassword(string password);

        bool ComparePassword(byte[] salt, string password, byte[] passwordHash); 
    }
}

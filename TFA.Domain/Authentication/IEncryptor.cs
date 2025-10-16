namespace TFA.Domain.Authentication
{
    public interface IEncryptor
    {
        Task<string> Encrypt(string password, string salt); 
    }
}

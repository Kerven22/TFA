namespace TFA.Domain.Authentication
{
    public interface IEncryptor
    {
        Task<string> Encrypt(string password, byte[] key, CancellationToken cancellationToken); 
    }
}

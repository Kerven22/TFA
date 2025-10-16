namespace TFA.Domain.UseCases.SignOn
{
    public interface ISignOnStorage
    {
        Task SignOn(string firstName, string secondName, string login, string email, byte[] passwordHash, byte[] salt,  string phoneNumber, int age, CancellationToken cancellationToken);
        Task<bool> UserExists(string login, CancellationToken cancellationToken); 
    }
}

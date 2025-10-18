namespace TFA.Domain.UseCases.SignIn
{
    public interface ISignInStorage
    {
        Task<RecognizedUser?> FindUser(string login, CancellationToken cancellationToken); 
    }
}

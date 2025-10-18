namespace TFA.Domain.UseCases.SignIn
{
    public interface ISignInUseCase
    {
        Task<(Authorization.IIdentity identity, string token)> Execute(string login, string password, CancellationToken cancellationToken);
    }
}

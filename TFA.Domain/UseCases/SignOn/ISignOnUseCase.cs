namespace TFA.Domain.UseCases.SignOn
{
    public interface ISignOnUseCase
    {
        public Task Execute(UserSignOnCommand command, CancellationToken cancellationToken);
    }
}

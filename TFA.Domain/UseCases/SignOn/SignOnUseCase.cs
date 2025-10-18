using TFA.Domain.Authentication;

namespace TFA.Domain.UseCases.SignOn
{
    public class SignOnUseCase : ISignOnUseCase
    {
        private readonly ISignOnStorage _storage;
        private readonly IPasswordManager _passwordManager;

        public SignOnUseCase(ISignOnStorage signOnStorage,IPasswordManager passwordManager)
        {
            _storage = signOnStorage;
            _passwordManager = passwordManager;
        }

        public async Task Execute(UserSignOnCommand command, CancellationToken cancellationToken)
        {
            var userAlreadySignOn = await _storage.UserExists(command.Login, cancellationToken);
            
            if (userAlreadySignOn)
            {
                throw new UserExistsExveption(command.Login);
            }

            var (salt, hash) = _passwordManager.GeneratePasswordHash(command.Password); 

            await _storage.SignOn(command.FirstName, command.SecondName, command.Login, command.Email, hash, 
                salt, command.PhoneNumber, command.Age, cancellationToken); 
        }
    }
}

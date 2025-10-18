using Microsoft.Extensions.Options;
using TFA.Domain.Authentication;
using TFA.Domain.Authorization;
using TFA.Domain.Exceptions;

namespace TFA.Domain.UseCases.SignIn
{
    public class SignInUseCase : ISignInUseCase
    {
        private readonly ISignInStorage _storage;
        private readonly IPasswordManager _passwordManager;
        private readonly IEncryptor _encryptor;
        private readonly AuthenticationConfiguration _configuration;

        public SignInUseCase(
            ISignInStorage storage,
            IPasswordManager passwordManager,
            IEncryptor encryptor,
            IOptions<AuthenticationConfiguration> configuration)
        {
            _storage = storage;
            _passwordManager = passwordManager;
            _encryptor = encryptor;
            _configuration = configuration.Value;
        }


        public async Task<(IIdentity identity, string token)> Execute(string login,
            string password, CancellationToken cancellationToken)
        {
            var user = await _storage.FindUser(login, cancellationToken);

            if (user == null)
            {
                throw new WronLoginOrPasswordException();
            }

            var passworMatches = _passwordManager.ComparePassword(user.Salt, password, user.PasswordHash);
            if (!passworMatches)
            {
                throw new WronLoginOrPasswordException();
            }

            var token = await _encryptor.Encrypt(user.UserId.ToString(), _configuration.Key, cancellationToken);

            return (new User(user.UserId), token);
        }
    }
}

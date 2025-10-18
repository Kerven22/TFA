using TFA.Domain.Authorization;

namespace TFA.Domain.Authentication
{
    public interface IAuthenticationService
    {
        Task<IIdentity> Authenticate(string token, CancellationToken cancellationToken); 
    }
}

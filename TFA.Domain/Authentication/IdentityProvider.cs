using TFA.Domain.Authorization;

namespace TFA.Domain.Authentication
{
    public class IdentityProvider : IIdentityProvider
    {
        public IIdentity Current {get; set;}
    }
}

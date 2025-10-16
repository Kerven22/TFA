using TFA.Domain.Authorization;

namespace TFA.Domain.Authentication
{
    public class IdentityProvider : IIdentityProvider
    {
        public IIdentity Current => new User(Guid.Parse("7aaff6cf-8ddf-4192-b6e6-bbe1c86b7ed4")); 
    }
}

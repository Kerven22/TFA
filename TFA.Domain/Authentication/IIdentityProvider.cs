namespace TFA.Domain.Authorization
{
    public interface IIdentityProvider
    {
        IIdentity Current { get;  }
    }
}

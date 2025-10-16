namespace TFA.Domain.Authorization
{
    public interface IIntentionResolver
    {
    }

    public interface IIntentionResolver<in TIntention> : IIntentionResolver
    {
        bool IsAllowed(IIdentity identity, TIntention intention);
    }

}

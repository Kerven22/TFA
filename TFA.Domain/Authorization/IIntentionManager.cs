using System.Runtime.CompilerServices;

namespace TFA.Domain.Authorization
{
    public interface IIntentionManager
    {
        bool IsAllowed<TIntention>(TIntention intention) where TIntention : struct;

        bool IsAllowed<TIntention, TObject>(TIntention intention, TObject target) where TIntention : struct;
    }

    public class IntentionManager : IIntentionManager
    {
        private readonly IEnumerable<IIntentionResolver> _intentionResolvers;
        private readonly IIdentityProvider _identityProvider;

        public IntentionManager(IEnumerable<IIntentionResolver> intentionResolvers, IIdentityProvider identityProvider)
        {
            _intentionResolvers = intentionResolvers;
            _identityProvider = identityProvider;
        }

        public bool IsAllowed<TIntention>(TIntention intention) where TIntention : struct
        {
            var matchinResolver = _intentionResolvers.OfType<IIntentionResolver<TIntention>>().FirstOrDefault();
            return matchinResolver?.IsAllowed(_identityProvider.Current, intention) ?? false;
        }

        public bool IsAllowed<TIntention, TObject>(TIntention intention, TObject target) where TIntention : struct
        {
            throw new NotImplementedException();
        }
    }

    public static class IntentionManagerExtentions
    {
        public static void ThrowIfForbidden<TIntention>(this IIntentionManager interntionManager,TIntention intention)
            where TIntention: struct
        {
            if(!interntionManager.IsAllowed(intention))
            {
                throw new IntentionManagerException(); 
            }

        }
    }
}

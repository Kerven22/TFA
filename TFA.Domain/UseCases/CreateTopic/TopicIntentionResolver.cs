using TFA.Domain.Authorization;

namespace TFA.Domain.UseCases.CreateTopic
{
    public class TopicIntentionResolver : IIntentionResolver<TopicIntention>
    {
        public bool IsAllowed(IIdentity identity, TopicIntention intention)
        {
            return intention switch
            {
                TopicIntention.Create => identity.IsAuthenticate(),
                _ => false,
            };
        }
    }
}

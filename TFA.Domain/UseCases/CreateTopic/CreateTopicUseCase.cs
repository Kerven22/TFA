using TFA.Domain.Authorization;
using TFA.Domain.Exceptions;
using TFA.Domain.Models;

namespace TFA.Domain.UseCases.CreateTopic
{
    public class CreateTopicUseCase : ICreateTopicUseCase
    {
        private readonly ICreateTopicStorage _createTopicStorage;
        private readonly IIdentityProvider _identityProvider;
        private readonly IIntentionManager _intentionManager;

        public CreateTopicUseCase(
            ICreateTopicStorage createTopicStorage, 
            IIntentionManager intentionManager,
            IIdentityProvider identityProvider)
        {
            _createTopicStorage = createTopicStorage;
            _identityProvider = identityProvider;  
            _intentionManager = intentionManager;
        }


        public async Task<TopicDto> Execute(Guid forumId, string title,CancellationToken cancellationToken)
        {
            _intentionManager.ThrowIfForbidden(TopicIntention.Create); 

            var forumExists = await _createTopicStorage.ForumExists(forumId, cancellationToken);

            if (!forumExists)
                throw new ForumNotFoundException(forumId);

            return await _createTopicStorage.CreateTopic(forumId, _identityProvider.Current.UserId, title, cancellationToken);
        }
    }
}

using TFA.Domain.Exceptions;
using TFA.Domain.Models;

namespace TFA.Domain.UseCases.CreateTopic
{
    public class CreateTopicUseCase : ICreateTopicUseCase
    {
        private readonly ICreateTopicStorage _createTopicStorage;

        public CreateTopicUseCase(ICreateTopicStorage createTopicStorage)
        {
            _createTopicStorage = createTopicStorage;
        }


        public async Task<TopicDto> Execute(Guid forumId, string title, Guid authorId, CancellationToken cancellationToken)
        {
            var forumExists = await _createTopicStorage.ForumExists(forumId, cancellationToken);
            if (!forumExists)
                throw new ForumNotFoundException(forumId);

            return await _createTopicStorage.CreateTopic(forumId, authorId, title, cancellationToken);
        }
    }
}

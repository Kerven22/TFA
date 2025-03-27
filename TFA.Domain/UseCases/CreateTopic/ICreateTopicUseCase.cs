using TFA.Domain.Models;

namespace TFA.Domain.UseCases.CreateTopic
{
    public interface ICreateTopicUseCase
    {
        Task<TopicDto> Execute(Guid forumId, string title, Guid authorId,  CancellationToken cancellationToken);  
    }
}

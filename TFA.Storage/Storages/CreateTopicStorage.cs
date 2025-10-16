using Microsoft.EntityFrameworkCore;
using TFA.Domain.Models;
using TFA.Domain.UseCases.CreateTopic;
using TFA.Storage.DatabaseContext;

namespace TFA.Storage.Storages
{
    public class CreateTopicStorage : ICreateTopicStorage
    {
        private readonly ForumDbContext forumDbContext;

        public CreateTopicStorage(ForumDbContext forumDbContext)
        {
            this.forumDbContext = forumDbContext;
        }



        public Task<TopicDto> CreateTopic(Guid forumId, Guid userId, string title, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ForumExists(Guid forumId, CancellationToken cancellationToken) =>
            forumDbContext.Forums.AnyAsync(f=>f.ForumId==forumId, cancellationToken); 
    }
}

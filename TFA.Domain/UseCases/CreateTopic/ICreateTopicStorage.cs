﻿using TFA.Domain.Models;
using TFA.Storage.Models;

namespace TFA.Domain.UseCases.CreateTopic
{
    public interface ICreateTopicStorage
    {
        Task<bool> ForumExists(Guid forumId, CancellationToken cancellationToken);
        Task<TopicDto> CreateTopic(Guid forumId, Guid userId, string title, CancellationToken cancellationToken);
    }
}

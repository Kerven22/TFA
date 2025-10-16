using FluentAssertions;
using Moq;
using Moq.Language.Flow;
using TFA.Domain.Authorization;
using TFA.Domain.Exceptions;
using TFA.Domain.Models;
using TFA.Domain.UseCases.CreateTopic;

namespace TFA.Domain.Tests
{
    public class CreateTopicUseCaseShould
    {
        private readonly Mock<ICreateTopicStorage> storage;
        private readonly ISetup<ICreateTopicStorage, Task<bool>> forumExistsSetup;
        private readonly ISetup<ICreateTopicStorage, Task<TopicDto>> forumCreateTopic;
        private readonly ISetup<IIdentity, Guid> getCurrentUserIdSetup;
        private readonly Mock<IIntentionManager> intentionManager;
        private readonly ISetup<IIntentionManager, bool> intentionIsAllowedSetup;
        private readonly CreateTopicUseCase sut;

        public CreateTopicUseCaseShould()
        {
            storage = new Mock<ICreateTopicStorage>();
            forumExistsSetup = storage.Setup(f => f.ForumExists(It.IsAny<Guid>(), It.IsAny<CancellationToken>()));
            forumCreateTopic = storage.Setup(f => f.CreateTopic(It.IsAny<Guid>(), It.IsAny<Guid>(), It.IsAny<string>(), It.IsAny<CancellationToken>()));
            var identity = new Mock<IIdentity>();
            var identityProvider = new Mock<IIdentityProvider>();
            var identityProviderSetup = identityProvider.Setup(s => s.Current).Returns(identity.Object);
            getCurrentUserIdSetup = identity.Setup(s => s.UserId);

            intentionManager = new Mock<IIntentionManager>();
            intentionIsAllowedSetup = intentionManager.Setup(s => s.IsAllowed(It.IsAny<TopicIntention>()));

            sut = new CreateTopicUseCase(storage.Object, intentionManager.Object, identityProvider.Object);
        }

        [Fact]
        public async Task ThrowIntnentionManagerException_WhenUserIsAnenimous()
        {
            var forumId = Guid.Parse("eb456221-296d-442e-b947-f182f2935cf9");
            intentionIsAllowedSetup.Returns(false);

            forumExistsSetup.ReturnsAsync(true);

            await sut.Invoking(s => s.Execute(forumId, "someTitle", CancellationToken.None))
                .Should().ThrowAsync<IntentionManagerException>();
            intentionManager.Verify(s => s.IsAllowed(TopicIntention.Create));
        }

        [Fact]
        public async Task ThrowNotFoundException_WhenNoForum()
        {
            intentionIsAllowedSetup.Returns(true);
            forumExistsSetup.ReturnsAsync(false);

            var forumId = Guid.Parse("eb456221-296d-442e-b947-f182f2935cf9");

            await sut.Invoking(s => s.Execute(forumId, "someTitle", CancellationToken.None))
                .Should().ThrowAsync<ForumNotFoundException>();
        }

        [Fact]
        public async Task ReturnNewlyCreatedTopic_WhenMatchingForumExists()
        {
            var forumId = Guid.Parse("82064200-00cc-4464-8675-9d7bb9395184");
            var userId = Guid.Parse("005d81d9-b8c6-4735-9079-20d628c0b7aa");

            intentionIsAllowedSetup.Returns(true);

            getCurrentUserIdSetup.Returns(userId);

            forumExistsSetup.ReturnsAsync(true);

            var expected = new TopicDto();

            forumCreateTopic.ReturnsAsync(expected);

            var actual = await sut.Execute(forumId, "Hello World", CancellationToken.None);

            actual.Should().Be(expected);

            storage.Verify(s => s.CreateTopic(forumId, userId, "Hello World", CancellationToken.None), Times.Once);

        }
    }
}
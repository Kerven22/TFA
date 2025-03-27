using FluentAssertions;
using Moq;
using Moq.Language.Flow;
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
        private readonly CreateTopicUseCase sut;

        public CreateTopicUseCaseShould()
        {
            storage = new Mock<ICreateTopicStorage>();
            forumExistsSetup = storage.Setup(f => f.ForumExists(It.IsAny<Guid>(), It.IsAny<CancellationToken>()));
            forumCreateTopic = storage.Setup(f => f.CreateTopic(It.IsAny<Guid>(), It.IsAny<Guid>(), It.IsAny<string>(), It.IsAny<CancellationToken>()));
            sut = new CreateTopicUseCase(storage.Object);
        }


        [Fact]
        public async Task ThrowNotFoundException_WhenNoForum()
        {
            forumExistsSetup.ReturnsAsync(false);

            var forumId = Guid.Parse("eb456221-296d-442e-b947-f182f2935cf9");
            var authorId = Guid.Parse("00a42a18-0e76-488c-be7e-40c3b18effa7");


            await sut.Invoking(s => s.Execute(forumId, "someTitle", authorId, CancellationToken.None))
                .Should().ThrowAsync<ForumNotFoundException>();
        }

        [Fact]
        public async Task ReturnNewlyCreatedTopic_WhenMatchingForumExists()
        {
            forumExistsSetup.ReturnsAsync(true);

            var expected = new TopicDto();

            forumCreateTopic.ReturnsAsync(expected);

            var forumId = Guid.Parse("82064200-00cc-4464-8675-9d7bb9395184");
            var userId = Guid.Parse("005d81d9-b8c6-4735-9079-20d628c0b7aa");

            var actual = await sut.Execute(forumId, "Hello World", userId, CancellationToken.None);

            actual.Should().Be(expected);

            storage.Verify(s => s.CreateTopic(forumId, userId, "Hello World", CancellationToken.None), Times.Once);

        }
    }
}
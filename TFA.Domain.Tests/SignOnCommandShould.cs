using FluentAssertions;
using Moq;
using Moq.Language.Flow;
using TFA.Domain.Authentication;
using TFA.Domain.UseCases.SignOn;

namespace TFA.Domain.Tests
{
    public class SignOnCommandShould
    {
        private readonly ISetup<ISignOnStorage, Task<bool>> userExistsSetup;
        private readonly ISetup<ISignOnStorage, Task> signOnSetup;
        private readonly SignOnUseCase sut;
        private readonly Mock<ISignOnStorage> signOnStorage;

        public SignOnCommandShould()
        {
            signOnStorage = new Mock<ISignOnStorage>();
            var passwordManager = new Mock<IPasswordManager>();
            userExistsSetup = signOnStorage.Setup(s => s.UserExists(It.IsAny<string>(), It.IsAny<CancellationToken>()));
            signOnSetup = signOnStorage.Setup(s => s.SignOn(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(),
                It.IsAny<string>(), It.IsAny<byte[]>(), It.IsAny<byte[]>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<CancellationToken>()));

            sut = new SignOnUseCase(signOnStorage.Object, passwordManager.Object);
        }

        [Fact]
        public void ThrowUserExistsException_WhenUserAlredyRegister()
        {
            userExistsSetup.ReturnsAsync(true);
            var login = "alex";
            var command = new UserSignOnCommand() { Login = login };
            sut.Invoking(s => s.Execute(command, CancellationToken.None)).Should().ThrowAsync<UserExistsExveption>();
            signOnStorage.Verify(s => s.UserExists(login, CancellationToken.None));
        }
    }
}

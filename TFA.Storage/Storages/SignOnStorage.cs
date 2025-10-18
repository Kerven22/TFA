using Microsoft.EntityFrameworkCore;
using TFA.Domain.UseCases.SignOn;
using TFA.Storage.DatabaseContext;
using TFA.Storage.Factories;
using TFA.Storage.Models;

namespace TFA.Storage.Storages
{
    public class SignOnStorage : ISignOnStorage
    {
        private readonly ForumDbContext _forumDbContext;
        private readonly IGuidFactory _guidFactory;
        public SignOnStorage(
            ForumDbContext forumDbContext,
            IGuidFactory guidFactory)
        {
            _forumDbContext = forumDbContext;
            _guidFactory = guidFactory;
        }
        public async Task SignOn(string firstName, string secondName, string login, string email, byte[] passwordHash, byte[] salt, string phoneNumber, int age, CancellationToken cancellationToken)
        {
            var userId = _guidFactory.Create();

            var user = new User()
            {
                UserId = userId,
                FirstName = firstName,
                SecondName = secondName,
                Login = login,
                Email = email,
                Password = passwordHash,
                PasswordSalt = salt,
                PhoneNumber = phoneNumber,
                Age = age
            };
            await _forumDbContext.Users.AddAsync(user, cancellationToken);
            await _forumDbContext.SaveChangesAsync(cancellationToken);
        }

        public Task<bool> UserExists(string login, CancellationToken cancellationToken) =>
            _forumDbContext.Users.AnyAsync(u => u.Login == login, cancellationToken);
    }
}

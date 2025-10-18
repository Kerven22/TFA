using Microsoft.EntityFrameworkCore;
using TFA.Domain.UseCases.SignIn;
using TFA.Storage.DatabaseContext;

namespace TFA.Storage.Storages
{
    public class SignInStorage : ISignInStorage
    {
        private readonly ForumDbContext _context;
        public SignInStorage(
            ForumDbContext forumDbContext)
        {
            _context = forumDbContext;
        }
        public async Task<RecognizedUser?> FindUser(string login, CancellationToken cancellationToken)=>
            await _context.Users
                .Where(r => r.Login == login)
                .Select(r=>new RecognizedUser { UserId = r.UserId, PasswordHash = r.Password, Salt = r.PasswordSalt})
                .FirstOrDefaultAsync(cancellationToken); 
    }
}

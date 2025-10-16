using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TFA.Domain.UseCases.SignOn;
using TFA.Storage.DatabaseContext;
using TFA.Storage.Factories;

namespace TFA.Storage.Storages
{
    public class SignOnStorage : ISignOnStorage
    {
        private readonly ForumDbContext _forumDbContext;
        private readonly IMapper _mapper;
        private readonly IGuidFactory _guidFactory; 
        public SignOnStorage(
            ForumDbContext forumDbContext, 
            IMapper mapper, 
            IGuidFactory guidFactory)
        {
            _forumDbContext = forumDbContext;
            _mapper = mapper;
            _guidFactory = guidFactory;
        }
        public Task SignOn(string firstName, string secondName, string login, string email, byte[] passwordHash, byte[] salt, string phoneNumber, int age, CancellationToken cancellationToken)
        {
            throw new NotImplementedException(); 
        }

        public Task<bool> UserExists(string login, CancellationToken cancellationToken)=>
            _forumDbContext.Users.AnyAsync(u=>u.Login == login,cancellationToken);
    }
}

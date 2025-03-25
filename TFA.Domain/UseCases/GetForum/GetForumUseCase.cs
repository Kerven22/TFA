using TFA.Domain.Models;
using TFA.Storage.DatabaseContext;

namespace TFA.Domain.UseCases.GetForum
{
    public class GetForumUseCase : IGetForumUseCase
    {
        private readonly ForumDbContext _dbContext;
        public GetForumUseCase(ForumDbContext dbContext)
        {
            _dbContext = dbContext; 
        }
        public async Task<IEnumerable<ForumDto>> Execute(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

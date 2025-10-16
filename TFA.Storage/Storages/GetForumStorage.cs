using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using TFA.Domain.Models;
using TFA.Domain.UseCases.GetForum;
using TFA.Storage.DatabaseContext;

namespace TFA.Storage.Storages
{
    public class GetForumStorage : IGetForumStorage
    {
        private readonly ForumDbContext forumDbContext;
        private readonly IMapper mapper;

        public GetForumStorage(
            ForumDbContext forumDbContext,
            IMapper mapper)
        {
            this.forumDbContext = forumDbContext;
            this.mapper = mapper;
        }
        public Task<ForumDto> GetForum(Guid IdForum, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ForumDto>> GetForums(CancellationToken cancellationToken)
        {
            return await forumDbContext.Forums
                .ProjectTo<ForumDto>(mapper.ConfigurationProvider)
                .ToArrayAsync(cancellationToken); 
        }
    }
}

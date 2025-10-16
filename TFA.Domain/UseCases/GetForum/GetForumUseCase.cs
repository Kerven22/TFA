using TFA.Domain.Models;

namespace TFA.Domain.UseCases.GetForum
{
    public class GetForumUseCase : IGetForumUseCase
    {
        private readonly IGetForumStorage _getForumStorage;

        public GetForumUseCase(IGetForumStorage getForumStorage)
        {
            _getForumStorage = getForumStorage;
        }


        public async Task<IEnumerable<ForumDto>> Execute(CancellationToken cancellationToken)
        {
            return await _getForumStorage.GetForums(cancellationToken);
        }

        public async Task<ForumDto> Execute(Guid forumId, CancellationToken cancellationToken)
        {
            return await _getForumStorage.GetForum(forumId, cancellationToken);
        }
    }
}

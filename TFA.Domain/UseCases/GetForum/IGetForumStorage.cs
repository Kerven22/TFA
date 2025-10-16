using TFA.Domain.Models;

namespace TFA.Domain.UseCases.GetForum
{
    public interface IGetForumStorage
    {
        Task<ForumDto> GetForum(Guid IdForum, CancellationToken cancellationToken); 
        Task<IEnumerable<ForumDto>> GetForums(CancellationToken cancellationToken);
    }
}

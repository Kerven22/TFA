using Microsoft.AspNetCore.Mvc;
using TFA.Domain.UseCases.GetForum;
using TFA.Models.Responsies;

namespace TFA.Controllers
{
    [ApiController]
    [Route("/api")]
    public class ForumController : ControllerBase
    {

        [HttpGet("forums")]
        [ProducesResponseType(200, Type = typeof(ForumResponse[]))]
        public async Task<IActionResult> GetForums([FromServices] IGetForumUseCase getForumUsecase, CancellationToken cancellationToken)
        {
            var forum = await getForumUsecase.Execute(cancellationToken);

            var forumResponse = forum.Select(s => new ForumResponse
            {
                Id = s.Id,
                Title = s.Title
            });
            
            return Ok(forumResponse); 
        }
    }
}

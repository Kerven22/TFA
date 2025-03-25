using Microsoft.AspNetCore.Mvc;

namespace TFA.Controllers
{
    [ApiController]
    [Route("/api")]
    public class ForumController:ControllerBase
    {
        [HttpGet("forums")]
        public IActionResult GetForums(CancellationToken cancellationToken)
        {
            return Ok(); 
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using TFA.Models.Requests;

namespace TFA.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController:ControllerBase
    {
        [HttpPost("signon")]
        public async Task<IActionResult> SignOn(
            [FromBody]UserSignOn userSignOn)
        {

            return Ok(); 
        }
    }
}

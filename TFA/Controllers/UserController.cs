using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TFA.Authentication;
using TFA.Domain.UseCases.SignIn;
using TFA.Domain.UseCases.SignOn;
using TFA.Models.Requests;

namespace TFA.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController:ControllerBase
    {
        [HttpPost("signon")]
        public async Task<IActionResult> SignOn(
            [FromBody]UserSignOn userSignOn,
            [FromServices] ISignOnUseCase signOnUseCase, 
            IMapper mapper,
            CancellationToken cancellationToken)
        {

            await signOnUseCase.Execute(mapper.Map<UserSignOnCommand>(userSignOn), cancellationToken); 
            return Ok(); 
        }

        [HttpPost("signin")]
        public async Task<IActionResult> SignIn(
            [FromBody] UserSignIn _userSignIn,
            [FromServices] ISignInUseCase _signInUseCase,
            IAuthStorage authStorage,
            CancellationToken cancellationToken)
        {

            var (identity, token) = await _signInUseCase
                .Execute(_userSignIn.Login, _userSignIn.Password, cancellationToken);
            authStorage.Store(HttpContext, token);
            return Ok(identity);
        }
    }
}
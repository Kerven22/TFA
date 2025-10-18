using TFA.Authentication;
using TFA.Domain.Authentication;
using TFA.Domain.Authorization;

namespace TFA.Middleware
{
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;       

        public AuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(
            HttpContext context,
            IIdentityProvider identityProvider,
            IAuthStorage _storage,
            IAuthenticationService _authenticationService)
        {
            var identity = _storage.TryExtract(context, out var authToken) 
                ? await _authenticationService.Authenticate(authToken, context.RequestAborted)
                : User.Guest;
            identityProvider.Current = identity;

            await _next.Invoke(context);
        }
    }
}

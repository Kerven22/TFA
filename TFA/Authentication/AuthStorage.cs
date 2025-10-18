
namespace TFA.Authentication
{
    internal class AuthStorage : IAuthStorage
    {
        private const string HeaderKey = "AuthToken";

        public void Store(HttpContext httpContext, string token)=>
            httpContext.Response.Cookies.Append(HeaderKey, token);

        bool IAuthStorage.TryExtract(HttpContext httpContext, out string token)
        {
            throw new NotImplementedException();
        }
    }
}

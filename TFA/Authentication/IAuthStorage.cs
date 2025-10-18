namespace TFA.Authentication
{
    public interface IAuthStorage
    {
        bool TryExtract(HttpContext httpContext, out string token); 
        public void Store(HttpContext httpContext, string token);
    }
}

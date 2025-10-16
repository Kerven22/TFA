namespace TFA.Domain.UseCases.SignOn
{
    public class UserExistsExveption : Exception
    {
        public UserExistsExveption(string login):base($"User with login {login} already exists ")
        {
            
        }
    }
}

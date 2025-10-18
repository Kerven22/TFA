namespace TFA.Domain.Exceptions
{
    public class WronLoginOrPasswordException : Exception
    {
        public WronLoginOrPasswordException() : base($"Wron login or password!")
        {
            
        }
    }
}

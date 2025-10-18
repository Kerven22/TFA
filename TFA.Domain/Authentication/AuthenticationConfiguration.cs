namespace TFA.Domain.Authentication
{
    public class AuthenticationConfiguration
    {
        public required string Base64String { get; set; }

        public byte[] Key => Convert.FromBase64String(Base64String);

    }
}

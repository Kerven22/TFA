namespace TFA.Domain.UseCases.SignOn
{
    public record UserSignOnCommand
    {
        public string FirstName { get; init; }
        public string SecondName { get; init; }
        public string Login { get; init; }
        public string Email { get; init; }
        public string Password { get; init; }
        public string PhoneNumber { get; init; }
        public int Age { get; init; }
    }


}

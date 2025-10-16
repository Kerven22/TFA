namespace TFA.Domain.UseCases.SignOn
{
    public record UserSignOnCommand(
        string FirstName, 
        string SecondaName, 
        string Login, 
        string Email, 
        string Password,
        string PhoneNumber,
        int Age); 
}

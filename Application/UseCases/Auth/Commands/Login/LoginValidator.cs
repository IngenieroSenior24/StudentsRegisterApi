namespace Application.UseCases.Auth.Commands.Login;

public class LoginValidator : AbstractValidator<LoginCommand>
{
    public LoginValidator()
    {
        RuleFor(_ => _.Identification).NotNull().NotEmpty().MinimumLength(9).MaximumLength(10);
    }
}
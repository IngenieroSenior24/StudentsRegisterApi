namespace Application.UseCases.Auth.Commands.Login;

public record LoginCommand(string Identification): IRequest<LoginDto>;


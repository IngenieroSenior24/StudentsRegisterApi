using Application.UseCases.Auth.Commands.Login;
using MediatR;

namespace Api.Controllers;

[ApiController]
[Route(ApiRoutes.Auth)]
public class AuthController : ControllerBase 
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator) => _mediator = mediator;
    
    
    [HttpPost]
    public async Task<LoginDto> Login(LoginCommand command)
    {
        return await _mediator.Send(command);
    }
}

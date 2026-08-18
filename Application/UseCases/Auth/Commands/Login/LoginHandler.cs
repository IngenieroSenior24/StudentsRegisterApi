using Domain.Entities;
using Domain.Services;

namespace Application.UseCases.Auth.Commands.Login;

public class LoginHandler : IRequestHandler<LoginCommand, LoginDto>
{
    private readonly StudentService _studentService;
    
    public LoginHandler(StudentService service)
    {
        _studentService = service ?? throw new ArgumentNullException(nameof(service));
    }

    public async Task<LoginDto> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        Student student = await _studentService.GetStudentByIdentification(request.Identification);
        return new LoginDto(student.Name, student.Identification);
    }
}
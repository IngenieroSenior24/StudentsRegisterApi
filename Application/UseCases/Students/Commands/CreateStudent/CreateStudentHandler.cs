using Application.UseCases.Students.Commands.AddSubject;
using Domain.Entities;
using Domain.Ports;
using Domain.Services;

namespace Application.UseCases.Students.Commands.CreateStudent;

public class CreateStudentHandler : IRequestHandler<CreateStudentCommand>
{
    private readonly StudentService _studentService;
    
    public CreateStudentHandler(StudentService service)
    {
        _studentService = service ?? throw new ArgumentNullException(nameof(service));
    }

    public async Task<Unit> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
    {
        Student student = new(request.Name, request.Identification);
        await _studentService.CreateAsync(student);
        return new Unit();
    }
}
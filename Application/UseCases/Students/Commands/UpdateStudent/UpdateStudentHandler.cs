using Domain.Services;

namespace Application.UseCases.Students.Commands.UpdateStudent;

public class UpdateStudentHandler : IRequestHandler<UpdateStudentCommand>
{
    private readonly StudentService _studentService;

    public UpdateStudentHandler(StudentService service)
    {
        _studentService = service ?? throw new ArgumentNullException(nameof(service));
    }

    public async Task<Unit> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
    {
        await _studentService.UpdateAsync(request.Identification, request.Name);
        return new Unit();
    }
}

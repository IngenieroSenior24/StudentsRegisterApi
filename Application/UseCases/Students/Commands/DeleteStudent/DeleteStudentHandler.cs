using Domain.Services;

namespace Application.UseCases.Students.Commands.DeleteStudent;

public class DeleteStudentHandler : IRequestHandler<DeleteStudentCommand>
{
    private readonly StudentService _studentService;

    public DeleteStudentHandler(StudentService service)
    {
        _studentService = service ?? throw new ArgumentNullException(nameof(service));
    }

    public async Task<Unit> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
    {
        await _studentService.DeleteAsync(request.Identification);
        return new Unit();
    }
}

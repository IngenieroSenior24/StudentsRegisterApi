using Domain.Entities;
using Domain.Services;

namespace Application.UseCases.Students.Commands.AddSubject;

public class AddSubjectHandler : IRequestHandler<AddSubjectCommand>
{
    private readonly StudentService _studentService;
    
    public AddSubjectHandler(StudentService service)
    {
        _studentService = service ?? throw new ArgumentNullException(nameof(service));
    }

    public async Task<Unit> Handle(AddSubjectCommand request, CancellationToken cancellationToken)
    {
        await _studentService.AddSubject(request.Identification, request.SubjectsId);
        return new Unit();
    }
}
using Application.Common.Exceptions;
using Application.Ports;
using Domain.Entities;

namespace Application.UseCases.Students.Queries.GetStudentsBySubjectIdAndIdentification;

public class GetStudentsBySubjectIdAndIndentificationHandler : IRequestHandler<GetStudentsBySubjectIdAndIndentificationQuery, IEnumerable<GetStudentsBySubjectIdAndIndentificationDto>>
{
    private readonly IReadRepository<StudentSubject> _repository;

    public GetStudentsBySubjectIdAndIndentificationHandler(IReadRepository<StudentSubject> repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    public async Task<IEnumerable<GetStudentsBySubjectIdAndIndentificationDto>> Handle(GetStudentsBySubjectIdAndIndentificationQuery query, CancellationToken cancellationToken)
    {
        bool isEnrolled = await _repository.AnyAsync(new IsStudentEnrolledSpec(query.Identification, query.SubjectId), cancellationToken);

        if (!isEnrolled)
        {
            throw new NotFoundException("No puede consultar los estudiantes de una materia a la que no asistes");
        }
        
        GetAllSubjectsByIdentificationSpec spec = new(query.SubjectId);
        return await _repository.ListAsync(spec, cancellationToken);
    }
}
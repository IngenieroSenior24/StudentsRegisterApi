
namespace Application.UseCases.Students.Queries.GetStudentsBySubjectIdAndIdentification;

public record GetStudentsBySubjectIdAndIndentificationQuery : IRequest<IEnumerable<GetStudentsBySubjectIdAndIndentificationDto>>
{
    public string Identification { get; set; }
    public Guid SubjectId { get; set; }

    public GetStudentsBySubjectIdAndIndentificationQuery(string identification, Guid subjectId)
    {
        Identification = identification;
        SubjectId = subjectId;
    }
}

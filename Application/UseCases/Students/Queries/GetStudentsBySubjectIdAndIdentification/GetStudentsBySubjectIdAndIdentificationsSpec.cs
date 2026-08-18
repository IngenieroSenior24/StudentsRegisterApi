using Ardalis.Specification;
using Domain.Entities;

namespace Application.UseCases.Students.Queries.GetStudentsBySubjectIdAndIdentification;

public class GetAllSubjectsByIdentificationSpec : Specification<StudentSubject, GetStudentsBySubjectIdAndIndentificationDto>
{
    public GetAllSubjectsByIdentificationSpec(Guid subjectId)
    {
        Query.Where(s => s.SubjectId == subjectId);
        Query.OrderByDescending(Subject => Subject.CreatedOn);
    }
}

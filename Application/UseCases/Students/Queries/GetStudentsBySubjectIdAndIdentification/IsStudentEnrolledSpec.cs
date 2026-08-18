using Ardalis.Specification;
using Domain.Entities;

namespace Application.UseCases.Students.Queries.GetStudentsBySubjectIdAndIdentification;

public class IsStudentEnrolledSpec : Specification<StudentSubject>
{
    public IsStudentEnrolledSpec(string identification, Guid subjectId)
    {
        Query.Where(s => s.Student.Identification == identification && s.SubjectId == subjectId);
    }
}

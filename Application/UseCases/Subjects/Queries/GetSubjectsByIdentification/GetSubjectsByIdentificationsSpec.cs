using Ardalis.Specification;
using Domain.Entities;

namespace Application.UseCases.Subjects.Queries.GetSubjectsByIdentification;

public class GetAllSubjectsByIdentificationSpec : Specification<StudentSubject, GetSubjectByIdentificationDto>
{
    public GetAllSubjectsByIdentificationSpec(string identification)
    {
        Query.Include(s => s.Student);
        Query.Where(s => s.Student.Identification == identification);
        Query.OrderByDescending(Subject => Subject.CreatedOn);
    }
}

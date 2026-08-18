using Ardalis.Specification;
using Domain.Entities;

namespace Application.UseCases.Subjects.Queries.GetAllSubject;

public class GetAllSubjectsSpec : Specification<Subject, GetAllSubjectDto>
{
    public GetAllSubjectsSpec()
    {
        Query.Include(s => s.ProfessorSubjects);

        Query.OrderByDescending(Subject => Subject.CreatedOn);
    }
}


namespace Application.UseCases.Subjects.Queries.GetAllSubject;

public record GetAllSubjectDto(Guid Id, string Name, int Credits, ProfessorDto Professor);
public record ProfessorDto(Guid Id, string Name);

namespace Application.UseCases.Subjects.Queries.GetSubjectsByIdentification;

public record GetSubjectByIdentificationDto(Guid Id, string Name, GetSubjectByIdentificationProfessorDto Professor);
public record GetSubjectByIdentificationProfessorDto(string Name);
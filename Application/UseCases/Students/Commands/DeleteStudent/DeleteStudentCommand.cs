namespace Application.UseCases.Students.Commands.DeleteStudent;

public record DeleteStudentCommand(string Identification) : IRequest<Unit>;

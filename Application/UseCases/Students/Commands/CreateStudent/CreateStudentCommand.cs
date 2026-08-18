namespace Application.UseCases.Students.Commands.CreateStudent;

public record CreateStudentCommand(string Name, string Identification): IRequest<Unit>;


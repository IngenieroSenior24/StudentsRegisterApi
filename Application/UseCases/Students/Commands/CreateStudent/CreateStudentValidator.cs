using Application.UseCases.Students.Commands.AddSubject;

namespace Application.UseCases.Students.Commands.CreateStudent;

public class CreateStudentValidator : AbstractValidator<CreateStudentCommand>
{
    public CreateStudentValidator()
    {
        RuleFor(_ => _.Name).NotNull().NotEmpty().MinimumLength(3).MaximumLength(100);
        RuleFor(_ => _.Identification).NotNull().NotEmpty().MinimumLength(9).MaximumLength(10);
    }
}
namespace Application.UseCases.Students.Commands.DeleteStudent;

public class DeleteStudentValidator : AbstractValidator<DeleteStudentCommand>
{
    public DeleteStudentValidator()
    {
        RuleFor(_ => _.Identification).NotNull().NotEmpty().MinimumLength(9).MaximumLength(10);
    }
}

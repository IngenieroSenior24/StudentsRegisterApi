namespace Application.UseCases.Students.Commands.UpdateStudent;

public class UpdateStudentValidator : AbstractValidator<UpdateStudentCommand>
{
    public UpdateStudentValidator()
    {
        RuleFor(_ => _.Name).NotNull().NotEmpty().MinimumLength(3).MaximumLength(100);
        RuleFor(_ => _.Identification).NotNull().NotEmpty().MinimumLength(9).MaximumLength(10);
    }
}

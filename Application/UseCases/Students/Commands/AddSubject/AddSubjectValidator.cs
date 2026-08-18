namespace Application.UseCases.Students.Commands.AddSubject;

public class AddSubjectValidator : AbstractValidator<AddSubjectCommand>
{
    public AddSubjectValidator()
    {
        RuleFor(_ => _.SubjectsId).NotNull().NotEmpty();
        RuleFor(_ => _.Identification).NotNull().NotEmpty().MinimumLength(9).MaximumLength(10);
    }
}
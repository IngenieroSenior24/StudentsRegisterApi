using Domain.Entities;

namespace Domain.Tests.Builders;

public class ProfessorBuilder
{
    private string _name = "Default Professor";
    private List<ProfessorSubject> _professorSubjects = new();

    public ProfessorBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public ProfessorBuilder WithSubjects(List<ProfessorSubject> professorSubjects)
    {
        _professorSubjects = professorSubjects;
        return this;
    }

    public Professor Build()
    {
        Professor professor = new (_name);
        foreach (ProfessorSubject subject in _professorSubjects)
        {
            professor.ProfessorSubjects.Add(subject);
        }
        return professor;
    }
}

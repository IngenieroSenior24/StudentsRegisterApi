using Domain.Entities;

namespace Domain.Tests.Builders;

public class StudentBuilder
{
    private string _name = "Default Student";
    private string _identification = "DefaultID";
    private List<StudentSubject> _studentSubjects = new();

    public StudentBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public StudentBuilder WithIdentification(string identification)
    {
        _identification = identification;
        return this;
    }

    public StudentBuilder WithSubjects(List<StudentSubject> studentSubjects)
    {
        _studentSubjects = studentSubjects;
        return this;
    }

    public Student Build()
    {
        Student student = new(_name, _identification);
        foreach (StudentSubject subject in _studentSubjects)
        {
            student.StudentSubjects.Add(subject);
        }
        return student;
    }
}

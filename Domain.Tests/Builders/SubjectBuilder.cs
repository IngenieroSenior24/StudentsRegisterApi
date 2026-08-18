using Domain.Entities;

namespace Domain.Tests.Builders;

public class SubjectBuilder
{
    private string _name = "Default Subject";

    public SubjectBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public Subject Build()
    {
        return new Subject(_name);
    }
}

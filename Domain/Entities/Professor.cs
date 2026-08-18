namespace Domain.Entities;

public class Professor : EntityBase<Guid>, IAggregateRoot
{
    private const int MaxSubjectsPerProfessor = 2;
    public string Name { get; private set; }
    public ICollection<ProfessorSubject> ProfessorSubjects { get; set; } = new List<ProfessorSubject>();

    public Professor(string name)
    {
        Name = name;
        ProfessorSubjects = new List<ProfessorSubject>();
    }

    public void AddSubject(Subject subject)
    {
        if (ProfessorSubjects.Count >= MaxSubjectsPerProfessor)
        {
            throw new InvalidOperationException("Un profesor no puede dictar más de 2 materias.");
        }

        ProfessorSubjects.Add(new ProfessorSubject(Id, subject.Id));
    }
}
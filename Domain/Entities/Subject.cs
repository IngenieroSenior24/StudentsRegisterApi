namespace Domain.Entities;
public class Subject : EntityBase<Guid>, IAggregateRoot
{
    private const int CreditsPerSubject = 3;
    private const int MaxProfessorsPerSubject = 2;
    public string Name { get; private set; }
    public int Credits { get; private set; }
    public ICollection<ProfessorSubject> ProfessorSubjects { get; set; } = new List<ProfessorSubject>();
    public ICollection<StudentSubject> StudentSubjects { get; set; } = new List<StudentSubject>();

    public Subject(string name)
    {
        Name = name;
        Credits = CreditsPerSubject;
        ProfessorSubjects = new List<ProfessorSubject>();
        StudentSubjects = new List<StudentSubject>();
    }

    public void AssignProfessor(Professor professor)
    {
        if (ProfessorSubjects.Count >= MaxProfessorsPerSubject)
        {
            throw new InvalidOperationException("Una materia no puede tener más de 2 profesores.");
        }

        ProfessorSubjects.Add(new ProfessorSubject(professor.Id, Id));
    }
}
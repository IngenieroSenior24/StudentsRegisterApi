namespace Domain.Entities;
public class Student : EntityBase<Guid>, IAggregateRoot
{
    private const int MaxSubjects = 3;
    public string Name { get; private set; }
    public string Identification { get; private set; }
    public ICollection<StudentSubject> StudentSubjects { get; set; } = new List<StudentSubject>();

    public Student(string name, string identification)
    {
        Name = name;
        Identification = identification;
        StudentSubjects = new List<StudentSubject>();
    }

    public void UpdateName(string name)
    {
        Name = name;
    }

    public void AddSubject(Guid subjectId, Guid professorId)
    {
        if (StudentSubjects.Count >= MaxSubjects)
        {
            throw new InvalidOperationException("El estudiante no puede inscribirse en más de 3 materias.");
        }

        if (StudentSubjects.Any(ss => ss.SubjectId == subjectId))
        {
            throw new InvalidOperationException("El estudiante no puede tener registrado la misma materia");
        }

        if (StudentSubjects.Any(ss => ss.ProfessorId == professorId))
        {
            throw new InvalidOperationException("El estudiante no puede tener más de una clase con el mismo profesor.");
        }

        StudentSubjects.Add(new StudentSubject(Id, subjectId, professorId));
    }
}

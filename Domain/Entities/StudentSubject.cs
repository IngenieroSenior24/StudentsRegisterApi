namespace Domain.Entities;

public class StudentSubject : EntityBase<Guid>, IAggregateRoot
{
    public Guid StudentId { get; private set; }
    public Student Student { get; set; }
    public Guid SubjectId { get; private set; }
    public Subject Subject { get; private set; }
    public Guid ProfessorId { get; private set; }
    public Professor Professor { get; private set; }

    public StudentSubject(Guid studentId, Guid subjectId, Guid professorId)
    {
        StudentId = studentId;
        SubjectId = subjectId;
        ProfessorId = professorId;
    }
}

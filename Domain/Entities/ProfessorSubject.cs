namespace Domain.Entities;

public class ProfessorSubject : EntityBase<Guid>, IAggregateRoot
{
    public Guid ProfessorId { get; set; }
    public Professor Professor { get; set; }

    public Guid SubjectId { get; set; }
    public Subject Subject { get; set; }

    public ProfessorSubject(Guid professorId, Guid subjectId)
    {
        ProfessorId = professorId;
        SubjectId = subjectId;
    }
}
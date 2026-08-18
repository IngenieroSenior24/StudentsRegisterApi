using System.Text.Json.Serialization;

namespace Application.UseCases.Students.Commands.AddSubject;

public class AddSubjectCommand : IRequest<Unit>
{
    [JsonIgnore]
    public string Identification { get; set; }
    public IEnumerable<Guid> SubjectsId { get; set; }

    public AddSubjectCommand(string identification, IEnumerable<Guid> subjectsId)
    {
        Identification = identification;
        SubjectsId = subjectsId;
    }
}


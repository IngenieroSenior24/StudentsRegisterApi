using System.Text.Json.Serialization;

namespace Application.UseCases.Students.Commands.UpdateStudent;

public class UpdateStudentCommand : IRequest<Unit>
{
    [JsonIgnore]
    public string Identification { get; set; }
    public string Name { get; set; }

    public UpdateStudentCommand(string identification, string name)
    {
        Identification = identification;
        Name = name;
    }
}

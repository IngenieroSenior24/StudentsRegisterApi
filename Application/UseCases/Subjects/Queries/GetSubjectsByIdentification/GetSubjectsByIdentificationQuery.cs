
namespace Application.UseCases.Subjects.Queries.GetSubjectsByIdentification;

public record GetSubjectByIdentificationQuery : IRequest<IEnumerable<GetSubjectByIdentificationDto>>
{
    public string Identification { get; set; }

    public GetSubjectByIdentificationQuery(string identification)
    {
        Identification = identification;
    }
}

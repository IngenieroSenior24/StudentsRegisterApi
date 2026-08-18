using Application.Ports;
using Domain.Entities;

namespace Application.UseCases.Subjects.Queries.GetSubjectsByIdentification;

public class GetSubjectByIdentificationHandler : IRequestHandler<GetSubjectByIdentificationQuery, IEnumerable<GetSubjectByIdentificationDto>>
{
    private readonly IReadRepository<StudentSubject> _repository;

    public GetSubjectByIdentificationHandler(IReadRepository<StudentSubject> repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    public async Task<IEnumerable<GetSubjectByIdentificationDto>> Handle(GetSubjectByIdentificationQuery query, CancellationToken cancellationToken)
    {
        GetAllSubjectsByIdentificationSpec spec = new(query.Identification);
        return await _repository.ListAsync(spec, cancellationToken);
    }
}
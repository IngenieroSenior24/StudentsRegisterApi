using Application.Ports;
using Domain.Entities;

namespace Application.UseCases.Subjects.Queries.GetAllSubject;

public class GetAllSujectHandler : IRequestHandler<GetAllSubjectQuery, IEnumerable<GetAllSubjectDto>>
{
    private readonly IReadRepository<Subject> _repository;

    public GetAllSujectHandler(IReadRepository<Subject> repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    public async Task<IEnumerable<GetAllSubjectDto>> Handle(GetAllSubjectQuery query, CancellationToken cancellationToken)
    {
        GetAllSubjectsSpec spec = new();
        return await _repository.ListAsync(spec, cancellationToken);
    }
}
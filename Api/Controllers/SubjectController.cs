using Application.UseCases.Subjects.Queries.GetAllSubject;
using Application.UseCases.Subjects.Queries.GetSubjectsByIdentification;
using MediatR;

namespace Api.Controllers;

[ApiController]
[Route(ApiRoutes.Subjects)]
public class SubjectController : ControllerBase 
{
    private readonly IMediator _mediator;

    public SubjectController(IMediator mediator) => _mediator = mediator;
    
    
    [HttpGet]
    public async Task<IEnumerable<GetAllSubjectDto>> GetAllSubject()
    {
        return await _mediator.Send(new GetAllSubjectQuery());
    }
    
    [HttpGet("{identification}")]
    public async Task<IEnumerable<GetSubjectByIdentificationDto>> GetAllSubject([FromRoute] string identification)
    {
        return await _mediator.Send(new GetSubjectByIdentificationQuery(identification));
    }
}

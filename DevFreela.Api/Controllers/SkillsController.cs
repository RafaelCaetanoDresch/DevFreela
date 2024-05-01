using DevFreela.Application.Queries.GetAllSkills;

namespace DevFreela.Api.Controllers;

[Route("api/skills")]
[Authorize]
public class SkillsController : ControllerBase
{
    private readonly IMediator _mediator;

    public SkillsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var query = new GetAllSkillsQuery();

        var skills = _mediator.Send(query);

        return Ok(skills);
    }
}

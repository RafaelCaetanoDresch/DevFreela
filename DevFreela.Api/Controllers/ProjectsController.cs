using DevFreela.Application.Commands.CreateProject;
using DevFreela.Application.Commands.UpdateProject;
using DevFreela.Application.InputModels;
using DevFreela.Application.Queries.GetAllProjects;
using DevFreela.Application.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.Api.Controllers;

[Route("api/projects")]
public class ProjectsController : ControllerBase
{
    private readonly IProjectService _projectService;
    private readonly IMediator _mediator;

    public ProjectsController(IProjectService projectService, IMediator mediator)
    {
        _projectService = projectService;
        _mediator = mediator;
    }

    //api/projects?query=netcore
    [HttpGet]
    public async Task<IActionResult> Get(string queryParam)
    {
        var query = new GetAllProjectsQuery(queryParam);

        var projects = await _mediator.Send(query);

        return Ok(projects);
    }

    //api/projects/1
    [HttpGet("{id}")]// => Get a project By Project ID
    public IActionResult GetById(Guid id)
    {
        var project = _projectService.GetById(id);

        if(project is null)
            return NotFound();

        return Ok(project);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateProjectCommand command)
    {
        if(command.Title.Length > 50)
            return BadRequest();

        var id = await _mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { id = id }, command);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody]UpdateProjectCommand command)
    {
        if (command.Description.Length > 200)
            return BadRequest();

        await _mediator.Send(command);

        return NoContent();
    }


    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        _projectService.Delete(id);
        return NoContent();
    }

    //api/projects/1/comments
    [HttpPost("{id}")]
    public IActionResult PostComment([FromBody] CreateCommentInputModel inputModel)
    {
        _projectService.CreateComment(inputModel);
        return NoContent();
    }

    //api/projects/1/start
    [HttpPut("{id}/start")]
    public IActionResult Start(Guid id)
    {
        _projectService.Start(id);
        return NoContent();
    }

    //api/projects/1/finish
    [HttpPut("{id}/finish")]
    public IActionResult Finish(Guid id)
    {
        _projectService.Start(id);
        return NoContent();
    }

}

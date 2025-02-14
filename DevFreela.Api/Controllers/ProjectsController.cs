﻿using DevFreela.Application.Commands.CreateComment;
using DevFreela.Application.Commands.CreateProject;
using DevFreela.Application.Commands.DeleteProject;
using DevFreela.Application.Commands.StartProject;
using DevFreela.Application.Commands.UpdateProject;
using DevFreela.Application.Queries.GetAllProjects;
using DevFreela.Application.Queries.GetProjectByID;

namespace DevFreela.Api.Controllers;

[Route("api/projects")]
public class ProjectsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProjectsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    //api/projects?query=netcore
    [HttpGet]
    [Authorize(Roles ="client, freelancer")]
    public async Task<IActionResult> Get(string queryParam)
    {
        var query = new GetAllProjectsQuery(queryParam);

        var projects = await _mediator.Send(query);

        return Ok(projects);
    }

    //api/projects/1
    [HttpGet("{id}")]// => Get a project By Project ID
    [Authorize(Roles = "client, freelancer")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var query = new GetProjectByIdCommand(id);

        var project = await _mediator.Send(query);

        if(project is null)
            return NotFound();

        return Ok(project);
    }

    [HttpPost]
    [Authorize(Roles = "client")]
    public async Task<IActionResult> Post([FromBody] CreateProjectCommand command)
    {
        var id = await _mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { id = id }, command);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "client")]
    public async Task<IActionResult> Put(int id, [FromBody]UpdateProjectCommand command)
    {
        if (command.Description.Length > 200)
            return BadRequest();

        await _mediator.Send(command);

        return NoContent();
    }


    [HttpDelete("{id}")]
    [Authorize(Roles = "client")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var command = new DeleteProjectCommand(id);

        await _mediator.Send(command);

        return NoContent();
    }

    //api/projects/1/comments
    [HttpPost("{id}")]
    [Authorize(Roles = "client, freelancer")]
    public async Task<IActionResult> PostComment([FromBody] CreateCommentCommand command)
    {
        await _mediator.Send(command);

        return NoContent();
    }

    //api/projects/1/start
    [HttpPut("{id}/start")]
    [Authorize(Roles = "client")]
    public async Task<IActionResult> Start(Guid id)
    {
        var command = new StartProjectCommand(id);
        await _mediator.Send(command);
        return NoContent();
    }

    //api/projects/1/finish
    [HttpPut("{id}/finish")]
    [Authorize(Roles = "client")]
    public async Task<IActionResult> Finish(Guid id)
    {
        var command = new StartProjectCommand(id);
        await _mediator.Send(command);
        return NoContent();
    }

}

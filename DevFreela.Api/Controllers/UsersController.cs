using DevFreela.Api.Models;
using DevFreela.Application.Commands.CreateUser;
using DevFreela.Application.Queries.GetUserById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.Api.Controllers;

[Route("api/users")]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    //api/users/1
    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
        var command = new GetUserByIdCommand(id);

        var user = _mediator.Send(command);

        if (user is null) return NotFound();

        return Ok(user);
    }

    //api/users
    [HttpPost]
    public IActionResult Post([FromBody] CreateUserCommand command)
    {
        var id = _mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { id = id }, command);
    }


    //api/users/1/login
    [HttpPut("{id}/login")]
    public IActionResult Login(int id, LoginModel model)
    {
        //await _cache.GetOrCreateAsync("User",
        //    async e =>
        //    {
        //        e.AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(1);
        //        e.SlidingExpiration = TimeSpan.FromMinutes(20);

        //        return await _context;
        //    });
        
        return NoContent();
    }
}

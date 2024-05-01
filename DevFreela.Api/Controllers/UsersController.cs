using DevFreela.Application.Commands.CreateUser;
using DevFreela.Application.Commands.LoginUser;
using DevFreela.Application.Queries.GetAllUsers;
using DevFreela.Application.Queries.GetUserById;

namespace DevFreela.Api.Controllers;

[Route("api/users")]
[Authorize]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync(string queryParams)
    {
        var query = new GetAllUsersQuery(queryParams);
        return Ok(await _mediator.Send(query));
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
    [AllowAnonymous]
    public IActionResult Post([FromBody] CreateUserCommand command)
    {
        var id = _mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { id = id }, command);
    }


    //api/users/login
    [HttpPut("login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login(LoginUserCommand command)
    {
        //await _cache.GetOrCreateAsync("User",
        //    async e =>
        //    {
        //        e.AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(1);
        //        e.SlidingExpiration = TimeSpan.FromMinutes(20);

        //        return await _context;
        //    });
        var loginUserViewModel = await _mediator.Send(command);

        if (loginUserViewModel is null) return BadRequest();

        return Ok(loginUserViewModel);
    }
}

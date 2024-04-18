using DevFreela.Api.Models;
using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace DevFreela.Api.Controllers;

[Route("api/users")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    //api/users/1
    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
        var user = _userService.GetUser(id);
        if (user is null) return NotFound();

        return Ok(user);
    }

    //api/users
    [HttpPost]
    public IActionResult Post([FromBody] CreateUserInputModel inputModel)
    {
        var id = _userService.Create(inputModel);

        return CreatedAtAction(nameof(GetById), new { id = id }, inputModel);
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

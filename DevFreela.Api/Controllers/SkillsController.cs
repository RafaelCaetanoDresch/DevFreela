using DevFreela.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.Api.Controllers;

[Route("api/skills")]
public class SkillsController : ControllerBase
{
    private readonly ISkillService _skillSevice;

    public SkillsController(ISkillService skillSevice)
    {
        _skillSevice = skillSevice;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var skills = _skillSevice.GetAll();
        return Ok(skills);
    }
}

using System.Runtime.CompilerServices;
using CrudApi.Services;
using Microsoft.AspNetCore.Mvc;
namespace CrudApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CrudController : ControllerBase
{
    private readonly UserService _userService;
    public CrudController(UserService userService) =>
        _userService = userService;

    [HttpGet("{id:length(24)}")]
    public async Task<IActionResult> Get(string id)
    {
        var existingUser = await _userService.GetAsync(id);
        if (existingUser is null)
            return NotFound();
        return Ok(existingUser);
    }
}
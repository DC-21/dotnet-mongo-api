using System.Runtime.CompilerServices;
using CrudApi.Services;
using CrudApi.Models;
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
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var allUsers = await _userService.GetAsync();
        if (allUsers.Any())
            return Ok(allUsers);
        return NotFound();
    }
    [HttpPost]
    public async Task<IActionResult> Post(User user)
    {
        await _userService.CreateAsync(user);
        return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
    }
    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Put(User user)
    {
        await _userService.UpdateAsync(user);
        return NoContent();
    }
}
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Database;
using WebApi.Entities;
using WebApi.Models;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly DataService _dataService;
    public UserController(DataService dataService)
    {
        _dataService = dataService;
    }

    [HttpPost("/SignIn")]
    public async Task<IActionResult> SignIn([FromBody] CreateUserDto model )
    {
        _dataService.ReadData();
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return Ok();
    }
    [HttpPost("/SignUp")]
    public async Task<IActionResult> SignUp([FromBody] UserDto model)
    {
        _dataService.ReadData();
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        var check = _dataService.Users.Any(u => u.Username == model.Username);
        if (check)
        {
            return BadRequest();
        }

        var user = new User()
        {
            Id  = Guid.NewGuid(),
            Name = model.Name,
            Email = model.Email,
            Username = model.Username,
            Password = model.Password,
            Status = model.Status
        };
        _dataService.Users.Add(user);
        _dataService.SaveData();
        return Ok();
    }

}
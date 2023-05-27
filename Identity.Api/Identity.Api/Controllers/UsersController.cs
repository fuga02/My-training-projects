using System.Security.Claims;
using Identity.Api.DataBase;
using Identity.Api.Entities;
using Identity.Api.Models;
using Identity.Api.Services;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Identity.Api.Controllers;

[Route("/api/[controller]")]

public class UsersController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly ILogger<UsersController> _logger;
    private readonly TokenService _tokenService;

    public UsersController(AppDbContext context, ILogger<UsersController> logger, TokenService tokenService)
    {
        _context = context;
        _logger = logger;
        _tokenService = tokenService;
    }

    [HttpPost("/signIn")]
    public async Task<IActionResult> SignIn([FromBody]EnterUserDto model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var users = await _context.Users.ToListAsync();
        var user = users.FirstOrDefault(u => u.Username == model.Username  );
        if (user == null || user.Password == model.Password)
        {
            return NotFound();
        }

        var token = _tokenService.GenerateToken(user);
        return Ok(token);
    }

    [HttpPost("/signUp")]
    public async Task<IActionResult> SignUp([FromBody] UserDto model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        if (await _context.Users.AnyAsync(u => u.Username == model.Username))
        {
            return BadRequest();
        }

        var user = model.Adapt<User>();
         _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> Profile()
    {
        var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);

        return Ok(user);
    }

}
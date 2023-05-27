using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _70_lesson.Controllers;

[Route("api/[controller]")]
[ApiController]
public class Something : ControllerBase
{
    private readonly IConfiguration _configuration;
    
    public Something(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    [HttpGet]
    public IActionResult Message()
    {
        return Ok(_configuration.GetValue<string>("BotToken:BaseUrl")!);
    }
}
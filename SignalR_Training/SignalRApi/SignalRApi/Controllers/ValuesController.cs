using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRApi.Hubs;

namespace SignalRApi.Controllers;

[Route("/api/[controller]")]
[ApiController]
public class ValuesController : ControllerBase
{
    private readonly IHubContext<ValueHub> _hubContext;

    public ValuesController(IHubContext<ValueHub> hubContext)
    {
        _hubContext = hubContext;
    }

    [HttpGet("Values")]
    public List<int> Values()
    {
        return  Main.ListOfInt;
    }

    [HttpPost("Add")]
    public async Task Add(int value)
    {
         Main.ListOfInt.Add(value);
         await _hubContext.Clients.All.SendAsync("NewValue", value);
    }
}


public static class Main
{
    public static readonly List<int> ListOfInt = new List<int>() { 1, 2, 3 };
}
using BackgroundService.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackgroundService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ValuesController : ControllerBase
{
    [HttpPost("add")]
    public async Task<int> Add(int a, int b)
    {
        var result = await Calculate(a, b);
        return result;
    }
    private async Task<int> Calculate(int a, int b)
    {
        await Task.Delay(3000);
        return a + b;
    }
    [HttpPost("background")]
    public IActionResult AddJob(int a, int b)
    {
        var job = new Job()
        {
            Id = Guid.NewGuid(),
            A = a, B = b,

        };
        JobService.JobList.Add(job);

        return Ok(new
        {
            JobId = job.Id
        });
    }
    [HttpGet("backgrounds")]
    public IActionResult GetResult(Guid jobId)
    {
        var job = JobService.JobList.FirstOrDefault(j => j.Id == jobId);
        if (job == null)
        {
            return NotFound();
        }

        if (!job.IsReady)
        {
            return Ok("Pending ...");
        }

        return Ok(job);

    }


}
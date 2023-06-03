
namespace BackgroundService.Services;

public class CalculatorBackgroundService:Microsoft.Extensions.Hosting.BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var timer = new System.Threading.Timer(Tick, null, 0, 20000);
    }

    public void Tick(object state)
    {
        var jobs = JobService.JobList.Where(j => j.IsReady == false).ToList();
        foreach (var job in jobs)
        {
            job.Result = job.A + job.B;
            job.IsReady = true;
        }
    }

    private async Task<int> Calculate(int a, int b)
    {
        await Task.Delay(3000);
        return a  + b ;
    }


}




public class JobService
{
    public static List<Job> JobList { get; set; } = new List<Job>();
}

public class Job
{
    public Guid Id { get; set; }
    public int A { get; set; }
    public int B { get; set; }
    public int? Result { get; set; }

    public bool IsReady { get; set; }



}
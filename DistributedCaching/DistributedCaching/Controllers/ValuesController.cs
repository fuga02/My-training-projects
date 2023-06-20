using DistributedCaching.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

namespace DistributedCaching.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ValuesController : ControllerBase
{
    private readonly IDistributedCache _distributedCache;

    public ValuesController(IDistributedCache distributedCache)
    {
        _distributedCache = distributedCache;
    }


    [HttpPost]
    public async Task<int> Add(int a, int b)
    {
        var cacheKey = $"{a},{b}";
        if (_distributedCache.TryGetValue<int>(cacheKey, out var cacheResult))
        {
            return (int)cacheResult;
        }

        var result = await Calculate(a, b);

        await _distributedCache.SetAsync(cacheKey, result, new DistributedCacheEntryOptions()
        {
            SlidingExpiration = TimeSpan.FromSeconds(5),
            AbsoluteExpiration = DateTime.Now.AddMinutes(1)
        });
        return result;
    }


    private async Task<int> Calculate(int a, int b)
    {
        await Task.Delay(3000);
        return a + b;
    }
}
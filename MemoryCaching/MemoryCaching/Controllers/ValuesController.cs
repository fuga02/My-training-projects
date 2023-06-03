using MemoryCaching.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace MemoryCaching.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ValuesController : ControllerBase
{
    private readonly CacheService _cacheService;
    private readonly IMemoryCache _cache;
    public ValuesController(CacheService cacheService, IMemoryCache cache)
    {
        _cacheService = cacheService;
        _cache = cache;
    }

    [HttpPost("add")]
    public async Task<int> Add(int a, int b)
    {
        var cacheKey = $"{a},{b}";
        if (_cacheService.TryGetValue(cacheKey, out var value))
        {
            return (int)value!;
        }
        
        await Task.Delay(3000);
        int sum = a + b;
        _cacheService.Set(cacheKey,sum, DateTime.Now.AddSeconds(5));
        return sum;
    }

    [HttpPost("addV")]
    public async Task<int> AddV(int a, int b)
    {
        var cacheKey = $"{a} : {b}";
        return await _cache.GetOrCreateAsync(cacheKey, Create );
    }

    private async Task<int> Create(ICacheEntry entry)
    {
        entry.SlidingExpiration = TimeSpan.FromSeconds(5);

        var result = await Calculate(4, 7);
        return result;
    }

    private async Task<int> Calculate(int a, int b)
    {
        await Task.Delay(3000);
        var sum = a + b;
        return sum;
    }
}
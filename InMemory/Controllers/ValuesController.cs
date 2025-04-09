using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace InMemory.Controllers;

[ApiController]
[Route("[controller]")]

public class ValuesController(IMemoryCache cache) : ControllerBase
{
    
    // [HttpGet("set/{name}")]
    // public void Set(string name)
    // {
    //     cache.Set("name", name);
    // }
    //
    // [HttpGet]
    // public string Get()
    // {
    //     if (cache.TryGetValue<string>("name", out string? name))
    //     {
    //         return name;
    //     }
    //     return "Hello World!";
    //     // return  cache.Get<string>("name");
    // }
    [HttpGet("setdate")]
    public void SetDate()
    {
        cache.Set<DateTime>("date", DateTime.Now, options: new ()
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30),
            SlidingExpiration = TimeSpan.FromMinutes(5)
        });
    }
    
    [HttpGet]
    public DateTime GetDate()
    {
        return  cache.Get<DateTime>("date");
    }
    
}
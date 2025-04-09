using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

namespace Distributed.Caching.Controllers;

[ApiController]
[Route("[controller]")]
public class ValuesController(IDistributedCache cache) : ControllerBase
{
    [HttpGet("Set")]
    public async Task<IActionResult> Set(string name, string surname)
    {
        await cache.SetStringAsync("name", name, options: new()
        {
            AbsoluteExpiration = DateTime.Now.AddSeconds(30),
            SlidingExpiration = TimeSpan.FromMinutes(5)
        });
        await cache.SetAsync("surname", Encoding.UTF8.GetBytes(surname), options: new()
        {
            AbsoluteExpiration = DateTime.Now.AddSeconds(30),
            SlidingExpiration = TimeSpan.FromMinutes(5)
        });
        return Ok("Veriler Redis'e kaydedildi.");
    }

    [HttpGet("Get")]
    public async Task<IActionResult> Get()
    {
        var name = await cache.GetStringAsync("name");

        var binary = await cache.GetAsync("surname");
        var surname = binary != null ? Encoding.UTF8.GetString(binary) : null;

        return Ok(new { name, surname });
    }
}
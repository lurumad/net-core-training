using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

[Route("api/[controller]")]
public class ConfigurationController : ControllerBase
{
    [HttpGet]
    [Route("")]
    public IActionResult Get()
    {
        return Ok();
    }
}
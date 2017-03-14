using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace simplelogging
{
    [Route("api/[controller]")]
    public class LoggingController : ControllerBase
    {
        ILogger<LoggingController> logger;

        public LoggingController(ILogger<LoggingController> logger)
        {
            this.logger = logger;
        }

        public IActionResult Get()
        {
            logger.LogInformation("Enter in LoggingController.Get");

            return Ok();
        }
    }
}

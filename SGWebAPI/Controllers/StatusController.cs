using Microsoft.AspNetCore.Mvc;

namespace SGWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StatusController : ControllerBase
    {
        private readonly ILogger<StatusController> _logger;

        public StatusController(ILogger<StatusController> logger)
        {
            _logger = logger;
        }
        
        public string Get()
        {
            return "Your API is up and running";
        }
    }
}
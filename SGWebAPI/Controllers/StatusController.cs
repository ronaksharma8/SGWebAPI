using Microsoft.AspNetCore.Mvc;

namespace SGWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StatusController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "Your API is up and running";
        }
    }
}
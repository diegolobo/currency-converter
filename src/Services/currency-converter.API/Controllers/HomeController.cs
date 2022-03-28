using Microsoft.AspNetCore.Mvc;

namespace currency_converter.API.Controllers
{
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        [Route("api/version")]
        public IActionResult Get()
        {
            return Ok(new { version = typeof(Program).Assembly.GetName().Version.ToString() });
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace InitPro.Kassa.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class v1Controller : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Service started!");
        }
    }
}

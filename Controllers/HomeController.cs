using InitPro.Kassa.Api.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace InitPro.Kassa.Api.Controllers
{
    [Route("api/[controller]/{id?}")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly TokenHelper _kassaH;

        public HomeController(TokenHelper kassaHelper)
        {
            _kassaH = kassaHelper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Service started!");
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post(int id)
        {
            var t = _kassaH.GetToken().token;

            return Ok(id.ToString());
        }
    }
}

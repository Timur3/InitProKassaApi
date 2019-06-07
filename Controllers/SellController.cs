using InitPro.Kassa.Api.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace InitPro.Kassa.Api.Controllers
{
    [Route("api/[controller]/{id?}")]
    [ApiController]
    public class SellController : ControllerBase
    {
        private readonly TokenHelper _kassaH;

        public SellController(TokenHelper kassaHelper)
        {
            _kassaH = kassaHelper;
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

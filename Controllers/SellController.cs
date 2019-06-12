using InitPro.Kassa.Api.Helpers;
using InitPro.Kassa.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace InitPro.Kassa.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellController : ControllerBase
    {
        private readonly TokenHelper _tokenH;
        private readonly SellHelper _sellH;

        public SellController(TokenHelper tokenHelper, SellHelper sellH)
        {
            _tokenH = tokenHelper;
            _sellH = sellH;
        }

        [HttpPost]
        public IActionResult Post(SellModel model)
        {
            var tokenResponse = _tokenH.GetToken();
            if (tokenResponse.error != null)
            {
                return BadRequest(tokenResponse);
            }

            var sellResponse = _sellH.SellReceiptAccepted(model, tokenResponse.token);
            if (sellResponse.error != null)
            {
                return BadRequest(sellResponse);
            }

            return Ok(sellResponse);
        }
    }
}

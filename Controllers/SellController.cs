using InitPro.Kassa.Api.Helpers;
using InitPro.Kassa.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace InitPro.Kassa.Api.Controllers
{
    [Route("api/[controller]/{id?}")]
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
            model.Token = tokenResponse.token;

            var sellResponse = _sellH.SellReceiptAccepted(model);

            return Ok();
        }
    }
}

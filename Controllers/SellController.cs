using System;
using InitPro.Kassa.Api.Helpers;
using InitPro.Kassa.Api.Models;
using InitPro.Kassa.Api.Models.Response;
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
            SellResponse response;

            var tokenResponse = _tokenH.GetToken();
            if (tokenResponse.error != null)
            {
                return BadRequest(tokenResponse);
            }

            if (model.Price < 0)
            {
                model.Price = Math.Abs(model.Price);
                response = _sellH.SellReceiptAccepted(model, tokenResponse.token, "/sell_refund");
            }
            else
            {
                response = _sellH.SellReceiptAccepted(model, tokenResponse.token, "/sell");
            }

            if (response.error != null)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}

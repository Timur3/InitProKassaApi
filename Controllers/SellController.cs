using System.Collections.Generic;
using System.IO;
using InitPro.Kassa.Api.Helpers;
using InitPro.Kassa.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

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
            var token = tokenResponse.token;

            var sellResponse = _sellH.SellReceiptAccepted(model, token);

            return Ok(sellResponse);
        }
    }
}

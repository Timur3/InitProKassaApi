using InitPro.Kassa.Api.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace InitPro.Kassa.Api.Controllers
{
    [Route("api/[controller]/{uuid}")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly TokenHelper _tokenH;
        private readonly ReportHelper _reportH;

        public ReportController(TokenHelper tokenHelper, ReportHelper reportHelper)
        {
            _tokenH = tokenHelper;
            _reportH = reportHelper;
        }

        [HttpGet]
        public IActionResult Get(string uuid)
        {
            var tokenResponse = _tokenH.GetToken();
            var token = tokenResponse.token;
            var reportResponse = _reportH.GetReceiptStatus(uuid, token);

            return Ok(reportResponse);
        }
    }
}
using InitPro.Kassa.Api.Models;
using InitPro.Kassa.Api.Models.Request;
using InitPro.Kassa.Api.Models.Response;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RestSharp;

namespace InitPro.Kassa.Api.Helpers
{
    public class TokenHelper
    {
        private readonly ILogger<TokenHelper> _logger;
        private readonly InitProSettings _settings;

        public TokenHelper(IOptions<InitProSettings> options, ILogger<TokenHelper> logger)
        {
            _logger = logger;
            _settings = options.Value;
        }

        public TokenResponse GetToken()
        {
            _logger.LogDebug("Requesting new InitPro token");
            
            const string operation = "getToken";
            var baseUrl = _settings.BaseUrl;

            var tokenRequest = new TokenRequest
            {
                login = _settings.Login,
                pass = _settings.Pass
            };

            var client = new RestClient(baseUrl + operation);
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/json");
            request.AddParameter("application/json", Newtonsoft.Json.JsonConvert.SerializeObject(tokenRequest), ParameterType.RequestBody);
            var response = client.Execute<TokenResponse>(request);
            return response.Data;
        }

    }
}

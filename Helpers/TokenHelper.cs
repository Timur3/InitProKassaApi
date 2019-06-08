using System.Net.Http;
using InitPro.Kassa.Api.Models;
using InitPro.Kassa.Api.Models.Response;
using Microsoft.Extensions.Options;
using RestSharp;

namespace InitPro.Kassa.Api.Helpers
{
    public class TokenHelper
    {
        private readonly InitProSettings _settings;

        public TokenHelper(IOptions<InitProSettings> options)
        {         
            _settings = options.Value;
        }

        public TokenResponse GetToken()
        {
            string operation = "getToken";
            string _baseUrl = _settings.BaseUrl;

            var tokenRequest = new TokenRequest
            {
                login = _settings.Login,
                pass = _settings.Pass
            };
            var client = new RestClient(_baseUrl + operation);
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/json");
            request.AddParameter("application/json", Newtonsoft.Json.JsonConvert.SerializeObject(tokenRequest), ParameterType.RequestBody);
            var response = client.Execute<TokenResponse>(request);
            return response.Data;
        }

    }
}

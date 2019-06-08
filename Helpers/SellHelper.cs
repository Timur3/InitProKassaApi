using InitPro.Kassa.Api.Models;
using InitPro.Kassa.Api.Models.Response;
using Microsoft.Extensions.Options;
using RestSharp;

namespace InitPro.Kassa.Api.Helpers
{
    public class SellHelper
    {
        private readonly InitProSettings _settings;

        public SellHelper(IOptions<InitProSettings> options)
        {
            _settings = options.Value;
        }

        public SellResponse SellReceiptAccepted(SellModel model)
        {
            string operation = "sell";
            string baseUrl = _settings.BaseUrl;

            var tokenRequest = new TokenRequest
            {
                login = _settings.Login,
                pass = _settings.Pass
            };
            var client = new RestClient(baseUrl + operation);
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/json");
            request.AddParameter("application/json", Newtonsoft.Json.JsonConvert.SerializeObject(tokenRequest), ParameterType.RequestBody);
            var response = client.Execute<SellResponse>(request);
            return response.Data;
        }
    }
}

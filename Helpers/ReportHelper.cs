using InitPro.Kassa.Api.Models;
using InitPro.Kassa.Api.Models.Response;
using Microsoft.Extensions.Options;
using RestSharp;
using Serilog;

namespace InitPro.Kassa.Api.Helpers
{
    public class ReportHelper
    {
        private readonly ILogger _logger;
        private readonly InitProSettings _settings;

        public ReportHelper(IOptions<InitProSettings> options, ILogger logger)
        {
            _logger = logger;
            _settings = options.Value;
        }

        public ReportResponse GetReceiptStatus(string uuid, string token)
        {
            string operation = "/report/" + uuid;
            var baseUrl = _settings.BaseUrl;

            var client = new RestClient(baseUrl + _settings.GroupCode + operation);
            var request = new RestRequest(Method.GET);
            request.AddHeader("Token", token);

            var response = client.Execute<ReportResponse>(request);
            
            _logger
                .ForContext("Request", uuid, true)
                .ForContext("Response", response.Data, true)
                .Information("Receipt {RequestMethod} request {RequestPath} responded {StatusCode}", request.Method, operation, (int)response.StatusCode);
            
            return response.Data;
        }
    }
}

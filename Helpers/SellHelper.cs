using System;
using InitPro.Kassa.Api.Enums;
using InitPro.Kassa.Api.Models;
using InitPro.Kassa.Api.Models.Request;
using InitPro.Kassa.Api.Models.Response;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using Serilog;

namespace InitPro.Kassa.Api.Helpers
{
    public class SellHelper
    {
        private readonly InitProSettings _settings;
        private readonly VatHelper _vatHelper;
        private readonly ILogger _logger;

        public SellHelper(IOptions<InitProSettings> options, VatHelper vatHelper, ILogger logger)
        {
            _settings = options.Value;
            _vatHelper = vatHelper;
            _logger = logger;
        }

        public SellResponse SellReceiptAccepted(SellModel model, string token, string operation)
        {
            //string operation = "/sell";
            string baseUrl = _settings.BaseUrl;
            decimal Sum = model.Price * model.Quantity;

            var sellRequest = new SellRequest()
            {
                external_id = model.Id,
                receipt = new Receipt()
                {
                    client = new Client()
                    {
                        email = model.Email,
                        phone = model.Phone
                    },
                    company = new Company()
                    {
                        email = _settings.Email,
                        inn = _settings.Inn,
                        sno = _settings.Sno,
                        payment_address = _settings.Payment_address
                    },
                    items = new[]
                    {
                        new Item()
                        {
                            name = model.ItemName,
                            price = model.Price,
                            quantity = model.Quantity,
                            sum = Sum,
                            measurement_unit = model.MeasurementUnit,
                            payment_method = PaymentMethod.full_payment.ToString(),
                            payment_object = PaymentObject.commodity.ToString(),
                            vat = new Vat()
                            {
                                type = VatType.vat20.ToString()
                            }
                        }
                    },
                    payments = new Payment[]
                    {
                        new Payment()
                        {
                            type = PaymentType.Electronic,
                            sum = Sum
                        }
                    },
                    total = Sum,
                    vats = null 
                },
                service = new Service()
                {
                    callback_url = "https://lk.mp-ges.ru/"
                },
                timestamp = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss")
            };
            var client = new RestClient(baseUrl + _settings.GroupCode + operation);
            var request = new RestRequest(Method.POST);
            var param = JsonConvert.SerializeObject(sellRequest, Formatting.Indented, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });
            request.AddHeader("content-type", "application/json");
            request.AddHeader("Token", token);
            request.AddParameter("application/json", param, ParameterType.RequestBody);

            var response = client.Execute<SellResponse>(request);

            _logger
                .ForContext("Request", sellRequest, true)
                .ForContext("Response", response.Data, true)
                .Information("Receipt {RequestMethod} request {RequestPath} responded {StatusCode}", request.Method, operation, (int)response.StatusCode);

            return response.Data;
        }
    }
}

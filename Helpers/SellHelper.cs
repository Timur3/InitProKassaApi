using System;
using InitPro.Kassa.Api.Enums;
using InitPro.Kassa.Api.Models;
using InitPro.Kassa.Api.Models.Request;
using InitPro.Kassa.Api.Models.Response;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;

namespace InitPro.Kassa.Api.Helpers
{
    public class SellHelper
    {
        private readonly InitProSettings _settings;
        private readonly VatHelper _vatHelper;

        public SellHelper(IOptions<InitProSettings> options, VatHelper vatHelper)
        {
            _settings = options.Value;
            _vatHelper = vatHelper;
        }

        public SellResponse SellReceiptAccepted(SellModel model, string token)
        {
            string operation = "/sell";
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
                    items = new Item[]
                    {
                        new Item()
                        {
                            name = model.ItemName,
                            price = model.Price,
                            quantity = model.Quantity,
                            sum = Sum,
                            agent_info = null,
                            measurement_unit = model.MeasurementUnit,
                            payment_method = PaymentMethod.full_payment.ToString("F"),
                            payment_object = PaymentObject.commodity.ToString("F"),
                            vat = new Vat()
                            {
                                type = VatType.vat20.ToString("F"),
                                sum = null
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
                    callback_url = "http://kabinet.hm-ges.ru/"
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
            return response.Data;
        }
    }
}

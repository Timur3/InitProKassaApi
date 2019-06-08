using System;
using InitPro.Kassa.Api.Enums;
using InitPro.Kassa.Api.Models;
using InitPro.Kassa.Api.Models.Request;
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

            var sellRequest = new SellRequest()
            {
                external_id = model.Id,
                receipt = new Receipt()
                {
                    client = new Client()
                    {
                        email = "asu@mp-ges.ru",
                        phone = "+79090334460"
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
                            sum = model.Sum,
                            agent_info = null,
                            measurement_unit = null,
                            payment_method = PaymentMethod.full_payment,
                            payment_object = PaymentObject.commodity,
                            vat = new Vat()
                            {
                                sum = model.Sum,
                                type = VatType.vat20
                            }
                        }
                    },
                    payments =new Payment[]
                    {
                        new Payment(), 
                    },
                    total = model.Sum,
                    vats = new Vat[]
                    {
                        new Vat()
                        {
                            sum = model.Sum,
                            type = VatType.vat20
                        }
                    }
                },
                service = new Service()
                {
                    callback_url = ""
                },
                timestamp = DateTime.Now
            };
            var client = new RestClient(baseUrl + operation);
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/json");
            request.AddParameter("application/json", Newtonsoft.Json.JsonConvert.SerializeObject(sellRequest), ParameterType.RequestBody);
            var response = client.Execute<SellResponse>(request);
            return response.Data;
        }
    }
}

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
        private readonly VatHelper _vatHelper;

        public SellHelper(IOptions<InitProSettings> options, VatHelper vatHelper)
        {
            _settings = options.Value;
            _vatHelper = vatHelper;
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
                            measurement_unit = model.MeasurementUnit,
                            payment_method = PaymentMethod.full_payment,
                            payment_object = PaymentObject.commodity,
                            vat = new Vat()
                            {
                                type = VatType.vat20
                            }
                        }
                    },
                    payments = new Payment[]
                    {
                        new Payment()
                        {
                            type = PaymentType.Electronic,
                            sum = model.Sum
                        }
                    },
                    total = model.Sum,
                    vats = new Vat[]
                    {
                        new Vat()
                        {
                            sum = _vatHelper.GetVatSum(model.Sum, VatType.vat20),
                            type = VatType.vat20
                        }
                    }
                },
                service = new Service()
                {
                    callback_url = null
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

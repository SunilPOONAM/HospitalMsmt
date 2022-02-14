using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Services.TapPayment
{
    public class TapPayment: ITapPayment
    {
        private readonly IConfiguration _configuration;
        private string ApiURL = "";
        private string siteURL = "";

        public TapPayment(IConfiguration configuration)
        {
            _configuration = configuration;
            ApiURL = _configuration.GetSection("AppSettings")["TapPaymentAPIURL"];
            siteURL = _configuration.GetSection("AppSettings")["SiteUrl"];
        }
        public string ChargeCard(RootObject model)
        {
            using (var client = new HttpClient())
            {
                model.redirect.url = siteURL + model.RedirectUrl;
                model.post.url = siteURL + "/Payment/TapPaymentPost";
               // client.DefaultRequestHeaders.Add("content-type", "application/json");
                client.DefaultRequestHeaders.Add("Authorization", "Bearer sk_test_OcS6dEB4pxiVhwJWo0UfPDRy");
                HttpContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");              
                var data = client.PostAsync(ApiURL + "/charges",content).Result.Content.ReadAsStringAsync().Result;
                return data;
            }
          
        }

        public string RetrieveChargeDetail(string charge_id)
        {
            using (var client = new HttpClient())
            {
               
                client.DefaultRequestHeaders.Add("Authorization", "Bearer sk_test_OcS6dEB4pxiVhwJWo0UfPDRy");
             
                var data = client.GetAsync(ApiURL + "/charges/"+ charge_id).Result.Content.ReadAsStringAsync().Result;
                return data;
            }

        }
    }
}

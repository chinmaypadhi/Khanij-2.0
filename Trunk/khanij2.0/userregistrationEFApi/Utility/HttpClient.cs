using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using userregistrationEF;

namespace userregistrationEFApi.Utility
{
    public class HttpWebClients : IHttpWebClients
    { 
        private readonly IConfiguration configuration;

        public HttpWebClients(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string PostRequest(string URI, string parameterValues)
        {
            var rr = configuration.GetSection("KeyList");
            string BaseURI =rr["WebApiurl"];
            string URL = BaseURI + URI;
            string jsonString = null;
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            // Pass the handler to httpclient(from you are calling api)
            HttpClient client = new HttpClient(clientHandler);
            client.Timeout = TimeSpan.FromMinutes(30);
            var jwt = GetJwt();
            // using (var client = new HttpClient())
            // {

            client.BaseAddress = new Uri(URL);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt);
            //GET Method  
            HttpContent c = new StringContent(parameterValues, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(URL, c).Result;
            if (response.IsSuccessStatusCode)
            {
                jsonString = response.Content.ReadAsStringAsync()
                                               .Result
                                               //.Replace("\\", "")
                                               //.Replace("\r\n", "'")
                                               .Trim(new char[1] { '"' });
            }

            // }
            return jsonString;
        }

        public string GetRequest(string URI, object parameterValues)
        {
            string BaseURI = "";

            string URL = BaseURI + URI;
            string jsonString = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(URL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", "ZURTZWN1cml0eTplX0RfQVBJLXVyaQ==");
                //GET Method  
                HttpResponseMessage response = client.GetAsync(URL).Result;
                if (response.IsSuccessStatusCode)
                {
                    jsonString = response.Content.ReadAsStringAsync()
                                                   .Result
                                                   .Replace("\\", "")
                                                   .Trim(new char[1] { '"' });

                }
            }
            return jsonString;
        }

        private string GetJwt()
        {
            var rr = configuration.GetSection("KeyList");
            string BaseURI = rr["Authurl"];
            string URL = BaseURI + "auth?name=catcher&pwd=123";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL);
            client.DefaultRequestHeaders.Clear();

            var res2 = client.GetAsync(URL).Result;

            dynamic jwt = JsonConvert.DeserializeObject(res2.Content.ReadAsStringAsync().Result);

            return jwt.access_token;
        }
    }
}

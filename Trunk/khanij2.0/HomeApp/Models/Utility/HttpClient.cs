// ***********************************************************************
// Assembly         : Khanij
// Author           : Kumar jeevan jyoti
// Created          : 28-dec-2020
//

// ***********************************************************************
// <copyright file="CommonExtension.cs" company="CSM technologies">
//     Copyright ©  2020
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Configuration;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using HomeEF;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace HomeApp.Models.Utility
{

    public class HttpWebClients:IHttpWebClients
    {
        private readonly IOptions<KeyList> _objKeyList;
        public HttpWebClients(IOptions<KeyList> objKeyList)
        {
            _objKeyList = objKeyList;
        }
        public string PostRequest(string URI, string parameterValues)
        {
            string BaseURI = _objKeyList.Value.WebApiurl;
            string URL = BaseURI + URI;
            string jsonString = null;
            var jwt = GetJwt();
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(URL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt);
                client.Timeout= TimeSpan.FromMinutes(20);
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

            }
            return jsonString;
        }
        public string GetRequest(string URI, object parameterValues)
        {
            string BaseURI = _objKeyList.Value.WebApiurl;

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
                                                   //.Replace("\\", "")
                                                   .Trim(new char[1] { '"' });

                }
            }
            return jsonString;
        }
        //public static string PostRequest(string URI, string parameterValues)
        //{
        //    string BaseURI = "https://localhost:44363/api/";
        //    string URL = BaseURI + URI;
        //    string jsonString = null;
        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri(URL);
        //        client.DefaultRequestHeaders.Accept.Clear();
        //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", "QXBwOkFwcA==");

        //        //GET Method  
        //        HttpContent c = new StringContent(parameterValues, Encoding.UTF8, "application/json");
        //        HttpResponseMessage response = client.PostAsync(URL, c).Result;
        //        if (response.IsSuccessStatusCode)
        //        {
        //            jsonString = response.Content.ReadAsStringAsync()
        //                                           .Result
        //                                           //.Replace("\\", "")
        //                                           //.Replace("\r\n", "'")
        //                                           .Trim(new char[1] { '"' });
        //        }

        //    }
        //    return jsonString;
        //}
        //public static string GetRequest(string URI, object parameterValues)
        //{
        //    string BaseURI = "http://localhost/MasterApi/api/"; //System.Configuration.ConfigurationManager.AppSettings["WebAPIURI"].ToString();

        //    string URL = BaseURI + URI;
        //    string jsonString = null;
        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri(URL);
        //        client.DefaultRequestHeaders.Accept.Clear();
        //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", "ZURTZWN1cml0eTplX0RfQVBJLXVyaQ==");
        //        //GET Method  
        //        HttpResponseMessage response = client.GetAsync(URL).Result;
        //        if (response.IsSuccessStatusCode)
        //        {
        //            jsonString = response.Content.ReadAsStringAsync()
        //                                           .Result
        //                                           //.Replace("\\", "")
        //                                           .Trim(new char[1] { '"' });

        //        }
        //    }
        //    return jsonString;
        //}
        public async Task<string> AwaitPostRequest(string URI, string parameterValues)
        {
            string BaseURI = _objKeyList.Value.WebApiurl;
            string URL = BaseURI + URI;
            string jsonString = null;
            var jwt = GetJwt();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(URL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", "QXBwOkFwcA==");
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

            }
            return await Task.FromResult(jsonString);
        }
        private string GetJwt()
        {
            string BaseURI = _objKeyList.Value.WebApiurl;
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

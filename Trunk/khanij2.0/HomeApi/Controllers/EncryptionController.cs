// ***********************************************************************
//  Controller Name          : EncryptionController
//  Description              : Get Encrypt value details for Mobile Api
//  Created By               : Lingaraj Dalai
//  Created On               : 06 May 2022
// ***********************************************************************
using HomeEF;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace HomeApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    public class EncryptionController : Controller
    {
        private readonly IConfiguration _configuration;
        public EncryptionController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        /// <summary>
        /// To get Encrypted value
        /// </summary>
        /// <param name="routeValues"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult View(object routeValues)
        {
            var dataProtectionProvider = DataProtectionProvider.Create(new DirectoryInfo(_configuration.GetSection("KeyList").GetValue<string>("EncryptionPath")));
            var protector = dataProtectionProvider.CreateProtector("KhanijEncryptDecryptQuery.QueryStrings");
            string mainString = string.Empty;
            string queryString = string.Empty;
            var rvd = new RouteValueDictionary(routeValues);
            IList<string> strings = new List<string>();
            if (routeValues!=null)
            {
                for (int i = 0; i < rvd.Keys.Count; i++)
                {
                    strings.Add(rvd.Keys.ElementAt(i) + "=" + rvd.Values.ElementAt(i));
                }
                queryString += string.Join("?", strings);
                var format = new CultureInfo("en-GB");
                var random = Guid.NewGuid().ToString("N").Substring(0, 10).ToUpper();
                var values = string.Join("|", random, queryString, DateTime.Now.ToString(format));
                mainString = $"?q={protector.Protect(values)}";
                var responseJson = new
                {
                    encryptvalue = mainString
                };
                return Json(responseJson);
            }
            else
            {
                return Json("");
            }
        }
    }
}

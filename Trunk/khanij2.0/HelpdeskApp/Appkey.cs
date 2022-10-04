using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
namespace Appkey
{
    static class ConfigurationManager
    {
        public static IConfiguration MySettings { get; }
        static ConfigurationManager()
        {
            MySettings = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
        }
    }
}

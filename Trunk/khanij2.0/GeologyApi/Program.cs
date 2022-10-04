// ***********************************************************************
//  Class Name               : Program
//  Desciption               : Program
//  Created By               : Lingaraj Dalai
//  Created On               : 28 Dec 2020
// ***********************************************************************
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace GeologyApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}

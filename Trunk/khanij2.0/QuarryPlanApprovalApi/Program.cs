// ***********************************************************************
//  Class Name               : Program
//  Desciption               : Program
//  Created By               : Lingaraj Dalai
//  Created On               : 23 Jan 2022
// ***********************************************************************
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace QuarryPlanApprovalApi
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

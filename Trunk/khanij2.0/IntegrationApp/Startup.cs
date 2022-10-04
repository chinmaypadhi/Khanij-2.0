using System;
using System.IO;
using IntegrationApp.ActionFilter;
using IntegrationApp.ExceptionHandlear;
using IntegrationApp.Model.ExceptionList;
using IntegrationApp.Areas.Payment.Models.SBIPayment;
using IntegrationEF;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using System.Text.Json;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using IntegrationApp.Areas.Payment.Models.VehiclePaymentDetails;
using IntegrationApp.Models.SBIEncryptDecryptKey;
using IntegrationApp.Areas.Payment.Models.LicensePaymentDetails;
using IntegrationApp.Models.Utility;
using IntegrationApp.Models.MailService;
using IntegrationApp.Models.SMSService;
using IntegrationApp.Models.PaymentResponses;
using IntegrationApp.Areas.Payment.Models.MineralConcession;
using IntegrationApp.Helper;
using Microsoft.Extensions.Options;
using IntegrationApp.Areas.Payment.Models.DemandNotePayDetails;
using IntegrationApp.Areas.Payment.Models.NoticeLtrDetails;

namespace IntegrationApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddCors(options =>
            {

                options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                {
                    builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
                //builder.WithOrigins("*").AllowAnyHeader().WithMethods("GET", "POST");
                });

            });

            #region User fro Cookie
            services.AddDataProtection().PersistKeysToFileSystem(new DirectoryInfo(Configuration.GetSection("KeyList:RingPaths").Value))
         .SetApplicationName("SharedCookieApp");

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.Lax;
            });


            services.AddAuthentication("Identity.Application").AddCookie("Identity.Application", options =>
            {
                options.Cookie.Name = ".AspNet.SharedCookie";//Configuration.GetSection("KeyList:CookieName").Value;
                //options.LoginPath = "/Home/Index";
                //options.LogoutPath = "/Home/Index";
                options.Cookie.Domain = Configuration.GetSection("KeyList:DomenNAme").Value;
                options.Cookie.HttpOnly = true;
            });

            #endregion
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(10);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            services.AddDistributedMemoryCache();
            services.Configure<KeyList>(Configuration.GetSection("KeyList"));

            services.AddScoped<IExceptionProvider, ExceptionProvider>();
            services.AddScoped<ISBIPaymentModel, SBIPaymentModel>();
            services.AddScoped<IVehiclePaymentModel,VehiclePaymentModel>();
            services.AddSingleton<Microsoft.AspNetCore.Http.IHttpContextAccessor, Microsoft.AspNetCore.Http.HttpContextAccessor>();
            services.AddScoped<IsbiIncriptDecript,sbiIncriptDecript>();
            services.AddScoped<ILicensePaymentModel,LicensePaymentModel>();
            services.AddScoped<IHttpWebClients,HttpWebClients> ();
            services.AddTransient<IMailModel, MailModel>();
            services.AddTransient<ISMSModel, SMSModel>();
            services.AddTransient<IPaymentResponseModel, PaymentResponseModel>();
            services.AddScoped<IMineralConcessionModel, MineralConcessionModel>();
            services.AddScoped<IDemandNotePaymentDetailModel, DemandNotePaymentDetailModel>();
            services.AddScoped<INoticeLtr,NoticeLtr>();
            services.AddMvc(
                   config =>
                   {
                       config.Filters.Add(typeof(ExceptionFilterHandlear));
                       config.Filters.Add(typeof(SessionActionFilter));//comment by sanjay
                   }
                  ).AddNewtonsoftJson()
                .SetCompatibilityVersion(CompatibilityVersion.Latest)
              .AddJsonOptions(options =>
              {
                  options.JsonSerializerOptions.IgnoreNullValues = true;
                  options.JsonSerializerOptions.WriteIndented = true;
                  options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
              });

            services.AddMvc().AddSessionStateTempDataProvider();
            services.AddControllers()
          .AddNewtonsoftJson(options =>
          {
              options.UseMemberCasing();
          });
            services.AddControllers().AddJsonOptions(options => {
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
                options.JsonSerializerOptions.DictionaryKeyPolicy = null;

            });
            //Following is add by sanjay to get http response
            //services.AddSingleton<Microsoft.AspNetCore.Http.IHttpContextAccessor, Microsoft.AspNetCore.Http.HttpContextAccessor>();
            services.Configure<KestrelServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });

            // If using IIS:
            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //app.UseCors(x => x
            //.AllowAnyOrigin()
            //.AllowAnyMethod()
            //.AllowAnyHeader());
            //if (env.IsDevelopment())
            //{
            app.UseDeveloperExceptionPage();
            //}
            //else
            //{
            //    app.UseExceptionHandler("/Home/Error");
            //    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            //    app.UseHsts();
            //}
            CustomQueryStringHelper.CustomQueryStringHelperEncryptPath(app.ApplicationServices.GetService<IOptions<KeyList>>());
            app.UseSession();
            //app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            
            app.UseRouting();
            app.UseEndpoints(routes =>
            {
                routes.MapControllerRoute(
                name: "MyArea",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );

                routes.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
                routes.MapControllerRoute("areaRoute", "{area}/{controller}/{action}/{id?}");
            });
        }

    }
}

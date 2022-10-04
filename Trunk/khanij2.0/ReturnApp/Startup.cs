using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ReturnApp.ActionFilter;
using ReturnApp.Areas.Dailyproduction.Models;
using ReturnApp.Areas.eReturn_NonCoal.Models;
using ReturnApp.Areas.eReturn_NonCoal_Yearly.Models;
using ReturnApp.Areas.EReturnCoal.Models.ReturnCoalMonthly;
using ReturnApp.Areas.EReturnCoal.Models.ReturnCoalYearly;
using ReturnApp.ExceptionHandlear;
using ReturnApp.Model.ExceptionList;
using ReturnApp.Models;
using ReturnApp.Models.Utility;
using ReturnEF;

namespace ReturnApp
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


            services.AddTransient<IExceptionProvider, ExceptionProvider>();
            services.AddTransient<IDailyProductionModel, DailyProductionmodel>();
            services.AddTransient<IeReturnNonCoalModel, eReturnNonCoalModel>();
            services.AddTransient<IeReturnNonCoalForm2Model, eReturnNonCoalForm2Model>();
            services.AddTransient<IeReturnNonCoalYearlyG1Model, eReturnNonCoalYearlyG1Model>();
            services.AddTransient<IReturnCoalMonthlyModel, ReturnCoalMonthlyModel>();
            services.AddTransient<IReturnCoalYearlyModel, ReturnCoalYearlyModel>();
            services.AddTransient<IeReturnNonCoalYearlyG2Model, eReturnNonCoalYearlyG2Model>();
            services.AddTransient<IHttpWebClients, HttpWebClients>();
            services.AddSingleton<Microsoft.AspNetCore.Http.IHttpContextAccessor, Microsoft.AspNetCore.Http.HttpContextAccessor>();
            //services.AddSingleton<DataProtectionPurposeStrings>();
            services.AddMvc(
               config =>
               {
                   config.Filters.Add(typeof(ExceptionFilterHandlear));
                  // config.Filters.Add(typeof(SessionActionFilter));
               }
              ).SetCompatibilityVersion(CompatibilityVersion.Latest)
             .AddJsonOptions(options =>
              {
                  options.JsonSerializerOptions.IgnoreNullValues = true;
                  options.JsonSerializerOptions.WriteIndented = true;
              });
            services.AddMvc().AddSessionStateTempDataProvider();
            services.Configure<FormOptions>(options =>
            {
                options.ValueLengthLimit = int.MaxValue;
                options.MultipartBodyLengthLimit = int.MaxValue;
                options.MultipartHeadersLengthLimit = int.MaxValue;
                options.ValueCountLimit = int.MaxValue;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseRouting();
            app.UseSession();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();
            //app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "EReturn",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                   name: "default",
                   pattern: "{controller=Home}/{action=Index}/{id?}");


            });

            //app.UseEndpoints(routes =>
            //{
            //    routes.MapControllerRoute(
            //    name: "MyArea",
            //    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
            //    );

            //    routes.MapControllerRoute(
            //    name: "default",
            //    pattern: "{controller=Home}/{action=Index}/{id?}");
            //    routes.MapControllerRoute("areaRoute", "{area}/{controller}/{action}/{id?}");
            //});

        }
    }
}

using System;
using System.IO;
using PermitApp.ActionFilter;
using PermitApp.ExceptionHandlear;
using PermitApp.Model.ExceptionList;
using PermitApp.Areas.Permit.Models.Lessee;
using PermitApp.Areas.Permit.Models.CoalEPermit;
using PermitApp.Areas.Permit.Models.MergePermit;
using PermitApp.Areas.Permit.Models.Transit;
using PermitApp.Areas.Permit.Models.PaymentConfig;
using PermitApp.Areas.Permit.Models.LTP;
using PermitApp.Models.ValidityExpired;
using PermitEF;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using PermitApp.Models.Utility;
using PermitApp.Helper;
using Microsoft.Extensions.Options;
using PermitApp.Areas.ECCapping.Models.ECCapping;
using PermitApp.Areas.Permit.Models.GradeUpdate;
using PermitApp.Areas.DemandNote.Models;
using PermitApp.Areas.CoalGrade.Models;

namespace PermitApp
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
            services.AddScoped<ILesseePermitModel, LesseePermitModel>();
            services.AddScoped<ICoalEPermitModel, CoalEPermitModel>();
            services.AddScoped<IMergePermitModel, MergePermitModel>();
            services.AddScoped<ITransitPermitModel, TransitPermitModel>();
            services.AddScoped<IExceptionProvider, ExceptionProvider>();
            services.AddScoped<IPaymentConfigModel, PaymentConfigModel>();
            services.AddScoped<ILTPModel, LTPModel>();
            services.AddScoped<IValidityExpiredModel, ValidityExpiredModel>();
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IECCappingModel, ECCappingModel>();
            services.AddScoped<IUpgradeGrade, UpgradeGrade>();
            services.AddScoped<IDemandNote, DemandNote>();
            services.AddScoped<ICoalGrade, CoalGrade>();
            services.TryAddSingleton<IHttpWebClients, HttpWebClients>();
            services.AddMvc(
                   config =>
                   {
                       //config.Filters.Add(typeof(ExceptionFilterHandlear));
                        config.Filters.Add(typeof(SessionActionFilter));//comment it if debug without session
                   }
                  ).AddNewtonsoftJson()
                .SetCompatibilityVersion(CompatibilityVersion.Latest)
              .AddJsonOptions(options =>
              {
                  options.JsonSerializerOptions.IgnoreNullValues = true;
                  options.JsonSerializerOptions.WriteIndented = true;
              });

            services.AddMvc().AddSessionStateTempDataProvider();
            services.AddControllers()
          .AddNewtonsoftJson(options =>
          {
              options.UseMemberCasing();
          });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error"); 
            }
            CustomQueryStringHelper.CustomQueryStringHelperEncryptPath(app.ApplicationServices.GetService<IOptions<KeyList>>());
            app.UseSession();
            app.UseHttpsRedirection();
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

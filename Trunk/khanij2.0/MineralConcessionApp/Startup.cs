using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MineralConcessionApp.ExceptionHandlear;
using MineralConcessionApp.Model.ExceptionList;
using MineralConcessionApp.Areas.MajorMineral.Models.Mineral;
using MineralConcessionApp.Models.LesseeProfile;
using Microsoft.AspNetCore.DataProtection;
using System.IO;
using MineralConcessionApp.ActionFilter;
using MineralConcessionEF;
using MineralConcessionApp.Models.Utility;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace MineralConcessionApp
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
            services.AddTransient<Imineral, mineral>();
            services.AddTransient<ILesseprofile, Lesseprofile>();
            services.AddTransient<IHttpWebClients, HttpWebClients>();
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddMvc(
                   config =>
                   {
                       config.Filters.Add(typeof(ExceptionFilterHandlear));
                       config.Filters.Add(typeof(SessionActionFilter));
                   }
                  ).AddNewtonsoftJson()
                  .SetCompatibilityVersion(CompatibilityVersion.Latest).AddJsonOptions(options =>
                  {
                      options.JsonSerializerOptions.IgnoreNullValues = true;
                      options.JsonSerializerOptions.WriteIndented = true;
                  });

            services.AddMvc().AddSessionStateTempDataProvider();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
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

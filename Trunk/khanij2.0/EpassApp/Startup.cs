using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EpassApp.Areas.Epass.Models.PurchaserConsignee;
using EpassApp.ExceptionHandlear;
using EpassApp.Model.ExceptionList;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using EpassApp.Areas.Epass.Models.eTransitpass;
using EpassEF;
using Microsoft.AspNetCore.DataProtection;
using System.IO;
using EpassApp.ActionFilter;
using EpassApp.Models.Utility;
using EpassApp.Areas.Epass.Models.ePassConfiguration;
using Microsoft.Extensions.DependencyInjection.Extensions;
using EpassApp.Areas.Epass.Models.MineralReceive;
using EpassApp.Areas.Epass.Models.GeneratedRTPAPP;
using EpassApp.Areas.Epass.Models.TPCancel;
using EpassApp.Areas.Epass.Models.eCancel;
using EpassApp.Areas.Epass.Models.AdminUtility;
using EpassApp.Areas.Epass.Models.CheckPostInCharge;

namespace EpassApp
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
            #region Use For Cookie
            services.AddDataProtection().PersistKeysToFileSystem(new DirectoryInfo(Configuration.GetSection("KeyList:RingPaths").Value))
         .SetApplicationName("SharedCookieApp");

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.Unspecified;
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
            services.AddScoped<IHttpWebClients, HttpWebClients>();
            services.AddScoped<IExceptionProvider, ExceptionProvider>();
            services.AddScoped<IePassConfigurationModel, ePassConfigurationModel>();
            services.AddScoped<IMineralReceiveNew, MineralReceiveNew>();
            
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //services.AddScoped<IPurchaserConsigneeProvider, PurchaserConsigneeProvider>();
            //Added by shesansu
            services.AddTransient<IPurchaserConsigneeProvider, PurchaserConsigneeProvider>();
                 services.AddTransient<IFinalForwadingNoteModel, FinalForwadingNoteModel>();
            services.AddScoped<ITranitPassDetail, TranitPassDetail>();//Dinesh 26Apr
            services.AddScoped<IeCancel, eCancel>();//Dinesh 27Apr
            services.AddScoped<IAdminUtility, AdminUtility>();//Dinesh 29Apr
            services.AddTransient<IeTransitpass, Transitpass>();
            services.AddScoped<IcheckPostInChargeModel, checkPostInChargeModel>(); 
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

            services.AddSingleton<KhanijSecurity.UniqueCode>();
            services.AddSingleton<KhanijSecurity.KhanijIDataProtection>();
            // services.AddControllersWithViews().AddRazorRuntimeCompilation();

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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseRouting();
            app.UseSession();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "Licensee",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                   name: "default",
                   pattern: "{controller=Home}/{action=Index}/{id?}");


            });
        }
    }
}

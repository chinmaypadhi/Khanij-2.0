using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using userregistrationApp.ActionFilter;
using userregistrationApp.Areas.CommonRailwaySiding.Models;
using userregistrationApp.Areas.Contractor.Models.ContractorBuilders;
using userregistrationApp.Areas.Contractor.Models.SandStone;
using userregistrationApp.Areas.Contractor.Models.TailingDam;
using userregistrationApp.Areas.Contractor.Models.VTDVendor;
using userregistrationApp.Areas.EndUserRegistration.Models;
using userregistrationApp.Areas.Licensee.Models.LicenseeApplication;
using userregistrationApp.Areas.VehicleOwner.Models.VehicleRegistration;
using userregistrationApp.Areas.VehicleOwner.Models.Vehicles;
using userregistrationApp.Areas.WeightBridge.Models;
using userregistrationApp.ExceptionHandlear;
using userregistrationApp.Helper;
using userregistrationApp.Model.ExceptionList;
using userregistrationApp.Models.MailService;
using userregistrationApp.Models.PaymentResponses;
using userregistrationApp.Models.SBIEncryptDecryptKey;
using userregistrationApp.Models.SMSService;
using userregistrationApp.Models.Utility;
using userregistrationApp.Models.WebsiteMenu;
using userregistrationApp.Services;
using userregistrationEF;

namespace userregistrationApp
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
                    builder.WithOrigins("*").AllowAnyHeader().WithMethods("GET", "POST");
                });

            });

            #region Use For Cookie
            services.AddDataProtection().PersistKeysToFileSystem(new DirectoryInfo(Configuration.GetSection("KeyList:RingPaths").Value))
         .SetApplicationName("SharedCookieApp");

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => false;
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
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(20);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            services.AddDistributedMemoryCache();
            services.Configure<KeyList>(Configuration.GetSection("KeyList"));

            services.AddTransient<IExceptionProvider, ExceptionProvider>();
            services.AddTransient<IVehicleRegistrationModel, VehicleRegistrationModel>();
            services.AddTransient<IVehicleModel, VehicleModel>();
            services.AddTransient<ILicenseeApplicationModel, LicenseeApplicationModel>();
            services.AddTransient<IEndUserRegModel, EndUserRegModel>();
            services.AddTransient<IHttpWebClients, HttpWebClients>();
            services.AddTransient<IWebsiteMenuModel,WebsiteMenuModel>();
            services.AddTransient<IMailModel, MailModel>();
            services.AddTransient<ISMSModel,SMSModel>();
            services.AddTransient<IPaymentResponseModel,PaymentResponseModel>();
            services.AddTransient<IsbiIncriptDecript,sbiIncriptDecript>();
            services.AddTransient<IVTDVendor, VTDVendor>();
            services.AddScoped<IContractorBuilder,ContractorBuilder>();
            services.AddScoped<ITailingDamModel,TailingDamModel>();
            services.AddTransient<IAreaType, AreaType>();
            services.AddTransient<IWeighbridgeMake, WeighBridgeMake>();
            services.AddTransient<IWeighBridgeModelType, WeighBridgeModelType>();
            services.AddTransient<IWeighBridge, WeighBridge>();
            services.AddTransient<IWeighBridgeTag, WeighBridgeTag>();
            services.AddScoped<ICommonRailwaySidingModel, userregistrationApp.Areas.CommonRailwaySiding.Models.CommonRailwaySidingModel>(); 
            services.AddTransient<userregistrationApp.Areas.EndUserProfile.Models.IEndUserModel, userregistrationApp.Areas.EndUserProfile.Models.EndUserModel>();
            services.AddScoped<ISandStoneModel,SandStoneModel>();
            services.AddSingleton<Microsoft.AspNetCore.Http.IHttpContextAccessor, Microsoft.AspNetCore.Http.HttpContextAccessor>();
            services.AddMvc(
                config =>
                {
                   // config.Filters.Add(typeof(ExceptionFilterHandlear));
                    config.Filters.Add(typeof(SessionActionFilter)); 
                }
                ).AddNewtonsoftJson()
                .SetCompatibilityVersion(CompatibilityVersion.Latest)
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
            #region bilingual
            services.AddSingleton<CommonLocalizationService>();
            services.AddLocalization(options => options.ResourcesPath = "Resources");
            services.AddMvc()
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization();
            services.Configure<RequestLocalizationOptions>(
                opt =>
                {
                    var supportedCultures = new List<CultureInfo>
                    {
                        new CultureInfo("en"),
                        new CultureInfo("hi")
                    };
                    opt.DefaultRequestCulture = new RequestCulture("en");
                    opt.SupportedCultures = supportedCultures;
                    opt.SupportedUICultures = supportedCultures;
                });

            #endregion
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
               // app.UseHsts();
            }
            app.UseRouting();
            CustomQueryStringHelper.CustomQueryStringHelperEncryptPath(app.ApplicationServices.GetService<IOptions<KeyList>>());

            #region bilingual 
            app.UseRequestLocalization(app.ApplicationServices.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value);
            #endregion	
            app.UseSession();
            ///app.UseHttpsRedirection();
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
                   pattern: "{controller=Test}/{action=Index}/{id?}");


            });

        }
    }
}

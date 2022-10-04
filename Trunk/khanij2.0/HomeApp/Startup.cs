using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeApp.Models.Login;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using HomeApp.Web;
using HomeApp.ExceptionHandlear;
using HomeApp.Model.ExceptionList;
using Microsoft.AspNetCore.Authentication.Cookies;
using HomeEF;
using Microsoft.AspNetCore.DataProtection;
using System.IO;
using Microsoft.Extensions.Options;
using HomeApp.Models.Utility;
using System.Security.Principal;
using HomeApp.Models.Notification;
using HomeApp.Areas.Website.Models.Tender;
using HomeApp.Areas.Website.Models.NotificationType;
using HomeApp.Areas.Website.Models.StaffDirectory;
using HomeApp.Areas.Website.Models.Banner;
using HomeApp.Areas.Website.Models.Testimonial;
using HomeApp.Areas.Website.Models.Gallery;
using HomeApp.Areas.Website.Models.GlobalLink;
using HomeApp.Areas.Website.Models.UserProfile;
using HomeApp.Areas.Website.Models.Feedback;
using HomeApp.Areas.Website.Models.Page;
using HomeApp.Areas.Website.Models.PrimaryLink;
using HomeApp.Models.ForgotPasswordApp;
using HomeApp.Models.DashboardSub;
using System.Globalization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Localization;
using HomeApp.Services;
using HomeApp.Areas.Website.Models.Qbuilder;
using Microsoft.Extensions.DependencyInjection.Extensions;
using HomeApp.ActionFilter;
using HomeApp.Models.ChangePassword;
using HomeApp.Areas.Website.Models.Graph;
using HomeApp.Areas.Website.Models.FinancialYear;
using HomeApp.Areas.Website.Models.Notice;
using HomeApp.Areas.Website.Models.MineralMap;

namespace HomeApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

        }

        public IConfiguration Configuration { get; }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

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
            //services.AddDataProtection();
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

            services.AddDistributedMemoryCache();
            services.AddScoped<ILoginModel, HomeApp.Models.Login.LoginModel>();
            services.AddScoped<IForgotPwdModel, ForgotPwdModel>();
            services.AddScoped<IExceptionProvider, ExceptionProvider>();
            services.AddScoped<IHttpWebClients, HttpWebClients>();
            services.AddScoped<IDashboardSubModel, DashboardSubModel>();
            #region Website module
            services.AddScoped<INotificationModel, NotificationModel>();
            services.AddScoped<ITenderModel, TenderModel>();
            services.AddScoped<INotificationTypeModel, NotificationTypeModel>();
            services.AddScoped<IStaffDirectoryModel, StaffDirectoryModel>();
            services.AddScoped<IBannerModel, BannerModel>();
            services.AddScoped<ITestimonialModel, TestimonialModel>();
            services.AddScoped<IGalleryModel, GalleryModel>();
            services.AddScoped<IGlobalLinkModel, GlobalLinkModel>();
            services.AddScoped<IUserProfileModel, UserProfileModel>();
            services.AddScoped<IFeedbackModel, FeedbackModel>();
            services.AddScoped<IPageModel, PageModel>();
            services.AddScoped<IPrimaryLinkModel, PrimaryLinkModel>();
            services.AddScoped<IQbuilderModel, QbuilderModel>();
            services.AddScoped<IRevenue, Revenue>();
            services.AddScoped<IProduction, Production>();
            services.AddScoped<IResources, Resources>();
            services.AddScoped<IMineral, Mineral>();
            services.AddScoped<IFinancialYearModel, FinancialYearModel>();
            services.AddScoped<INoticeModel, NoticeModel>();
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IMineralMapModel, MineralMapModel>();
            #endregion
            services.AddScoped<IChangePasswordModel, ChangePasswordModel>();
            services.AddControllersWithViews();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(20);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            services.AddMvc().AddSessionStateTempDataProvider();
            services.AddMvc(
                config =>
                {
                    config.Filters.Add(typeof(ExceptionFilterHandlear));
                    config.Filters.Add(typeof(SessionActionFilter));
                }
                ).AddNewtonsoftJson()
               .SetCompatibilityVersion(CompatibilityVersion.Latest)
               .AddJsonOptions(options =>
               {
                   options.JsonSerializerOptions.IgnoreNullValues = true;
                   options.JsonSerializerOptions.WriteIndented = true;
               });
            services.AddRazorPages();

            services.Configure<KeyList>(Configuration.GetSection("KeyList"));

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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                //app.UseHsts();
            }
            CustomQueryStringHelper.CustomQueryStringHelperEncryptPath(app.ApplicationServices.GetService<IOptions<KeyList>>());
            app.UseRouting();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            #region bilingual
            app.UseRequestLocalization(app.ApplicationServices.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value);
            #endregion
            app.UseSession();
            //app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            //app.UseIdentity();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });

            app.UseEndpoints(routes =>
            {
                routes.MapControllerRoute(
                   name: "default",
                   pattern: "{area=Website}/{controller=Website}/{action=Home}/{id?}");

                //routes.MapControllerRoute(
                //     name: "default1",
                //     pattern: "{controller=Home}/{action=Index}/{id?}");



                //routes.MapControllerRoute(
                //     name: "ssss",
                //     pattern: "/{controller=Home}/{action=Index}/{id?}");
                //routes.MapAreaControllerRoute(
                //     name: "default",
                //      areaName: "Website",
                //     pattern: "Website/{controller=Website}/{action=Home}/{id?}");


            });
        }
    }
}
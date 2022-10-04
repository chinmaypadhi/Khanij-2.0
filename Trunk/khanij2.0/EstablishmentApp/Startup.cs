using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EstablishmentApp.Areas.Aec.Models.AppraisalClassIV;
using EstablishmentApp.Areas.Aec.Models.AppraisalDriver;
using EstablishmentApp.Areas.Aec.Models.ClassIIIAppraisal;
using EstablishmentApp.Areas.Aec.Models.PastaffAppraisal;
using EstablishmentApp.Areas.Aec.Models.SelfAppraisal;
using EstablishmentApp.Areas.EmpPro.Models;
using EstablishmentApp.Areas.EmpPro.Models.EmpProfile;
using EstablishmentApp.Areas.EmpPro.Models.Section;
using EstablishmentApp.ExceptionHandlear;
using EstablishmentApp.Model.ExceptionList;
using EstablishmentApp.Models.Utility;
using EstablishmentEf;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;

using EstablishmentApp.Areas.LeaveManagement.Models.LeaveManagement;
using EstablishmentApp.Areas.WorkFlow.Models.WorkFlow;

using System.Text;
using EstablishmentApp.ActionFilter;
using EstablishmentApp.Web;
using Microsoft.Extensions.Options;

namespace EstablishmentApp
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
            services.AddScoped<IHttpWebClients, HttpWebClients>();
            services.AddScoped<IExceptionProvider, ExceptionProvider>();
            services.AddScoped<IofficeLevelModul, OfficeLevelModul>();
            services.AddScoped<IEmpProfileModel, EmpProfileModel>();
            services.AddScoped<ISectionModel, SectionModel>();
            services.AddScoped<ISelfAppraisalModel, SelfAppraisalModel>();
            services.AddScoped<IClassIIIAppraisalModel, ClassIIIAppraisalModel>();
            services.AddScoped<IPAstaffApprasalModel, PAstaffApprasalModel>();
            services.AddScoped<IAppraisalDriverModel, AppraisalDriverModel>();
            services.AddScoped<IAppraisalClassIVModel, AppraisalClassIVModel>();

            services.AddScoped<ILeaveManagementModel, LeaveManagementModel>();
            services.AddScoped<ILeaveAssignClassWiseModel, LeaveAssignClassWiseModel>();
            services.AddScoped<ISectionModel, SectionModel>();
            services.AddScoped<IActivityModel, ActivityModel>();
            services.AddScoped<IWorkFlowModel, WorkFlowModel>();
            services.AddMvc(
                 config =>
                 {
                     config.Filters.Add(typeof(ExceptionFilterHandlear));
                     config.Filters.Add(typeof(SessionActionFilter));
                 }
                ).SetCompatibilityVersion(CompatibilityVersion.Latest);
            services.Configure<KeyList>(Configuration.GetSection("KeyList"));



            //services.AddMvc();
            //.AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());

            //-----security-----
            services.AddSingleton<KhanijSecurity.UniqueCode>();
            services.AddSingleton<KhanijSecurity.KhanijIDataProtection>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddMvc().AddSessionStateTempDataProvider();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public  void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
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

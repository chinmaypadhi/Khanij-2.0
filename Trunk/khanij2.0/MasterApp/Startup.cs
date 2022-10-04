using System;
using MasterApp.Areas.Master.Models.CriticalityMasters;
using MasterApp.Areas.Master.Models.Department;
using MasterApp.Areas.Master.Models.Designation;
using MasterApp.Areas.Master.Models.District;
using MasterApp.Areas.Master.Models.Division;
using MasterApp.Areas.Master.Models.MineralForm;
using MasterApp.Areas.Master.Models.MineralGrade;
using MasterApp.Areas.Master.Models.MineralSchedule;
using MasterApp.Areas.Master.Models.MineralSchedulePart;
using MasterApp.Areas.Master.Models.Railway;
using MasterApp.Areas.Master.Models.RailwayZone;
using MasterApp.Areas.Master.Models.Royalty;
using MasterApp.Areas.Master.Models.StateMaster;
using MasterApp.Areas.Master.Models.Tehsil;
using MasterApp.Areas.Master.Models.Village;
using MasterApp.ExceptionHandlear;
using MasterApp.Model.ExceptionList;
using MasterApp.Models.MIneral;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MasterApp.Areas.Master.Models.Priority;
using MasterApp.Areas.Master.Models.Route;
using MasterApp.Areas.Master.Models.Checkpost;
using MasterApp.Areas.Master.Models.WeighBridge;
using MasterApp.Areas.Master.Models.Policy;
using MasterApp.Areas.Master.Models.UserFeedback;
using MasterApp.Areas.Master.Models.Transparncy;
using MasterApp.Areas.Master.Models.Mineral;
using MasterApp.Areas.Master.Models.OSU;
using MasterApp.Areas.Master.Models.ApplicationSetting;
using MasterApp.Areas.Master.Models.Menu;
using MasterApp.Areas.Master.Models.ChangeStatus;
using MasterApp.Areas.Master.Models.RoyaltyForward;
using MasterApp.Areas.Master.Models.RoyaltyMapping;
using MasterApp.Areas.Master.Models.PaymentHead;
using Microsoft.AspNetCore.DataProtection;
using System.IO;
using MasterApp.ActionFilter;
using MasterEF;
using MasterApp.Areas.LesseeProfile.Models.LesseeDetails;
using MasterApp.Areas.LesseeProfile.Models.OfficeDetails;
using MasterApp.Areas.LesseeProfile.Models.GrantOrderDetails;
using MasterApp.Areas.LesseeProfile.Models.LeaseAreaDetails;
using MasterApp.Areas.LesseeProfile.Models.MineralInformation;
using MasterApp.Areas.LesseeProfile.Models.IBMDetails;
using MasterApp.Areas.LesseeProfile.Models.ForestClearanceDetails;
using MasterApp.Areas.LesseeProfile.Models.CTEDetails;
using MasterApp.Areas.LesseeProfile.Models.AssessmentReportDetails;
using MasterApp.Areas.LesseeProfile.Models.CTODetails;
using MasterApp.Areas.LesseeProfile.Models.EnvironmentClearanceDetails;
using MasterApp.Areas.LesseeProfile.Models.LesseeMiningPlan;
using MasterApp.Factory;
using MasterApp.Areas.Licensee.Models;
using MasterApp.Areas.DMO.Models;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MasterApp.Areas.Master.Models.PaymentTypeMaster;
using MasterApp.Areas.Master.Models.MineralUnit;
using MasterApp.Areas.Master.Models.AccessPermission;
using MasterApp.Areas.Master.Models.LeaseType;
using MasterApp.Areas.Master.Models.LicenseeType;
using MasterApp.Areas.Master.Models.TransportationMode;
using MasterApp.Areas.Master.Models.NoticeMaster;
using MasterApp.Models.Company;
using MasterApp.Areas.Master.Models.Rule;
using MasterApp.Models.Utility;
using MasterApp.Areas.Master.Models.Checklist;
using MasterApp.Areas.Master.Models.Block;
using MasterApp.Areas.Master.Models.Usertype;
using MasterApp.Areas.Master.Models.Country;
using MasterApp.Areas.Master.Models.MineralSize;
using MasterApp.Areas.Master.Models.Module;
using MasterApp.Areas.Master.Models.MainMenu;
using MasterApp.Areas.LesseeProfile.Models.Profile;
using MasterApp.Web;
using Microsoft.Extensions.Options;
using MasterApp.Areas.WorkFlowEngine.Models.WorkFlow;

namespace MasterApp
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
                options.IdleTimeout = TimeSpan.FromMinutes(20);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            services.AddDistributedMemoryCache();
            services.Configure<KeyList>(Configuration.GetSection("KeyList"));
            services.AddScoped<IHttpWebClients, HttpWebClients>();
            services.AddScoped<IAccessPermission, AccessPermission>();
            services.AddScoped<IMIneralModel, MIneralModel>();
            services.AddScoped<IStateMasterModel, StateMasterModel>();
            services.AddScoped<ICriticalityMasterModel, CriticalityMasterModel>();
            services.AddScoped<IDesignationModel, DesignationModel>();
            services.AddScoped<IMineralGradeMasterModel, MineralGradeMasterModel>();
            services.AddScoped<IDepartmentMasterModel, DepartmentMasterModel>();
            services.AddScoped<IMineralFormModel, MineralFormModel>();
            services.AddScoped<IExceptionProvider, ExceptionProvider>();
            services.AddScoped<IDivisionMasterModel, DivisionMasterModel>();
            services.AddScoped<IDistrictMasterModel, DistrictMasterModel>();
            services.AddScoped<ITehsilMasterModel, TehsilMasterModel>();
            services.AddScoped<IVillageMaster, VillageMaster>();
            services.AddScoped<IMineralScheduleMasterModel, MineralScheduleMasterModel>();
            services.AddScoped<IMineralSchedulePartMasterModel, MineralSchedulePartMasterModel>();
            services.AddScoped<IRailwayZoneMasterModel, RailwayZoneMasterModel>();
            services.AddScoped<IRailwayMasterModel, RailwayMasterModel>();
            services.AddScoped<IRoyaltyMasterModel, RoyaltyMasterModel>();
            services.AddScoped<IMIneralModel, MIneralModel>();
            services.AddScoped<IStateMasterModel, StateMasterModel>();
            services.AddScoped<IPriorityModel, PriorityModel>();
            services.AddScoped<IPaymentTypeMasterModel, PaymentTypeMasterModel>();
            services.AddScoped<IMineralUnitModel, MineralUnitModel>();
            services.AddScoped<IRouteModel, RouteModel>();
            services.AddScoped<ICheckPostModel, CheckPostModel>();
            services.AddScoped<IWeighBridgeModel, WeighBridgeModel>();
            services.AddScoped<IPolicyModel, PolicyModel>();
            services.AddScoped<IUserFeedbackModel, UserFeedbackModel>();
            services.AddScoped<IExceptionProvider, ExceptionProvider>();
            services.AddScoped<ITransparncyModel, TransparncyModel>();
            services.AddScoped<IOtherMineralModel, OtherMineralModel>();
            services.AddScoped<IOSUModel, OSUModel>();
            services.AddScoped<IApplicationSettingModel, ApplicationSettingModel>();
            services.AddScoped<IMenuModel, MenuModel>();
            services.AddScoped<IChangeStatusModel, ChangeStatusModel>();
            services.AddScoped<IRoyaltyForwardModel, RoyaltyForwardModel>();
            services.AddScoped<IRoyaltyMasterModel, RoyaltyMasterModel>();
            services.AddScoped<IMineralGradeMasterModel, MineralGradeMasterModel>();
            services.AddScoped<IMineralScheduleMasterModel, MineralScheduleMasterModel>();
            services.AddScoped<IMineralSchedulePartMasterModel, MineralSchedulePartMasterModel>();
            services.AddScoped<IMineralFormModel, MineralFormModel>();
            services.AddScoped<IRoyaltyMappingModel, RoyaltyMappingModel>();
            services.AddScoped<IRoyaltyMasterModel, RoyaltyMasterModel>();
            services.AddScoped<IMineralMasterModel, MineralMasterModel>();
            services.AddScoped<ISinglePaymentHeadMasterModel, SinglePaymentHeadMasterModel>();
            services.AddScoped<IExceptionProvider, ExceptionProvider>();
            services.AddScoped<IUserInformationLicenseeModel, UserInformationLicenseeModel>();
            services.AddScoped<IUserInformationLicenseeAothorityModel, UserInformationLicenseeAothorityModel>();
            services.AddScoped<ILeaseTypeModel, LeaseTypeModel>();
            services.AddScoped<ILicenseeTypeModel, LicenseeTypeModel>();
            services.AddScoped<ITransportationModeModel, TransportationModeModel>();
            services.AddScoped<INoticeMasterModel, NoticeMasterModel>();
            services.AddScoped<ICompanyModel, CompanyModel>();
            services.AddScoped<IRuleMasterModel, RuleMasterModel>();
            services.AddScoped<IChecklistModel, ChecklistModel>();
            services.AddScoped<IBlockModel, BlockModel>();
            services.AddScoped<IUsertypeModel, UsertypeModel>();
            services.AddScoped<ICountryMasterModel, CountryMasterModel>();
            services.AddScoped<IMineralSizeMasterModel, MineralSizeMasterModel>();
            services.AddScoped<IModuleModel, ModuleModel>();
            services.AddScoped<IMainMenuMasterModel, MainMenuMasterModel>();
            services.AddScoped<IWorkFlowModel, WorkFlowModel>();
            services.AddScoped<IActivityModel, ActivityModel>();

            #region LesseeProfile
            services.AddScoped<ILesseeDetailsModel, LesseeDetailsModel>();
            services.AddScoped<ILesseeOfficeMasterModel, LesseeOfficeMasterModel>();
            services.AddScoped<ILesseeGrantOrderModel, LesseeGrantOrderModel>();
            services.AddScoped<ILesseeLeaseAreaModel, LesseeLeaseAreaModel>();
            services.AddScoped<IMineralInformationModel, MineralInformationModel>();
            services.AddScoped<ILesseeIBMModelDetails, LesseeIBMModelDetails>();
            services.AddScoped<ILesseeForestClearanceModel, LesseeForestClearanceModel>();
            services.AddScoped<ILesseeCTEModel, LesseeCTEModel>();
            services.AddScoped<ILesseeAssessmentReportModel, LesseeAssessmentReportModel>();
            services.AddScoped<ILesseeCTOModel, LesseeCTOModel>();
            services.AddScoped<ILesseEnvironmentClearanceModel, LesseEnvironmentClearanceModel>();
            services.AddScoped<ILesseeMiningPlanModel, LesseeMiningPlanModel>();
            services.AddScoped<IProfileModel, ProfileModel>();
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            IConnectionFactory connectionFactory = new ConnectionFactory(Configuration.GetConnectionString("CIMSConnectionString"));
            services.AddSingleton(connectionFactory);
            services.AddMvc().AddSessionStateTempDataProvider();
            #endregion
            services.AddSingleton(connectionFactory);
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
                //routes.MapControllerRoute("areaRoute", "{area}/{controller}/{action}/{id?}");
            });

        }
    }
}

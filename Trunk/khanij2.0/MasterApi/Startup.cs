using MasterApi.AuthenticationHandler;
using MasterApi.ExceptionHandlear;
using MasterApi.Factory;
using MasterApi.Model.AccessPermission;
using MasterApi.Model.ApplicationSetting;
using MasterApi.Model.Block;
using MasterApi.Model.ChangeStatus;
using MasterApi.Model.Checklist;
using MasterApi.Model.Checkpost;
using MasterApi.Model.Company;
using MasterApi.Model.Country;
using MasterApi.Model.CriticalityMasters;
using MasterApi.Model.Department;
using MasterApi.Model.Designation;
using MasterApi.Model.District;
using MasterApi.Model.Division;
using MasterApi.Model.ExceptionList;
using MasterApi.Model.LeaseType;
using MasterApi.Model.LesseeAssessmentReport;
using MasterApi.Model.LesseeCTE;
using MasterApi.Model.LesseeCTO;
using MasterApi.Model.LesseeDetails;
using MasterApi.Model.LesseeEnvironmentClearance;
using MasterApi.Model.LesseeForestClearance;
using MasterApi.Model.LesseeGrantOrder;
using MasterApi.Model.LesseeIBM;
using MasterApi.Model.LesseeLeaseArea;
using MasterApi.Model.LesseeMineralInformation;
using MasterApi.Model.LesseeMiningPlan;
using MasterApi.Model.LesseeOfficeMaster;
using MasterApi.Model.LicenseeType;
using MasterApi.Model.Menu;
using MasterApi.Model.Mineral;
using MasterApi.Model.MineralForm;
using MasterApi.Model.MineralGrade;
using MasterApi.Model.MineralName;
using MasterApi.Model.MineralSchedule;
using MasterApi.Model.MineralSchedulePart;
using MasterApi.Model.MineralSize;
using MasterApi.Model.MineralUnit;
using MasterApi.Model.NoticeMaster;
using MasterApi.Model.OSU;
using MasterApi.Model.PaymentHead;
using MasterApi.Model.PaymentTypeMaster;
using MasterApi.Model.Policy;
using MasterApi.Model.PriorityMaster;
using MasterApi.Model.Railway;
using MasterApi.Model.RailwayZone;
using MasterApi.Model.Route;
using MasterApi.Model.Royalty;
using MasterApi.Model.RoyaltyForward;
using MasterApi.Model.RoyaltyMapping;
using MasterApi.Model.Rule;
using MasterApi.Model.StateMaster;
using MasterApi.Model.Tehsil;
using MasterApi.Model.Transparncy;
using MasterApi.Model.TransportationMode;
using MasterApi.Model.UserFeedback;
using MasterApi.Model.UserInformation;
using MasterApi.Model.Usertype;
using MasterApi.Model.Village;
using MasterApi.Model.WeighBridge;
using MasterApi.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Text;
using MasterApi.Model.Module;
using MasterApi.Model.MainMenu;
using MasterApi.Model.UserInformationLicensee;
using MasterApi.Model.Profile;
using MasterApi.Model.WorkFlow;

namespace MasterApi
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
            services.AddMvc(
                config =>
                {
                    config.Filters.Add(typeof(ExceptionFilterHandlear));
                }

                           ).AddNewtonsoftJson()
                .SetCompatibilityVersion(CompatibilityVersion.Latest)
              .AddJsonOptions(options =>
              {
                  options.JsonSerializerOptions.IgnoreNullValues = true;
                  options.JsonSerializerOptions.WriteIndented = true;
              });
            #region commented on 26.11.2021 for using jwt
            //// configure basic authentication 
            //services.AddAuthentication("BasicAuthentication")
            //    .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);
            #endregion
            #region added on 26.11.2021 for using jwt
            var audienceConfig = Configuration.GetSection("Audience");
            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(audienceConfig["Secret"]));
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = signingKey,
                ValidateIssuer = true,
                ValidIssuer = audienceConfig["Iss"],
                ValidateAudience = true,
                ValidAudience = audienceConfig["Aud"],
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero,
                RequireExpirationTime = true,
            };

            services.AddAuthentication(o =>
            {
                o.DefaultAuthenticateScheme = "TestKey";
            })
            .AddJwtBearer("TestKey", x =>
            {
                x.RequireHttpsMetadata = false;
                x.TokenValidationParameters = tokenValidationParameters;
            });
            #endregion

            // configure DI for application services
            services.AddScoped<IAccessPermission, AccessPermission>();
            services.AddScoped<IExceptionProvider, ExceptionProvider>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IMineralProvider, MineralProvider>();
            services.AddScoped<IStateMasterProvider, StateMasterProvider>();
            services.AddScoped<ICriticalityMasterProvider, CriticalMasterProvider>();
            services.AddScoped<IDesignationProvider, DesignationProvider>();
            services.AddScoped<IMineralGradeProvider, MineralGradeProvider>();
            services.AddScoped<IDepartmentProvider, DepartmentProvider>();
            services.AddScoped<IMineralFormProvider, MineralFormProvider>();
            services.AddScoped<IDivisionProvider, DivisionProvider>();
            services.AddScoped<IDistrictProvider, DistrictProvider>();
            services.AddScoped<ITehsilProvider, TehsilProvider>();
            services.AddScoped<IVillageProvider, VillageProvider>();
            services.AddScoped<IMineralScheduleProvider, MineralScheduleProvider>();
            services.AddScoped<IMineralSchedulePartProvider, MineralSchedulePartProvider>();
            services.AddScoped<IRailwayZoneProvider, RailwayZoneProvider>();
            services.AddScoped<IRailwayProvider, RailwayProvider>();
            services.AddScoped<IRoyaltyProvider, RoyaltyProvider>();
            services.AddScoped<IExceptionProvider, ExceptionProvider>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IMineralProvider, MineralProvider>();
            services.AddScoped<IStateMasterProvider, StateMasterProvider>();
            services.AddScoped<IPriorityProvider, PriorityProvider>();
            services.AddScoped<IPaymentTypeMasterProvider, PaymentTypeMasterProvider>();
            services.AddScoped<IMineralUnitProvider, MineralUnitProvider>();
            services.AddScoped<ICheckPostProvider, CheckPostProvider>();
            services.AddScoped<IRouteProvider, RouteProvider>();
            services.AddScoped<IWeighBridgeProvider, WeighBridgeProvider>();
            services.AddScoped<IPolicyProvider, PolicyProvider>();
            services.AddScoped<IUserFeedbackProvider, UserFeedbackProvider>();
            services.AddScoped<ITransparncyProvider, TransparncyProvider>();
            services.AddScoped<IOSUProvider, OSUProvider>();
            services.AddScoped<IApplicationSettingProvider, ApplicationSettingProvider>();
            services.AddScoped<IMenuProvider, MenuProvider>();
            services.AddScoped<IChangeStatusProvider, ChangeStatusProvider>();
            services.AddScoped<IRoyaltyForwardProvider, RoyaltyForwardProvider>();
            services.AddScoped<IRoyaltyProvider, RoyaltyProvider>();
            services.AddScoped<IMineralGradeProvider, MineralGradeProvider>();
            services.AddScoped<IMineralScheduleProvider, MineralScheduleProvider>();
            services.AddScoped<IMineralSchedulePartProvider, MineralSchedulePartProvider>();
            services.AddScoped<IMineralFormProvider, MineralFormProvider>();
            services.AddScoped<IRoyaltyMappingProvider, RoyaltyMappingProvider>();
            services.AddScoped<IRoyaltyProvider, RoyaltyProvider>();
            services.AddScoped<IMineralNameProvider, MineralNameProvider>();
            services.AddScoped<ISinglePaymentHeadProvider, SinglePaymentHeadProvider>();
            services.AddScoped<ILeaseTypeProvider, LeaseTypeProvider>();
            services.AddScoped<IRuleMasterProvider, RuleMasterProvider>();
            services.AddScoped<INoticeMasterProvider, NoticeMasterProvider>();
            services.AddScoped<ILicenseeTypeProvider, LicenseeTypeProvider>();
            services.AddScoped<ICompanyProvider, CompanyProvider>();
            services.AddScoped<IChecklistProvider, ChecklistProvider>();
            services.AddScoped<IBlockProvider, BlockProvider>();
            services.AddScoped<IUsertypeProvider, UsertypeProvider>();
            services.AddScoped<ITransportationModeProvider, TransportationModeProvider>();
            services.AddScoped<IUserInformationProvider, UserInformationProvider>();
            services.AddScoped<IUserInformationLicenseeProvider, UserInformationLicenseeProvider>();
            services.AddScoped<ICountryProvider, CountryProvider>();
            services.AddScoped<IMineralSizeProvider, MineralSizeProvider>();
            services.AddScoped<IModuleProvider, ModuleProvider>();
            services.AddScoped<IMainMenuProvider, MainMenuProvider>();
            #region LesseeProfile
            services.AddScoped<ILesseeDetailsProvider, LesseeDetailsProvider>();
            services.AddScoped<ILesseeOfficeMasterProvider, LesseeOfficeMasterProvider>();
            services.AddScoped<ILesseeGrantOrderProvider, LesseeGrantOrderProvider>();
            services.AddScoped<ILesseeLeaseAreaProvider, LesseeLeaseAreaProvider>();
            services.AddScoped<ILesseeMineralInformationProvider, LesseeMineralInformationProvider>();
            services.AddScoped<ILesseeIBMProvider, LesseeIBMProvider>();
            services.AddScoped<ILesseeForestClearanceProvider, LesseeForestClearanceProvider>();
            services.AddScoped<ILesseeCTEProvider, LesseeCTEProvider>();
            services.AddScoped<ILesseeAssessmentReportProvider, LesseeAssessmentReportProvider>();
            services.AddScoped<ILesseeCTOProvider, LesseeCTOProvider>();
            services.AddScoped<ILesseeEnvironmentClearanceProvider, LesseeEnvironmentClearanceProvider>();
            services.AddScoped<ILesseeMiningPlanProvider, LesseeMiningPlanProvider>();
            services.AddScoped<IProfileProvider, ProfileProvider>();
            #endregion

            #region workflow
            services.AddScoped<IWorkFlow, WorkFlow>();
            services.AddScoped<IActivity, Activity>();
            #endregion
            IConnectionFactory connectionFactory = new ConnectionFactory(Configuration.GetConnectionString("CIMSConnectionString"));
            services.AddSingleton(connectionFactory);
            services.AddRouting();

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" }); });
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            //app.UseHttpsRedirection();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

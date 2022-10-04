using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MasterApi.Factory;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using userregistrationEFApi.AuthenticationHandler;
using userregistrationEFApi.ExceptionHandlear;
using userregistrationEFApi.Model.CommonRailwaySiding;
using userregistrationEFApi.Model.ContractorBuilder;
using userregistrationEFApi.Model.EndUser;
using userregistrationEFApi.Model.EndUserProfile;
using userregistrationEFApi.Model.ExceptionList;
using userregistrationEFApi.Model.Licensee;
using userregistrationEFApi.Model.PaymentResponse;
using userregistrationEFApi.Model.SandStoneRegd;
using userregistrationEFApi.Model.TailingDam;
using userregistrationEFApi.Model.Vhicle;
using userregistrationEFApi.Model.VTDVendor;
using userregistrationEFApi.Model.WeighBridge;
using userregistrationEFApi.Services;
using userregistrationEFApi.Utility;
using userregistrationEFApi.Utility.MailService;
using userregistrationEFApi.Utility.SMSService;

namespace userregistrationEFApi
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

            // configure basic authentication 
            //services.AddAuthentication("BasicAuthentication")
            //    .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);
            #region Jwt Authentication
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
            //added by shyam sir

            //services.AddAuthentication(options =>
            //{
            //    //options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //})
            //   .AddJwtBearer(jwtBearerOptions =>
            //   {
            //       jwtBearerOptions.RequireHttpsMetadata = true;
            //       jwtBearerOptions.SaveToken = true;
            //       jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters
            //       {
            //           ValidateIssuerSigningKey = true,
            //           IssuerSigningKey = signingKey,
            //           ValidateIssuer = false,
            //           ValidateAudience = false,
            //           ClockSkew = TimeSpan.Zero
            //       };
            //   });
            //added by shyam sir
            #endregion
            // configure DI for application services
            services.AddTransient<IExceptionProvider, ExceptionProvider>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IVehicleRegistrationProvider,VehicleRegistrationProvider>();
            services.AddTransient<IVehicleProvider, VehicleProvider>();
            services.AddTransient<ILicenseeApplicationProvider, LicenseeApplicationProvider>();
            services.AddTransient<IHttpWebClients, HttpWebClients>();
            services.AddTransient<IEndUserRegProvider, EndUserRegProvider>();
            services.AddTransient<IMailServiceProvider,MailServiceProvider>();
            services.AddTransient<ISMSServiceProvider,SMSServiceProvider>();
            services.AddTransient<IPaymentResponseProvider,PaymentResponseProvider>();
            services.AddTransient<IVTDVendorProvider,VTDVendorProvider>();
            services.AddTransient<IContractorBuilderProvider,ContractorBuilderProvider>();
            services.AddTransient<ITailingDamProvider,TailingDamProvider>();
            services.AddTransient<IAreaTypeProvider, AreaTypeProvider>();
            services.AddTransient<IWeighBridgeMakeProvider, WeighBridgeMakeProvider>();
            services.AddTransient<IWeighBrideModelTypeProvider, WeighBridgeModelTypeProvider>();
            services.AddTransient<IWBRegisterProvider, WBRegistrationProvider>();
            services.AddTransient<IWeighBridgeTagProvider, WeighBridgeTagProvider>();
            services.AddTransient<IEndUserProfileProvider,EndUserProfileProvider>();
            services.AddTransient<ICommonRailwaySidingProvider, CommonRailwaySidingProvider>();
            services.AddTransient<ISandStoneProvider,SandStoneProvider>();
            IConnectionFactory connectionFactory = new ConnectionFactory(Configuration.GetConnectionString("CIMSConnectionString"));
            services.AddSingleton(connectionFactory);
           
            services.AddRouting(); 
            services.AddMvc( 
                config => 
                { 
                    config.Filters.Add(typeof(ExceptionFilterHandlear)); 
                }).AddNewtonsoftJson()
                .SetCompatibilityVersion(CompatibilityVersion.Latest)
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.IgnoreNullValues = true;
                    options.JsonSerializerOptions.WriteIndented = true;
                });

            services.Configure<FormOptions>(options =>
            {
                options.ValueLengthLimit = int.MaxValue;
                options.MultipartBodyLengthLimit = long.MaxValue; // <-- ! long.MaxValue
                options.MultipartBoundaryLengthLimit = int.MaxValue;
                options.MultipartHeadersCountLimit = int.MaxValue;
                options.MultipartHeadersLengthLimit = int.MaxValue;
            });
            // services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //app.UseSwagger();
            //app.UseSwaggerUI(c => {
            //    c.SwaggerEndpoint("/swagger/v1/swagger.json", "User Registration2222 API V1");
            //});
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoitnts => 
            { 
                endpoitnts.MapControllers();

            });
        }
    }
}

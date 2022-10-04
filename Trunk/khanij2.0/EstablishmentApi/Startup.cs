using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstablishmentApi.AuthenticationHandler;
using EstablishmentApi.ExceptionHandlear;
using EstablishmentApi.Factory;
using EstablishmentApi.Model.AppraisalDriver;
using EstablishmentApi.Model.ClassIIIAppraisal;
using EstablishmentApi.Model.EmpProfile;
using EstablishmentApi.Model.ExceptionList;
using EstablishmentApi.Model.officeLevel;
using EstablishmentApi.Model.PAStatffAppraisal;
using EstablishmentApi.Model.SelfeAprasial;
using EstablishmentApi.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

using EstablishmentApi.Model.LeaveManagement;
using EstablishmentApi.Model.AppraisalClassIV;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using EstablishmentApi.Model.Section;
using EstablishmentApi.Model.WorkFlow;

namespace EstablishmentApi
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
                ).SetCompatibilityVersion(CompatibilityVersion.Latest);
            // configure basic authentication 
            //services.AddAuthentication("BasicAuthentication")
            //    .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

            //JWT Token
            var audienceConfig = Configuration.GetSection("Audience");

            var signingKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(Encoding.ASCII.GetBytes(audienceConfig["Secret"]));
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

            //End jwt

            // configure DI for application services
            services.AddScoped<IExceptionProvider, ExceptionProvider>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IOfficeLevelProvider,OfficeLevelProvider>();
            services.AddScoped<IEmpProfile,EmpProfileModule>();
            services.AddScoped<IClassIIIAppraisalProvider,ClassIIIAppraisalProvider>();
            services.AddScoped<ISalfeAprasialProvider,SalfeAprasialProvider>();
            services.AddScoped<IPAStatffAppraisalProvider,PAStatffAppraisalProvider>();
            services.AddScoped<IAppraisalDriverProvider,AppraisalDriverProvider>();
            services.AddScoped<IAppraisalClassIVprovider, AppraisalClassIVprovider>();

            services.AddScoped<ILeaveManagement, LeaveManagement>();
            services.AddScoped<ILeaveAssignClassWise, LeaveAssignClassWise>();
            services.AddScoped<ISectionProvider, SectionProvider>();
            services.AddScoped<IActivity, Activity>();
            services.AddScoped<IWorkFlow, WorkFlow>();
            IConnectionFactory connectionFactory = new ConnectionFactory(Configuration.GetConnectionString("CIMSConnectionString"));
            services.AddSingleton(connectionFactory);
            services.AddRouting();

           


            // Register the Swagger generator, defining 1 or more Swagger documents
            //services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" }); });

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
          
            //app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

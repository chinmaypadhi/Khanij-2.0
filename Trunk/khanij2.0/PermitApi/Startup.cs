// ***********************************************************************
//  Class Name               : Startup
//  Desciption               : Startup
//  Created By               : sanjay kumar
//  Created On               : 28 Dec 2020
// ***********************************************************************
using PermitApi.AuthenticationHandler;
using PermitApi.ExceptionHandlear;
using PermitApi.Factory;
using PermitApi.Model.ExceptionList;
using PermitApi.Model.Permit;
using PermitApi.Model.CoalEPermit;
using PermitApi.Model.MergePermit;
using PermitApi.Model.Transit;
using PermitApi.Model.LTP;
using PermitApi.Model.ValidityExpired;
using PermitApi.Model.PaymentConfig;
using PermitApi.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Text;
using System;
using Microsoft.IdentityModel.Tokens;
using PermitApi.Model.ECCapping;
using PermitApi.Model.GradeUpdate;
using PermitApi.Model.DemandNote;
using PermitApi.Model.CoalGrade;

namespace PermitApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public IConfiguration Configuration { get; }
        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
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

                           ).AddNewtonsoftJson().SetCompatibilityVersion(CompatibilityVersion.Latest)
              .AddJsonOptions(options =>
              {
                  options.JsonSerializerOptions.IgnoreNullValues = true;
                  options.JsonSerializerOptions.WriteIndented = true;
              });
            #region commented on 28.10.2021 for using jwt
            //// configure basic authentication 
            //services.AddAuthentication("BasicAuthentication")
            //    .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);
            #endregion
            #region added on 28.10.2021 for using jwt
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
            services.AddScoped<IExceptionProvider, ExceptionProvider>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ILesseeProvider, LesseeProvider>();
            services.AddScoped<ICoalEPermitProvider, CoalEPermitProvider>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IMergePermitProvider, MergePermitProvider>();
            services.AddScoped<ITransitProvider, TransitProvider>();
            services.AddScoped<ILTPProvider, LTPProvider>();
            services.AddScoped<IValidityExpiredProvider, ValidityExpiredProvider>();
            services.AddScoped<IPaymentConfigProvider, PaymentConfigProvider>();
            services.AddScoped<IECCappingProvider, ECCappingProvider>();
            services.AddScoped<IUpgradeGrade, UpgradeGrade>();
            services.AddScoped<IDemandNoteProvider, DemandNoteProvider>();
            services.AddScoped<ICoalGradeProvider, CoalGradeProvider>();
            IConnectionFactory connectionFactory = new ConnectionFactory(Configuration.GetConnectionString("CIMSConnectionString"));
            services.AddSingleton(connectionFactory);
            services.AddRouting();
            services.AddControllers()
          .AddNewtonsoftJson(options =>
          {
              options.UseMemberCasing();
          });

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" }); });
        }
        /// <summary>
        ///  This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
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
            app.UseHttpsRedirection();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

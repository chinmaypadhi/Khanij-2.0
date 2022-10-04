using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EpassApi.AuthenticationHandler;
using EpassApi.ExceptionHandlear;
using EpassApi.Factory;
using EpassApi.Model.ExceptionList;
using EpassApi.Model.PurchaserConsignee;
using EpassApi.Services;
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
using EpassApi.Model.eTransitpass;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using EpassApi.Model.ePassConfiguration;
using EpassApi.Model.MineralReceive;
using EpassApi.Model.GeneratedRTPAPP;
using EpassApi.Model.eCancel;
using EpassApi.Model.AdminUtility;
using EpassApi.Model.CaseOfIrregularity;

namespace EpassApi
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
            //JWT Token
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
            //End

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
            // configure basic authentication 
            services.AddAuthentication("BasicAuthentication")
                .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

            // configure DI for application services
            services.AddScoped<IExceptionProvider, ExceptionProvider>();
            services.AddScoped<IUserService, UserService>();
            services.AddTransient<IPurchaserConsigneeProvider, PurchaserConsigneeProvider>();
            services.AddTransient<IeTransitpassprovider, eTransitpassprovider>();
            services.AddTransient<IePassConfigurationProvider, ePassConfigurationProvider>();
            services.AddTransient<IMineralReceiveProvider, MineralReceiveProvider>();
            services.AddTransient<IGeneratedRTPAPPProvider, GeneratedRTPAPPProvider>();
            services.AddTransient<ICaseOfIrregularityProvider, CaseOfIrregularityProvider>();
            //services.AddTransient<ICaseOfIrregularityProvider, CaseOfIrregularityProvider>();
            //Dinesh 27Apr22
            services.AddTransient<IeCancelProvider, eCancelProvider>();
            //Dinesh 29Apr22
            services.AddTransient<IAdminUtilityProvider, AdminUtilityProvider>();
            IConnectionFactory connectionFactory = new ConnectionFactory(Configuration.GetConnectionString("CIMSConnectionString"));
            services.AddSingleton(connectionFactory);
            services.AddRouting();

            // Register the Swagger generator, defining 1 or more Swagger documents            
            //services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" }); });
            services.AddSwaggerGen();
            

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Test Swagger API");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }      


            
            
            app.UseHttpsRedirection();
            app.UseCors("AllowAll");
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

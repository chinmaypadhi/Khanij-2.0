using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ReturnApi.AuthenticationHandler;
using ReturnApi.ExceptionHandlear;
using ReturnApi.Factory;
using ReturnApi.Model.DailyProduction;
using ReturnApi.Model.e_Return_NonCoal;
using ReturnApi.Model.e_Return_NonCoal_AnnualG1;
using ReturnApi.Model.eReturnCoalMonthly;
using ReturnApi.Model.eReturnCoalYearly;
using ReturnApi.Model.e_Return_NonCoal_AnnualG2;
using ReturnApi.Model.ExceptionList;
using ReturnApi.Services;

namespace ReturnApi
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
            //.AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);
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
            // configure DI for application services
            services.AddTransient<IExceptionProvider, ExceptionProvider>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IDailyProductionProvider, DaillyProductionProvider>();
            services.AddTransient<IeReturnNonCoalProvider, eReturnNonCoalProvider>();
            services.AddTransient<IeReturnNonCoalForm2Provider, eReturnNonCoalForm2Provider>();
            services.AddTransient<IeReturnNonCoalYearlyG1Provider,eReturnNonCoalYearlyG1Provider>();

            services.AddTransient<IMonthlyCoalReturnProvider, MonthlyCoalReturnProvider>();
            services.AddTransient<IYearlyCoalReturnProvider, YearlyCoalReturnProvider>();
            services.AddTransient<IeReturnNonCoalYearlyG2Provider,eReturnNonCoalYearlyG2Provider>();

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
            // app.UseMvc();
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

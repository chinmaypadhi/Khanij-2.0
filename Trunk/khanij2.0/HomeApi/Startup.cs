using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HomeApi.AuthenticationHandler;
using HomeApi.ExceptionHandlear;
using HomeApi.Factory;
using HomeApi.Factory.Factory;
using HomeApi.Model.Banner;
using HomeApi.Model.ExceptionList;
using HomeApi.Model.Feedback;
using HomeApi.Model.Gallery;
using HomeApi.Model.GlobalLink;
using HomeApi.Model.Login;
using HomeApi.Model.Notification;
using HomeApi.Model.NotificationType;
using HomeApi.Model.Page;
using HomeApi.Model.PrimaryLink;
using HomeApi.Model.Qbuilder;
using HomeApi.Model.StaffDirectory;
using HomeApi.Model.Tender;
using HomeApi.Model.Testimonial;
using HomeApi.Model.UserProfile;
using HomeApi.Model.ForgotPassword;
using HomeApi.Services;
using Microsoft.AspNetCore.Authentication;
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
using Microsoft.OpenApi.Models;
using HomeApi.Model.ChangePassword;
using HomeApi.Model.Graph;
using HomeApi.Model.MineralMap;

namespace HomeApi
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
            services.Configure<FormOptions>(options =>
            {
                options.ValueLengthLimit = int.MaxValue;
                options.MultipartBodyLengthLimit = int.MaxValue;
                options.MultipartHeadersLengthLimit = int.MaxValue;
                options.ValueCountLimit = int.MaxValue;
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
            #region commented on 28.10.2021 for using jwt
            // configure basic authentication 
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
            services.AddLogging();
            services.AddScoped<ILoginProvider, LoginProvider>();
            services.AddScoped<IForgotPasswordProvider, ForgotPasswordProvider>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IExceptionProvider, ExceptionProvider>();
            #region Website module
            services.AddScoped<INotificationProvider, NotificationProvider>();
            services.AddScoped<ITenderProvider, TenderProvider>();
            services.AddScoped<INotificationTypeProvider, NotificationTypeProvider>();
            services.AddScoped<IStaffDirectoryProvider, StaffDirectoryProvider>();
            services.AddScoped<IBannerProvider, BannerProvider>();
            services.AddScoped<ITestimonialProvider, TestimonialProvider>();
            services.AddScoped<IGalleryProvider, GalleryProvider>();
            services.AddScoped<IGlobalLinkProvider, GlobalLinkProvider>();
            services.AddScoped<IUserProfileProvider, UserProfileProvider>();
            services.AddScoped<IFeedbackProvider, FeedbackProvider>();
            services.AddScoped<IPageProvider, PageProvider>();
            services.AddScoped<IPrimaryLinkProvider, PrimaryLinkProvider>();
            services.AddScoped<IQbuilderProvider, QbuilderProvider>();
            services.AddScoped<IRevenueProvider, RevenueProvider>();
            services.AddScoped<IProductionProvider, ProductionProvider>();
            services.AddScoped<IResourcesProvider, ResourcesProvider>();
            services.AddScoped<IMineralMapProvider, MineralMapProvider>();
            #endregion
            services.AddScoped<IChangePasswordProvider, ChangePasswordProvider>();
            // configure DI for application services
            IConnectionFactory connectionFactory = new ConnectionFactory(Configuration.GetConnectionString("CIMSConnectionString"));
            services.AddSingleton(connectionFactory);
            services.AddRouting();
            services.AddControllers();
            // Register the Swagger generator, defining 1 or more Swagger documents
            // services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" }); });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "HomeApi", Version = "v1" });
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First()); //This line
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "homeapi v1"));
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

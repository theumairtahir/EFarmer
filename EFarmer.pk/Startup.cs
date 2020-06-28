using ImageUploader;
using ImageWriter;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.IO;
using Swashbuckle.AspNetCore.SwaggerUI;
using Swashbuckle.AspNetCore;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.Swagger;
using System.Collections.Generic;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.PlatformAbstractions;
using EFarmerPkModelLibrary.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.AspNetCore.Mvc.Razor;
using System.Globalization;
using Microsoft.Extensions.Options;
using EFarmer.pk.Common;

namespace EFarmer.pk
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
            //dbcontext
            services.AddDbContext<EFarmerDbModel>(options => options.UseSqlServer(Common.ConnectionStrings.CONNECTION_STRING))
                .AddUnitOfWork<EFarmerDbModel>();

            //swagger
            var pathToDoc = Configuration["Swagger:FileName"];
            services.AddSwaggerGen();
            services.ConfigureSwaggerGen(options =>
            {
                options.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "EFarmer.pk",
                        Version = "v1",
                        Description = "An Api of application for the farmers to provide buy and sell facility",
                        TermsOfService = new System.Uri("https://www.google.com")
                    }
                 );

                var filePath = Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, pathToDoc);
                options.IncludeXmlComments(filePath);
#pragma warning disable CS0618 // Type or member is obsolete
                options.DescribeAllEnumsAsStrings();

#pragma warning restore CS0618 // Type or member is obsolete
            });
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            //Resources
            services.AddLocalization(opts =>
            {
                opts.ResourcesPath = "Resources";
            });

            services.AddMvc()
                .AddViewLocalization(opts =>
                {
                    opts.ResourcesPath = "Resources";
                })
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddTransient<IImageHandler, ImageHandler>();
            services.AddTransient<IImageWriter, ImageWriter.ImageWriter>();
            services.Configure<RequestLocalizationOptions>(opts =>
            {
                var supportedCultures = new List<CultureInfo>()
                {
                     new CultureInfo("en"),
                     new CultureInfo("en-US"),
                     new CultureInfo("ur-PK")
                };
                opts.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("ur");
                opts.SupportedCultures = supportedCultures;
                opts.SupportedUICultures = supportedCultures;
            });
            services.AddMvc(c => c.Conventions.Add(new SwaggerIgnore()));
            //services.AddRouting();
            //areas
            //services.Configure<RazorViewEngineOptions>(options =>
            //{
            //    //options.AreaViewLocationFormats.Clear();
            //    options.AreaViewLocationFormats.Add("/Areas/{2}/Views/{1}/{0}.cshtml");
            //    options.AreaViewLocationFormats.Add("/Areas/{2}/Views/Shared/{0}.cshtml");
            //    //options.AreaViewLocationFormats.Add("/Views/{1}/{0}.cshtml");
            //    //options.AreaViewLocationFormats.Add("/Views/Shared/{0}.cshtml");
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            //localization

            var localizationOptions = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(localizationOptions.Value);

            app.UseMvc(routes =>
            {
                //area route
                //routes.MapRoute(
                //name: "areas",
                //template: "{area=Admin}/{controller = Dashboard}/{action = Index}/{id?}");
                routes.MapAreaRoute(
                    name: "AdminArea",
                    areaName: "Admin",
                    template: "Admin/{controller=Dashboard}/{action=Index}/{id?}");
                //default route
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            //swagger
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            app.UseStaticFiles();
            var basePath = "";
            app.UseSwagger(c =>
            {
                c.RouteTemplate = "swagger/{documentName}/swagger.json";
                c.PreSerializeFilters.Add((swaggerDoc, httpReq) =>
                {
                    swaggerDoc.Servers = new List<OpenApiServer> { new OpenApiServer { Url = $"{httpReq.Scheme}://{httpReq.Host.Value}{basePath}" } };
                });
            });

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "V1 Docs");
            });
        }
    }
}

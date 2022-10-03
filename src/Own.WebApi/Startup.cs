using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Own.Infrastructure;
using Serilog;
using System;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Own.WebApi.Errors;
using Own.Application;

namespace Own.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddPresentation();
            services.AddApplication();
            services.AddInfrastructure(Configuration);
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                // under dev env, return detailed messages including stack trace
                // and check request header [Accept] to display return value in different formats.
                // if its not enabled, then just 500 error.
                app.UseDeveloperExceptionPage();
                app.UseSwagger(c =>
                {
                    // documentName要和SwaggerDoc.name一致
                    c.RouteTemplate = "api-docs/{documentName}/swagger.json";
                });
                app.UseSwaggerUI(c =>
                {
                    c.RoutePrefix = "api-docs";
                    c.DocumentTitle = "Own api-docs";
                    c.SwaggerEndpoint("/api-docs/v1/swagger.json", "Own API V1");
                    c.SwaggerEndpoint("/api-docs/v2/swagger.json", "Own API V2");
                    c.IndexStream = () => GetType().Assembly.GetManifestResourceStream("Own.WebApi.Pages.swaggerindex.html");
                    c.DisplayRequestDuration();
                });
            }
            else
            {
                app.UseExceptionHandler("/error");
            }

            app.UseSerilogRequestLogging();

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

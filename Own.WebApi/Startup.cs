using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;

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
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                // swagger doc
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Own API",
                    Version = "v1",
                    Description = "This is My Own API!",
                    Contact = new OpenApiContact
                    {
                        Name = "gusong",
                        Email = "kandejianer@gmail.com"
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Apache 2.0",
                        Url = new Uri("http://www.apache.org/licenses/LICENSE-2.0.html")
                    }
                });
                c.SwaggerDoc("v2", new OpenApiInfo { Title = "Own API", Version = "v2" });

                // xml comments
                var filePath = Path.Combine(AppContext.BaseDirectory, "Own.WebApi.xml");
                c.IncludeXmlComments(filePath);

                // security
                c.AddSecurityDefinition("bearerAuth", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Description = "JWT Authorization header using the Bearer scheme."
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "bearerAuth" }
                        },
                        new string[] {}
                    }
                });
            });
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
                app.UseDeveloperExceptionPage();
                app.UseSwagger(c =>
                {
                    // documentName和SwaggerDoc.name一致
                    c.RouteTemplate = "api-docs/{documentName}/swagger.json";
                });
                app.UseSwaggerUI(c =>
                {
                    // 修改相对路径
                    c.RoutePrefix = "api-docs";
                    // 浏览器标签页名
                    c.DocumentTitle = "Own api-docs";
                    c.SwaggerEndpoint("/api-docs/v1/swagger.json", "Own API V1");
                    c.SwaggerEndpoint("/api-docs/v2/swagger.json", "Own API V2");
                    c.IndexStream = () => GetType().Assembly.GetManifestResourceStream("Own.WebApi.Pages.swaggerindex.html");
                    c.DisplayRequestDuration();
                });
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

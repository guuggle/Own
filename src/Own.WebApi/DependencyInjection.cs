using Microsoft.Extensions.DependencyInjection;
using Own.WebApi.Mappings;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Own.WebApi.Errors;

namespace Own.WebApi
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddMappings();
            services.AddApiVersioning(config =>
            {
                // Specify the default API Version as 1.0
                config.DefaultApiVersion = new ApiVersion(1, 0);
                // If the client hasn't specified the API version in the request, use the default API version number 
                config.AssumeDefaultVersionWhenUnspecified = true;
                // Advertise the API versions supported for the particular endpoint
                config.ReportApiVersions = true;
            });

            services
                .AddControllers()
                .AddMvcOptions(options =>
                {
                    options.ReturnHttpNotAcceptable = true;
                })
                //.AddXmlSerializerFormatters()
                //.AddXmlDataContractSerializerFormatters() // TODO: 区别?
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.PropertyNamingPolicy = null;
                });

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
                        Name = "guuggle",
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

            services.AddSingleton<ProblemDetailsFactory, OwnProblemDetailsFactory>();

            return services;
        }
    }
}

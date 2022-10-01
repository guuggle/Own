using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Own.Infrastructure.Persistence;
using Own.Infrastructure.Repository;
using Own.Infrastructure.Authentication;
using System;
using System.Collections.Generic;
using System.Text;
using Own.Application.Common.Interfaces;
using Own.Application.Common.Interfaces.Persistence;
using Own.Application.Common.Interfaces.Authentication;
using Own.Application.Common.Interfaces.Services;
using Own.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Own.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<OwnDbContext>(options =>
            {
                options.UseMySQL(configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddAuth(configuration);
            services.AddScoped<IOwnDbContext, OwnDbContext>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
            return services;
        }

        /// <summary>
        /// AddAuthentication可以指定默认scheme name，这样Authorize如果需要走默认scheme则无需指定任何scheme name
        /// 如果不指定默认scheme name，则所有Authorize都需指定scheme name否则会抛未找到scheme的异常
        /// Addxxx如AddJwtBear, AddCookie等等都有各自默认名字
        /// 如需配置多个Scheme，分别指定好SchemeName，可以在AddAuthentication时指定默认SchemeName
        /// 这样可灵活使用Authorize特性
        /// <see cref="https://learn.microsoft.com/en-us/aspnet/core/security/authorization/limitingidentitybyscheme?view=aspnetcore-6.0"/>
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        private static IServiceCollection AddAuth(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtSettings = new JwtSettings();
            configuration.Bind(JwtSettings.SectionName, jwtSettings);
            services.AddSingleton(Options.Create(jwtSettings));
            // services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName)); // 等价于上三行
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

            services.AddAuthentication(jwtSettings.SchemeName)
                .AddJwtBearer(jwtSettings.SchemeName, options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret)),

                        ValidateIssuer = true,
                        ValidIssuer = jwtSettings.Issuer,

                        ValidateAudience = true,
                        ValidAudience = jwtSettings.Audience,

                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.FromMinutes(0)
                    };
                });

            return services;
        }
    }
}

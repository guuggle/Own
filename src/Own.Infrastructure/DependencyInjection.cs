using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
            services.AddScoped<IOwnDbContext, OwnDbContext>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
            return services;
        }
    }
}

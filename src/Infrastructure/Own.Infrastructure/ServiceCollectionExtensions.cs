using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Own.Application.Interfaces;
using Own.Infrastructure.Persistence;
using Own.Infrastructure.Repository;
using Own.Infrastructure.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Own.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<OwnDbContext>(options =>
            {
                //options.UseMySQL(
                //    configuration.GetConnectionString("DefaultConnection"),
                //    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName));
                options.UseMySQL(configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddScoped<IOwnDbContext, OwnDbContext>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            return services;
        }
    }
}

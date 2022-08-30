using Microsoft.Extensions.DependencyInjection;
using Own.Application.Interfaces;
using Own.Infrastructure.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Own.Infrastructure.ServiceCollectionExtensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<ISysUserService, SysUserService>();
            return services;
        }
    }
}

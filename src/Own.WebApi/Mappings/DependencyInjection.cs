using System.Runtime.CompilerServices;
using System.Reflection;
using System.ComponentModel.Design;
using Mapster;
using Microsoft.Extensions.DependencyInjection;
using MapsterMapper;

namespace Own.WebApi.Mappings
{
    public static class DependencyInjection
    {
        /// <summary>
        /// config.Scan will call all Register method that implement <see cref="IRegister"/>
        /// from given assemblys.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddMappings(this IServiceCollection services)
        {
            var config = TypeAdapterConfig.GlobalSettings;
            config.Scan(Assembly.GetExecutingAssembly());

            services.AddSingleton(config);
            services.AddScoped<IMapper, ServiceMapper>();
            return services;
        }

    }
}
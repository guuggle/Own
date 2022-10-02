using Microsoft.Extensions.DependencyInjection;
using MediatR;

namespace Own.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(typeof(DependencyInjection).Assembly);
            // services.AddScoped<IAuthenticationService, AuthenticationService>();
            return services;
        }
    }
}

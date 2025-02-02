using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;

namespace payture.Application
{
    public static class Inject
    {
        public static IServiceCollection AddPaytureApplication(this IServiceCollection services)
        {
            services.AddScoped<IPaytureService, PaytureService>();

            return services;
        }

    }
}

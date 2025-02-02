using Microsoft.Extensions.DependencyInjection;

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

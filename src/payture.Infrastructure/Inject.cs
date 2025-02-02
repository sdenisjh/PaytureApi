using Microsoft.Extensions.DependencyInjection;
using payture.Infrastructure.Infrastructure.Payture;

public static class Inject
{
    public static IServiceCollection AddPaytureInfrastructure(this IServiceCollection services)
    {
        services.AddPaytureClient();

        return services;
    }

    private static IServiceCollection AddPaytureClient(this IServiceCollection services)
    {
        services.AddHttpClient<IApiProvider, ApiProvider>(client =>
        {
            client.BaseAddress = new Uri("https://sandbox3.payture.com/api/");
            client.Timeout = TimeSpan.FromSeconds(100);
            client.DefaultRequestHeaders.Add("Accept", "application/xml");
        });

        return services;
    }
}

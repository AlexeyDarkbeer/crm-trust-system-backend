using CRM.Trust.Application.HttpClients;
using CRM.Trust.Infrastructure.HttpClients;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.Extensions.Http;

namespace CRM.Trust.Infrastructure;

public static class HttpClientsConfigurationExtensions
{
    public static IServiceCollection AddMathCoreHttpClient(this IServiceCollection services,
        IConfiguration configuration)
    {
        var settings = new MathCoreHttpClientSettings();
        configuration.GetSection(MathCoreHttpClientSettings.SECTION).Bind(settings);

        services.AddHttpClient(MathCoreHttpClientSettings.HTTP_CLIENT_NAME)
            .ConfigureHttpClient(httpClient =>
            {
                httpClient.BaseAddress = new Uri(settings.Url);
            })
            .SetHandlerLifetime(TimeSpan.FromMinutes(5))
            .AddPolicyHandler(GetRetryPolicy());
        services.AddScoped<IMathCoreHttpClient, MathCoreHttpClient>();
        return services;
    }
    
    private static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
    {
        return HttpPolicyExtensions
            .HandleTransientHttpError()
            .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
            .WaitAndRetryAsync(2, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
    }
}
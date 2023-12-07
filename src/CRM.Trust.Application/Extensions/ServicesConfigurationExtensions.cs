using CRM.Trust.Application.Services.Scorings;
using Microsoft.Extensions.DependencyInjection;

namespace CRM.Trust.Application.Extensions;

public static class ServicesConfigurationExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IScoringService, ScoringService>();
        return services;
    }
}
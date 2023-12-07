using CRM.Trust.Application.Services.Scorings.Mappings;
using Microsoft.Extensions.DependencyInjection;

namespace CRM.Trust.Application.Extensions;

public static class MappingConfigurationExtensions
{
    public static IServiceCollection AddApplicationMappings(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(ScoringMapping));
        return services;
    }
}
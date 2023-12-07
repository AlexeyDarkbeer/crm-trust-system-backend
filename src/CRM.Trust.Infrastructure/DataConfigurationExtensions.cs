using CRM.Trust.Application.Data;
using CRM.Trust.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CRM.Trust.Infrastructure;

public static class DataConfigurationExtensions
{
    public static IServiceCollection AddCoreContext(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<ICoreContext, CoreContext>(options =>
        {
            var connectionString = configuration.GetConnectionString(CoreContext.SCHEMA);
            options.UseNpgsql(connectionString, optionsBuilder =>
            {
                optionsBuilder.MigrationsHistoryTable(HistoryRepository.DefaultTableName, CoreContext.SCHEMA);
            });
        });
        return services;
    }
    
    public static IServiceCollection AddScoringContext(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<IScoringContext, ScoringContext>(options =>
        {
            var connectionString = configuration.GetConnectionString(ScoringContext.SCHEMA);
            options.UseNpgsql(connectionString, optionsBuilder =>
            {
                optionsBuilder.MigrationsHistoryTable(HistoryRepository.DefaultTableName, ScoringContext.SCHEMA);
            });
        });
        return services;
    }
}
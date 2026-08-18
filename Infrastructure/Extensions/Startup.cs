using Application;
using Infrastructure.Context;
using Infrastructure.Extensions.Cors;
using Infrastructure.Extensions.Logs;
using Infrastructure.Extensions.Mediator;
using Infrastructure.Extensions.OpenApi;
using Infrastructure.Extensions.Persistence;
using Infrastructure.Extensions.Service;
using Infrastructure.Extensions.Validation;
using Infrastructure.Inicialize;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace Infrastructure.Extensions;

public static class Startup
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration config, IWebHostEnvironment env)
    {
        MapsterSettings.Configure();
        services
            .AddPersistence(config)
            .AddOpenApiDocumentation()
            .AddValidation()
            .AddMediator()
            .AddCorsPolicy(config)
            .AddLogger()
            .AddRepositories(config)
            .AddDomainServices();
    }

    public static void UseInfrastructure(this IApplicationBuilder builder)
    {
        builder
            .UseOpenApiDocumentation()
            .UseCorsPolicy();
    }

    public static async Task InitializeDatabasesAsync(this IApplicationBuilder builder)
    {
        try
        {
            using IServiceScope? scope = builder.ApplicationServices.GetService<IServiceScopeFactory>()?.CreateScope();
            PersistenceContext contex = scope!.ServiceProvider.GetRequiredService<PersistenceContext>();
            Start start = new(contex);
            start.UseDatabase();
            await start.InitializeDatabasesAsync();
        }
        catch (Exception e)
        {
            Log.Error($"Error to initialize the database {e.Message}, {e}");
        }
    }
}
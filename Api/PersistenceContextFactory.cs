using Infrastructure.Context;
using Infrastructure.Extensions.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Options;

namespace Api;

public class PersistenceContextFactory : IDesignTimeDbContextFactory<PersistenceContext>
{
    public PersistenceContext CreateDbContext(string[] args)
    {
        IConfigurationRoot config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true)
            .Build();
        
        ServiceProvider? serviceProvider = new ServiceCollection()
            .AddOptions()
            .Configure<DatabaseSettings>(config.GetSection(nameof(DatabaseSettings)))
            .BuildServiceProvider();

        IOptions<DatabaseSettings> databaseSettingsOptions = serviceProvider.GetRequiredService<IOptions<DatabaseSettings>>();
        DatabaseSettings? settings = databaseSettingsOptions.Value;
        
        DbContextOptionsBuilder<PersistenceContext> optionsBuilder = new();
        
        MySqlServerVersion serverVersion = new(new Version(8, 4, 0));
        optionsBuilder.UseMySql(settings?.ConnectionString!, serverVersion, sqlopts =>
        {
            sqlopts.MigrationsHistoryTable(settings?.MigrationsHistoryTable!);
        });

        return new PersistenceContext(optionsBuilder.Options, databaseSettingsOptions);
    }
}
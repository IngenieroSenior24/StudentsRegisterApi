using Api.Filters;
using Infrastructure.Common;
using Infrastructure.Extensions;
using Prometheus;
using Serilog;

StaticLogger.EnsureInitialized();
Log.Information("Server Booting Up...");
WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
ConfigurationManager config = builder.Configuration;
if (builder.Environment.IsDevelopment())
{
    config.AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true);
}
else if (builder.Environment.IsProduction())
{
    config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
}
builder.Services.AddHealthChecks();
builder.Services.AddControllers(opts =>
{
    opts.Filters.Add(typeof(AppExceptionFilterAttribute));
});
builder.Services.AddInfrastructure(config, builder.Environment);

builder.Services.AddEndpointsApiExplorer();

WebApplication app = builder.Build();
await app.InitializeDatabasesAsync();
app.UseInfrastructure();
app.UseRouting().UseHttpMetrics().UseEndpoints(endpoints =>
{
    endpoints.MapMetrics();
    endpoints.MapHealthChecks("/health");
});
app.UseHttpLogging();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

public partial class Program { }
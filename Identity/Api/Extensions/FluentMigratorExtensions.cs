using System.Reflection;
using FluentMigrator.Runner;
using FluentMigrator.Runner.Initialization;
using Infrastructure.Migrations;

namespace Api.Extensions;

public static class FluentMigratorExtensions
{
    public static IServiceCollection AddFluentRunner(this IServiceCollection serviceCollection,IConfiguration configuration)
    {
        Console.WriteLine( configuration["ConnectionString"]);
        serviceCollection.AddLogging(c => c.AddFluentMigratorConsole())
            .AddFluentMigratorCore()
            .ConfigureRunner(c => c
                .AddPostgres()
                .WithGlobalConnectionString(
                    configuration["ConnectionString"])
                .ScanIn(typeof(InitialMigration).Assembly).For.Migrations());
        return serviceCollection;
    }
    
    public static IApplicationBuilder UseFluentMigrator(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var runner = scope.ServiceProvider.GetService<IMigrationRunner>();
        runner.MigrateUp();
        return app;
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace AspireApp1.Shared;

public static class DependencyInjectionExtensions
{
    public static IHostApplicationBuilder AddSharedServices(this IHostApplicationBuilder builder)
    {
        // AddSqlServerDbContext does the following:
        // Enable retry on failure - .EnableRetryOnFailure()
        // Pools the DbContext - .AddPooledDbContext<TDbContext>()
        // Adds tracing for sql server client - .AddSqlClientInstrumentation()
        // Add health check - .AddDbContextCheck<TDbContext>()
        builder.AddSqlServerDbContext<MyDbContext>("sql", settings =>
        {
            settings.ConnectionString = builder.Configuration.GetConnectionString("ConnectionStrings__Database");
        }, configure =>
        {
            configure.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        });

        return builder;
    }
}

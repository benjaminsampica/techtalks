using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    // Normal initialization
    //.ConfigureFunctionsWorkerDefaults()
    // ASP.NET Core initialization
    // NOTE: Not all features of ASP.NET Core are exposed by this model. Specifically, the ASP.NET Core middleware pipeline and routing capabilities are not available.
    .ConfigureFunctionsWebApplication()
    .ConfigureAppConfiguration((hostContext, configBuilder) =>
    {
        configBuilder
            .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables();
    })
    .ConfigureServices(services =>
    {
    })
    .Build();

host.Run();

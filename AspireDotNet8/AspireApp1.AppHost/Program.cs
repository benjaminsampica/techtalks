using Testcontainers.MsSql;

var builder = DistributedApplication.CreateBuilder(args);

var sqlServer = new MsSqlBuilder()
    .Build();
await sqlServer.StartAsync();

var apiService = builder.AddProject<Projects.AspireApp1_ApiService>("apiservice")
    .WithEnvironment("ConnectionStrings__Database", sqlServer.GetConnectionString());

builder.AddProject<Projects.AspireApp1_Web>("webfrontend")
    .WithReference(apiService)
    .WithEnvironment("ConnectionStrings__Database", sqlServer.GetConnectionString());

builder.Build().Run();

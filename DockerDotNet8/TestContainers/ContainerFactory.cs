using Testcontainers.Azurite;
using Testcontainers.MsSql;

namespace TestContainersDotNet8;

public sealed class AzuriteContainerFactory : IAsyncDisposable
{
    private static AzuriteContainer _azuriteContainer = null!;

    private AzuriteContainerFactory() { }

    public static async Task<string> CreateAsync()
    {
        _azuriteContainer = new AzuriteBuilder()
            .WithImage("mcr.microsoft.com/azure-storage/azurite:3.27.0")
            .Build();

        await _azuriteContainer.StartAsync();

        return _azuriteContainer.GetConnectionString();
    }

    public ValueTask DisposeAsync() => _azuriteContainer.DisposeAsync();
}
public sealed class MsSqlContainerFactory : IAsyncDisposable
{
    private static readonly List<MsSqlContainer> _msSqlContainers = [];

    private MsSqlContainerFactory() { }

    public static async Task<string> CreateAsync()
    {
        var msSqlContainer = new MsSqlBuilder()
            .Build();

        await msSqlContainer.StartAsync();

        _msSqlContainers.Add(msSqlContainer);

        return msSqlContainer.GetConnectionString();
    }

    public async ValueTask DisposeAsync()
    {
        await ValueTask.FromResult(_msSqlContainers.Select(c => c.DisposeAsync()));
    }
}
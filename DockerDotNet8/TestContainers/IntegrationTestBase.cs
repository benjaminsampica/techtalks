using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace TestContainersDotNet8;

public class TestDbContext(DbContextOptions<TestDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
}

public class IntegrationTestBase
{
#pragma warning disable NUnit1032 // An IDisposable field/property should be Disposed in a TearDown method
    private IServiceProvider _serviceProvider = null!;
#pragma warning restore NUnit1032 // An IDisposable field/property should be Disposed in a TearDown method

    [OneTimeSetUp]
    public async Task Initialize()
    {
        var sqlConnectionString = await MsSqlContainerFactory.CreateAsync();
        _serviceProvider = new ServiceCollection()
            .AddDbContext<TestDbContext>(d =>
                // d.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=DotNet8Tests;Integrated Security=True;MultipleActiveResultSets=true;")) // Works locally, and on windows vms. But not linux.
                d.UseSqlServer(sqlConnectionString))
            .AddLogging(builder => builder.AddConsole())
            .BuildServiceProvider();
    }

    [SetUp]
    public async Task ResetAsync()
    {
        var dbContext = _serviceProvider.GetRequiredService<TestDbContext>();
        await dbContext.Database.EnsureCreatedAsync();
    }

    public T GetRequiredService<T>() where T : class => _serviceProvider.GetRequiredService<T>();
}

public class User
{
    public int Id { get; set; }
    public required string Name { get; set; }
}
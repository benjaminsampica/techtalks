using EfCoreEight;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace EFCoreEight;

public class TestDbContext(DbContextOptions<TestDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<PrimitiveCollection> PrimitiveCollections { get; set; }
}

public class TestBase
{
    private IServiceProvider _serviceProvider = null!;

    [OneTimeSetUp]
    public void Initialize()
    {
        _serviceProvider = new ServiceCollection()
            .AddDbContext<TestDbContext>(d =>
                d.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=DotNet8Tests;Integrated Security=True;MultipleActiveResultSets=true;"))
            .AddLogging(builder => builder.AddConsole())
            .BuildServiceProvider();
    }

    [SetUp]
    public async Task ResetAsync()
    {
        var dbContext = _serviceProvider.GetRequiredService<TestDbContext>();
        await dbContext.Database.EnsureDeletedAsync();
        await dbContext.Database.EnsureCreatedAsync();
    }

    public T GetRequiredService<T>() where T : class => _serviceProvider.GetRequiredService<T>();
}
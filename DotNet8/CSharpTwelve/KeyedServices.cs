using Microsoft.Extensions.DependencyInjection;

namespace CSharpTwelve;

public class NerdDbContext
{
    public IEnumerable<User> Users { get; set; } = [];
}

public class User
{
    public int Id { get; set; }
    public bool LikesDAndD { get; set; }
    public bool LikesProgramming { get; set; }
}

// Interface implemented by multiple things that need dependency injection.
public interface INerdValidator
{
    public bool IsNerd();
}

public interface ICurrentUserService
{
    public int Id { get; }
}

// First validator
public class LikesDAndDNerdValidator : INerdValidator
{
    readonly NerdDbContext _dbContext;
    readonly ICurrentUserService _cus;

    public LikesDAndDNerdValidator(NerdDbContext dbContext, ICurrentUserService cus)
    {
        _dbContext = dbContext;
        _cus = cus;
    }

    public bool IsNerd()
    {
        var user = _dbContext.Users.First(u => u.Id == _cus.Id);

        return user.LikesDAndD;
    }
}

// Second Validator
public class LikesProgrammingNerdValidator : INerdValidator
{
    readonly NerdDbContext _dbContext;
    readonly ICurrentUserService _cus;

    public LikesProgrammingNerdValidator(NerdDbContext dbContext, ICurrentUserService cus)
    {
        _dbContext = dbContext;
        _cus = cus;
    }

    public bool IsNerd()
    {
        var user = _dbContext.Users.First(u => u.Id == _cus.Id);

        return user.LikesProgramming;
    }
}

public static class DependencyInjectionExtensions1
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddKeyedScoped<INerdValidator, LikesProgrammingNerdValidator>("Likes Programming");
        services.AddKeyedScoped<INerdValidator, LikesDAndDNerdValidator>("D&D");

        return services;
    }

    public static void GetKeyedService()
    {
        var services = new ServiceCollection()
            .AddApplicationServices()
            .BuildServiceProvider();

        services.GetRequiredKeyedService<INerdValidator>("Likes Programming");
    }

    // Production example
    // https://dev.azure.com/caseys01/Financials/_git/Daysheets?path=/src/Daysheets.Web/Features/DaysheetValidationReport/DaysheetValidationReport.razor.cs&version=GBmain&line=98&lineEnd=99&lineStartColumn=1&lineEndColumn=1&lineStyle=plain&_a=contents
}
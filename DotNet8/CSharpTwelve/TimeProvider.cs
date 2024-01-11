using Microsoft.Extensions.DependencyInjection;

namespace CSharpTwelve;

public class CaseysTimeProvider : TimeProvider
{
    public override TimeZoneInfo LocalTimeZone => TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
}

public static class DependencyInjectionExtensions2
{
    public static IServiceCollection GetServices()
    {
        var services = new ServiceCollection();

        services.AddSingleton<CaseysTimeProvider>();

        return services;
    }

    // Production example
    // https://dev.azure.com/caseys01/Financials/_git/TenderSettlementReconciliation?path=/src/TenderSettlementReconciliation.Function/Features/Shared/DateTimeProvider.cs&version=GBmain
}

public class MyMethodUsingCaseysTime(CaseysTimeProvider caseysTimeProvider)
{
    public void ShowMethods()
    {
        caseysTimeProvider.GetUtcNow();
        caseysTimeProvider.GetLocalNow();

        var thisInstant = caseysTimeProvider.GetTimestamp();
        var elapsed = caseysTimeProvider.GetElapsedTime(thisInstant);

        // https://github.com/dotnet/runtime/issues/95213
        // Backporting on 8.0.2 sometime in the next couple of weeks.
        // Linux only issue
        var bugWithDisplayName = caseysTimeProvider.LocalTimeZone.StandardName;
    }
}

public class TestMyMethodUsingCaseysTime
{
    public void Test()
    {
        var sut = new MyMethodUsingCaseysTime(new CaseysTimeProvider());
    }
}

public class NoWaitingTimeProvider : TimeProvider
{
    public override ITimer CreateTimer(
        TimerCallback callback,
        object? state,
        TimeSpan dueTime,
        TimeSpan period)
    {
        return base.CreateTimer(callback, state, TimeSpan.Zero, period);
    }
}

public class TestMyMethodUsingNoWaiting
{
    public async Task Test()
    {
        var timer = new NoWaitingTimeProvider();

        Console.WriteLine("Entering Task.Delay at " + timer.GetUtcNow());
        await Task.Delay(TimeSpan.FromSeconds(5), timer);
        Console.WriteLine("Exiting Task.Delay at " + timer.GetUtcNow());
    }
}
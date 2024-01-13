using Microsoft.AspNetCore.OutputCaching;

namespace YouMightHaveMissed;

public sealed class OutputCacheWithAuthPolicy : IOutputCachePolicy
{
    ValueTask IOutputCachePolicy.CacheRequestAsync(OutputCacheContext context, CancellationToken cancellationToken)
    {
        var attemptOutputCaching = AttemptOutputCaching(context);
        context.EnableOutputCaching = true;
        context.AllowCacheLookup = attemptOutputCaching;
        context.AllowCacheStorage = attemptOutputCaching;
        context.AllowLocking = true;
        context.CacheVaryByRules.QueryKeys = "*";
        context.ResponseExpirationTimeSpan = TimeSpan.FromHours(1);
        return ValueTask.CompletedTask;
    }

    // By default, the out-of-the-box caching doesn't cache authenticated requests so we override this behavior by just specifying get/head.
    private static bool AttemptOutputCaching(OutputCacheContext context)
    {
        var request = context.HttpContext.Request;

        if (!HttpMethods.IsGet(request.Method) && !HttpMethods.IsHead(request.Method))
        {
            return false;
        }

        return true;
    }

    public ValueTask ServeFromCacheAsync(OutputCacheContext context, CancellationToken cancellation) => ValueTask.CompletedTask;
    public ValueTask ServeResponseAsync(OutputCacheContext context, CancellationToken cancellation) => ValueTask.CompletedTask;

}
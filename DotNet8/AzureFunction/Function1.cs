using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System.Net;

namespace AzureFunction;

public class Function1(ILogger<Function1> logger)
{
    // Old
    [Function("OldFunction1")]
    public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req)
    {
        logger.LogInformation("C# HTTP trigger function processed a request.");

        req.Headers.TryGetValues("Authorization", out var values);
        var authToken = values?.FirstOrDefault();

        var response = req.CreateResponse(HttpStatusCode.OK);
        response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

        await response.WriteStringAsync("Welcome to Azure Functions!");

        return response;
    }
}

public class Function2(ILogger<Function2> logger)
{
    // New
    [Function("NewFunction1")]
    public IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest req)
    {
        logger.LogInformation("C# HTTP trigger function processed a request.");

        // easy access to HttpContrxt, headers, etc. like you're used to in ASP.NET Core
        var traceparent = req.HttpContext.TraceIdentifier;
        var authHeader = req.Headers.Authorization.FirstOrDefault();

        return new ContentResult
        {
            Content = "Welcome to Azure Functions!"
        };
    }
}

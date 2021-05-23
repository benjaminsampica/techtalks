using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorTechTalk.Shared.Application
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(typeof(WeatherForecastQuery));

            return services;
        }
    }
}

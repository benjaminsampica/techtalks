using BlazorTechTalk.Shared.Domain;
using BlazorTechTalk.Shared.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace BlazorTechTalk.Shared.Infrastructure
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BlazorTechTalkDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("Application")));

            SeedData(services);

            return services;
        }

        private static void SeedData(IServiceCollection services)
        {
            var scope = services.BuildServiceProvider().CreateScope();

            var random = new Random();
            var forecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Today.AddDays(index),
                TemperatureC = random.Next(-20, 55),
                Summary = WeatherForecast.Summaries[random.Next(WeatherForecast.Summaries.Length)]
            });

            var dbContext = scope.ServiceProvider.GetRequiredService<BlazorTechTalkDbContext>();
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();
            dbContext.AddRange(forecasts);
            dbContext.SaveChanges();
        }
    }
}

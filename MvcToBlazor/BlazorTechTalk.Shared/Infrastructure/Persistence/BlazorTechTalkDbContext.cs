using BlazorTechTalk.Shared.Domain;
using Microsoft.EntityFrameworkCore;

namespace BlazorTechTalk.Shared.Infrastructure.Persistence
{
    public class BlazorTechTalkDbContext : DbContext
    {
        public BlazorTechTalkDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<WeatherForecast> WeatherForecasts { get; set; }
    }
}

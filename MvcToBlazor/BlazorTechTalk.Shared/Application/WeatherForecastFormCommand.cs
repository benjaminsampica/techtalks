using BlazorTechTalk.Shared.Domain;
using BlazorTechTalk.Shared.Infrastructure.Persistence;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorTechTalk.Shared.Application
{
    public record WeatherForecastFormCommand : IRequest
    {
        public DateTime Date { get; set; }
        public string Summary { get; set; }
        public int TemperatureC { get; set; }

        internal class Handler : IRequestHandler<WeatherForecastFormCommand>
        {
            public BlazorTechTalkDbContext _dbContext { get; set; }

            public Handler(BlazorTechTalkDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<Unit> Handle(WeatherForecastFormCommand request, CancellationToken cancellationToken)
            {
                var weatherForecast = new WeatherForecast
                {
                    Date = request.Date,
                    Summary = request.Summary,
                    TemperatureC = request.TemperatureC
                };

                _dbContext.WeatherForecasts.Add(weatherForecast);
                await _dbContext.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}

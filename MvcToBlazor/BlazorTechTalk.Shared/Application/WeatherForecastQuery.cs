using BlazorTechTalk.Shared.Domain;
using BlazorTechTalk.Shared.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorTechTalk.Shared.Application
{
    public record WeatherForecastQuery(DateTime StartDate, string Search) : IRequest<WeatherForecast[]>
    {
        internal class Handler : IRequestHandler<WeatherForecastQuery, WeatherForecast[]>
        {
            public BlazorTechTalkDbContext _dbContext { get; set; }

            public Handler(BlazorTechTalkDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<WeatherForecast[]> Handle(WeatherForecastQuery request, CancellationToken cancellationToken)
            {
                await Task.Delay(1000); //Uncomment this to see the AlertForecastComponent fail.
                return await _dbContext.WeatherForecasts
                .Where(wf => wf.Summary.Contains(request.Search))
                .ToArrayAsync(cancellationToken);
            }
        }
    }
}

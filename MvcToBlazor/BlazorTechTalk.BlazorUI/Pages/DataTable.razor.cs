using BlazorTechTalk.Shared.Application;
using BlazorTechTalk.Shared.Domain;
using MediatR;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorTechTalk.BlazorUI.Pages
{
    public partial class DataTable : ComponentBase
    {
        [Inject] public IMediator Mediator { get; set; }

        private readonly CancellationTokenSource _cancellationTokenSource = new();

        private WeatherForecast[] forecasts;
        private WeatherForecastQuery _form = new(DateTime.Now, string.Empty);

        protected override async Task OnInitializedAsync()
        {
            //await Task.Delay(1000); // Loading/progress text is super easy to show. Componentize it!
            await SetForecastsAsync();
        }

        private async Task SearchOnInputAsync(ChangeEventArgs args)
        {
            _form = _form with { Search = args.Value.ToString() };

            await SetForecastsAsync();
        }

        private async Task SetForecastsAsync()
        {
            forecasts = await Mediator.Send(_form, _cancellationTokenSource.Token);
        }
    }
}

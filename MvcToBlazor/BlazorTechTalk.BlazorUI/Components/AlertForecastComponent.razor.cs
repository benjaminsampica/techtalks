using BlazorTechTalk.Shared.Application;
using BlazorTechTalk.Shared.Domain;
using MediatR;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorTechTalk.BlazorUI.Components
{
    public sealed partial class AlertForecastComponent : ComponentBase, IDisposable
    {
        [Inject] private IMediator Mediator { get; set; }
        [Parameter] public bool HandleError { get; set; }

        private bool _show;
        private int _count;
        private WeatherForecast[] forecasts;
        private readonly CancellationTokenSource _cancellationTokenSource = new();
        private string _error;

        protected override async Task OnInitializedAsync()
        {
            if (HandleError)
            {
                try
                {
                    forecasts = await Mediator.Send(new WeatherForecastQuery(DateTime.Now, string.Empty), _cancellationTokenSource.Token);
                    _count = forecasts.Length;
                }
                catch
                {
                    _error = "An error occured";
                }
            }
            else
            {
                forecasts = await Mediator.Send(new WeatherForecastQuery(DateTime.Now, string.Empty), _cancellationTokenSource.Token);
                _count = forecasts.Length;
            }
        }

        private void Toggle()
        {
            _show = !_show;
        }

        public void Dispose()
        {
            _cancellationTokenSource?.Cancel();
            _cancellationTokenSource.Dispose();
        }
    }
}

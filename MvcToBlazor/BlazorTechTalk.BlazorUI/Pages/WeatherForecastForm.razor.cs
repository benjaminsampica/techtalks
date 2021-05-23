using BlazorTechTalk.Shared.Application;
using MediatR;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace BlazorTechTalk.BlazorUI.Pages
{
    public partial class WeatherForecastForm : ComponentBase
    {
        [Inject] private IMediator Mediator { get; set; }

        private readonly WeatherForecastFormCommand _form = new() { Date = DateTime.Today };

        private async Task OnValidSubmitAsync()
        {
            await Mediator.Send(_form);
        }
    }
}

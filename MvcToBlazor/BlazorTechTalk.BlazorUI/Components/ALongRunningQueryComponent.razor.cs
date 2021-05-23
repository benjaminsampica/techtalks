using BlazorTechTalk.BlazorUI.Services;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace BlazorTechTalk.BlazorUI.Components
{
    public partial class ALongRunningQueryComponent : ComponentBase
    {
        [Inject] private ComponentStateService ComponentStateService { get; set; }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
        }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                await Task.Delay(3000);
                ComponentStateService.SetContent();
                //throw new Exception();
            }
            catch
            {
                ComponentStateService.SetError();
            }

        }
    }
}

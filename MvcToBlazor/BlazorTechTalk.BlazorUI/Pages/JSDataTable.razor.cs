using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace BlazorTechTalk.BlazorUI.Pages
{
    public partial class JSDataTable : ComponentBase
    {
        [Inject] private IJSRuntime JSRuntime { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender) await JSRuntime.InvokeVoidAsync("initializeDataTable");
        }
    }
}

using Microsoft.AspNetCore.Components;

namespace BlazorTechTalk.BlazorUI.Shared.Components.Bases
{
    public partial class LoadingBase : ComponentBase
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }
    }
}

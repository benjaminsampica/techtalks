using Ardalis.GuardClauses;
using BlazorTechTalk.BlazorUI.Services;
using Microsoft.AspNetCore.Components;

namespace BlazorTechTalk.BlazorUI.Shared.Components
{
    public partial class StatefulComponent : ComponentBase
    {
        [Inject] public ComponentStateService ComponentStateService { get; set; }
        [Parameter] public RenderFragment Loading { get; set; }
        [Parameter] public RenderFragment ChildContent { get; set; }
        [Parameter] public RenderFragment Error { get; set; }
        [Parameter] public ComponentState ParentComponentState { get; set; }

        protected override void OnParametersSet()
        {
            ComponentStateService.SetState(ParentComponentState);

            if (!ParentComponentState.HasError())
            {
                try
                {
                    VerifyInternalParameters();
                }
                catch
                {
                    ComponentStateService.SetError();

                    StateHasChanged();
                }
            }
        }

        protected void VerifyInternalParameters()
        {
            Guard.Against.Null(ChildContent, nameof(ChildContent));
        }
    }
}

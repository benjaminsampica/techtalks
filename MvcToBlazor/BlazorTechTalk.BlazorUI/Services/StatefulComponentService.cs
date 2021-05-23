namespace BlazorTechTalk.BlazorUI.Services
{
    public sealed class ComponentStateService
    {
        public ComponentStateService(ComponentState componentState = ComponentState.Loading)
        {
            ComponentState = componentState;
        }

        private ComponentState ComponentState;

        internal void SetState(ComponentState componentState) => ComponentState = componentState;
        internal void SetContent() => ComponentState = ComponentState.Content;
        internal void SetLoading() => ComponentState = ComponentState.Loading;
        internal void SetError() => ComponentState = ComponentState.Error;
        internal ComponentState GetCurrentState() => ComponentState;
    }

    public static class ComponentStateExtensions
    {
        public static bool HasError(this ComponentState componentState) => componentState == ComponentState.Error;
    }

    public enum ComponentState
    {
        Loading,
        Content,
        Error
    }
}

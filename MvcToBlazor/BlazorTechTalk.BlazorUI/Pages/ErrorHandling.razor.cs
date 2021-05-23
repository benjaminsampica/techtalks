using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace BlazorTechTalk.BlazorUI.Pages
{
    public partial class ErrorHandling : ComponentBase
    {
        protected override Task OnInitializedAsync()
        {
            // Kinda shit tbh. Getting a needed face lift in .NET 6 which provides an overrideable method
            // called OnError/OnErrorAsync that lets you handle exceptions in root components.

            return Task.CompletedTask;
        }
    }
}

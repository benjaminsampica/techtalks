using Clean.Application.Common.Interfaces;
using Clean.Application.Orders.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Clean.WebUI.Pages
{
    public sealed partial class AddOrderPage : ComponentBase, IDisposable
    {
        [Inject] private IOrderService OrderService { get; set; }

        private readonly AddOrderModel _form = new();
        private readonly CancellationTokenSource _cancellationTokenSource = new();

        private async Task OnValidSubmitAsync()
        {
            await OrderService.AddOrderAsync(_form, _cancellationTokenSource.Token);
        }

        public void Dispose()
        {
            _cancellationTokenSource.Cancel();
            _cancellationTokenSource.Dispose();
        }
    }
}

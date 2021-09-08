using MediatR;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace VerticalSliceArchitecture.Features.AddOrder
{
    public sealed partial class AddOrderPage : ComponentBase, IDisposable
    {
        [Inject] private IMediator Mediator { get; set; }

        private readonly AddOrderCommand _form = new();
        private readonly CancellationTokenSource _cancellationTokenSource = new();

        private async Task OnValidSubmitAsync()
        {
            await Mediator.Send(_form, _cancellationTokenSource.Token);
        }

        public void Dispose()
        {
            _cancellationTokenSource.Cancel();
            _cancellationTokenSource.Dispose();
        }
    }
}

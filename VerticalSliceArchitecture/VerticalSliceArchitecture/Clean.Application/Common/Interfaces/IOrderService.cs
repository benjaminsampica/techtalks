using Clean.Application.Orders.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Clean.Application.Common.Interfaces
{
    public interface IOrderService
    {
        ValueTask AddOrderAsync(AddOrderModel orderModel, CancellationToken cancellationToken);
        ValueTask IsOrderShippedAsync(int orderId, CancellationToken cancellationToken);
        ValueTask GetErroredOrdersByDateAsync(DateTime date, CancellationToken cancellationToken);
    }
}

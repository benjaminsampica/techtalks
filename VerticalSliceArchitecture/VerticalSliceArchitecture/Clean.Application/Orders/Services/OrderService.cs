using Clean.Application.Common.Interfaces;
using Clean.Application.Orders.Models;
using Clean.Domain;
using Clean.Domain.Entities;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Clean.Application.Orders.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<Product> _productRepository;

        public OrderService(IRepository<Order> orderRepository, IRepository<Product> productRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }

        public async ValueTask AddOrderAsync(AddOrderModel orderModel, CancellationToken cancellationToken)
        {
            // Do some validation (is this a valid order, etc.)
            // Likely this would exist in another service like IOrderValidatorService which is called before this one.

            var allProducts = await _productRepository.GetAllAsync(cancellationToken);
            var orderedProducts = allProducts
                .Where(p => orderModel.ProductIds.Contains(p.Id))
                .ToArray();

            var order = new Order
            {
                ReferenceNumber = Guid.NewGuid().ToString()
            };
            order.AddProducts(orderedProducts);

            await _orderRepository.AddAsync(order, cancellationToken);
            await _orderRepository.SaveAsync(order, cancellationToken);
        }

        public ValueTask GetErroredOrdersByDateAsync(DateTime date, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public ValueTask IsOrderShippedAsync(int orderId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

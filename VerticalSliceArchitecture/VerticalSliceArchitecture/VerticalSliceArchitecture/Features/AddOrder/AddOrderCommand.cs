using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VerticalSliceArchitecture.Entities;
using VerticalSliceArchitecture.Infrastructure;

namespace VerticalSliceArchitecture.Features.AddOrder
{
    public class AddOrderCommand : IRequest
    {
        public List<int> ProductIds { get; set; }
    }

    public class AddOrderCommandHandler : IRequestHandler<AddOrderCommand>
    {
        private readonly ApplicationDbContext _dbContext;

        public AddOrderCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(AddOrderCommand request, CancellationToken cancellationToken)
        {
            var orderedProducts = await _dbContext.Products
                .Where(p => request.ProductIds.Contains(p.Id))
                .ToArrayAsync(cancellationToken);

            var order = new Order
            {
                ReferenceNumber = Guid.NewGuid().ToString()
            };

            order.AddProducts(orderedProducts);

            _dbContext.Add(order);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }

    // Validate the command before it comes in.
    public class AddOrderCommandValidator : AbstractValidator<AddOrderCommand>
    {
        public AddOrderCommandValidator()
        {
            RuleFor(c => c.ProductIds).NotEmpty();
        }
    }
}

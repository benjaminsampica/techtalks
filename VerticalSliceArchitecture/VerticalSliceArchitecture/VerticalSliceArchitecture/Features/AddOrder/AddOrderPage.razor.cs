using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using VerticalSliceArchitecture.Entities;
using VerticalSliceArchitecture.Infrastructure;

namespace VerticalSliceArchitecture.Features.AddOrder;

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

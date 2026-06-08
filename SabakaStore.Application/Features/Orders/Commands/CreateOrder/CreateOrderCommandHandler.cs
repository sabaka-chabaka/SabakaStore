using MediatR;
using SabakaStore.Application.Common.Errors;
using SabakaStore.Application.Common.Result;
using SabakaStore.Domain.Entities;
using SabakaStore.Domain.Repositories;

namespace SabakaStore.Application.Features.Orders.Commands.CreateOrder;

public class CreateOrderCommandHandler(
    ICartRepository cartRepository,
    IOrderRepository orderRepository) : IRequestHandler<CreateOrderCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(CreateOrderCommand request, CancellationToken ct)
    {
        var cart = await cartRepository.GetByUserIdAsync(request.UserId);
        if (cart is null || !cart.ProductsId.Any())
            return OrderErrors.CartIsEmpty;

        var order = new Order
        {
            Id = Guid.NewGuid(),
            UserId = request.UserId,
            Products = cart.ProductsId.ToList(),
            Quantity = cart.ProductsId.Count
        };

        await orderRepository.AddAsync(order, ct);

        cart.ProductsId.Clear();
        cartRepository.Update(cart);

        await orderRepository.SaveAsync(ct);

        return order.Id;
    }
}

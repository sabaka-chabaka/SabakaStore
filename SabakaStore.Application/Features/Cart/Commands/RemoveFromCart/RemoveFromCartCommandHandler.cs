using MediatR;
using SabakaStore.Application.Common.Errors;
using SabakaStore.Application.Common.Result;
using SabakaStore.Domain.Repositories;

namespace SabakaStore.Application.Features.Cart.Commands.RemoveFromCart;

public class RemoveFromCartCommandHandler(ICartRepository cartRepository)
    : IRequestHandler<RemoveFromCartCommand, Result>
{
    public async Task<Result> Handle(RemoveFromCartCommand request, CancellationToken ct)
    {
        var cart = await cartRepository.GetByUserIdAsync(request.UserId);
        if (cart is null)
            return CartErrors.NotFound;

        var product = cart.ProductsId.FirstOrDefault(p => p.Id == request.ProductId);
        if (product is null)
            return CartErrors.ProductNotInCart;

        cart.ProductsId.Remove(product);
        cartRepository.Update(cart);
        await cartRepository.SaveAsync(ct);

        return Result.Success();
    }
}

using MediatR;
using SabakaStore.Application.Common.Errors;
using SabakaStore.Application.Common.Result;
using SabakaStore.Domain.Repositories;

namespace SabakaStore.Application.Features.Cart.Commands.ClearCart;

public class ClearCartCommandHandler(ICartRepository cartRepository)
    : IRequestHandler<ClearCartCommand, Result>
{
    public async Task<Result> Handle(ClearCartCommand request, CancellationToken ct)
    {
        var cart = await cartRepository.GetByUserIdAsync(request.UserId);
        if (cart is null)
            return CartErrors.NotFound;

        cart.ProductsId.Clear();
        cartRepository.Update(cart);
        await cartRepository.SaveAsync(ct);

        return Result.Success();
    }
}

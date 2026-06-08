using MediatR;
using SabakaStore.Application.Common.Errors;
using SabakaStore.Application.Common.Result;
using SabakaStore.Domain.Repositories;

namespace SabakaStore.Application.Features.Cart.Queries.GetCart;

public class GetCartQueryHandler(ICartRepository cartRepository)
    : IRequestHandler<GetCartQuery, Result<Domain.Entities.Cart>>
{
    public async Task<Result<Domain.Entities.Cart>> Handle(GetCartQuery request, CancellationToken ct)
    {
        var cart = await cartRepository.GetByUserIdAsync(request.UserId);
        if (cart is null)
            return CartErrors.NotFound;

        return cart;
    }
}

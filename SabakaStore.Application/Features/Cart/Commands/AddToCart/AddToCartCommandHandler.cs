using MediatR;
using SabakaStore.Application.Common.Errors;
using SabakaStore.Application.Common.Result;
using SabakaStore.Domain.Repositories;

namespace SabakaStore.Application.Features.Cart.Commands.AddToCart;

public class AddToCartCommandHandler(
    ICartRepository cartRepository,
    IProductRepository productRepository) : IRequestHandler<AddToCartCommand, Result>
{
    public async Task<Result> Handle(AddToCartCommand request, CancellationToken ct)
    {
        var product = await productRepository.GetByIdAsync(request.ProductId);
        if (product is null)
            return ProductErrors.NotFound;

        var cart = await cartRepository.GetByUserIdAsync(request.UserId);
        if (cart is null)
        {
            cart = new Domain.Entities.Cart
            {
                UserId = request.UserId,
                ProductsId = new List<Domain.Entities.Product>()
            };
            await cartRepository.AddAsync(cart, ct);
        }

        cart.ProductsId.Add(product);
        cartRepository.Update(cart);
        await cartRepository.SaveAsync(ct);

        return Result.Success();
    }
}

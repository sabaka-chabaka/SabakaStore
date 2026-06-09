using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SabakaStore.Application.Features.Cart.Commands.AddToCart;
using SabakaStore.Application.Features.Cart.Commands.ClearCart;
using SabakaStore.Application.Features.Cart.Commands.RemoveFromCart;
using SabakaStore.Application.Features.Cart.Queries.GetCart;

namespace SabakaStore.API.Controllers;

[Authorize]
public class CartController(IMediator mediator) : BaseApiController(mediator)
{
    /// <summary>Get current user's cart</summary>
    [HttpGet]
    public async Task<IActionResult> GetCart(CancellationToken ct)
    {
        var result = await Mediator.Send(new GetCartQuery(CurrentUserId), ct);
        return HandleResult(result);
    }

    /// <summary>Add a product to cart</summary>
    [HttpPost("{productId:guid}")]
    public async Task<IActionResult> AddToCart(Guid productId, CancellationToken ct)
    {
        var result = await Mediator.Send(new AddToCartCommand(CurrentUserId, productId), ct);
        return HandleResult(result);
    }

    /// <summary>Remove a product from cart</summary>
    [HttpDelete("{productId:guid}")]
    public async Task<IActionResult> RemoveFromCart(Guid productId, CancellationToken ct)
    {
        var result = await Mediator.Send(new RemoveFromCartCommand(CurrentUserId, productId), ct);
        return HandleResult(result);
    }

    /// <summary>Clear the cart</summary>
    [HttpDelete]
    public async Task<IActionResult> ClearCart(CancellationToken ct)
    {
        var result = await Mediator.Send(new ClearCartCommand(CurrentUserId), ct);
        return HandleResult(result);
    }
}

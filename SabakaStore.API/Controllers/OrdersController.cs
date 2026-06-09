using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SabakaStore.Application.Features.Orders.Commands.CreateOrder;
using SabakaStore.Application.Features.Orders.Queries.GetAllOrders;
using SabakaStore.Application.Features.Orders.Queries.GetOrder;
using SabakaStore.Application.Features.Orders.Queries.GetUserOrders;

namespace SabakaStore.API.Controllers;

[Authorize]
public class OrdersController(IMediator mediator) : BaseApiController(mediator)
{
    /// <summary>Create order from current cart</summary>
    [HttpPost]
    public async Task<IActionResult> CreateOrder(CancellationToken ct)
    {
        var result = await Mediator.Send(new CreateOrderCommand(CurrentUserId), ct);
        return HandleResult(result);
    }

    /// <summary>Get order by id</summary>
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken ct)
    {
        var result = await Mediator.Send(new GetOrderQuery(id), ct);
        return HandleResult(result);
    }

    /// <summary>Get current user's orders</summary>
    [HttpGet("my")]
    public async Task<IActionResult> GetMyOrders(CancellationToken ct)
    {
        var result = await Mediator.Send(new GetUserOrdersQuery(CurrentUserId), ct);
        return HandleResult(result);
    }

    /// <summary>Get all orders (admin)</summary>
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken ct)
    {
        var result = await Mediator.Send(new GetAllOrdersQuery(), ct);
        return HandleResult(result);
    }
}

using MediatR;
using Microsoft.AspNetCore.Mvc;
using SabakaStore.Application.Features.Stores.Queries.GetAllStores;
using SabakaStore.Application.Features.Stores.Queries.GetStore;
using SabakaStore.Application.Features.Stores.Queries.GetStoreProducts;

namespace SabakaStore.API.Controllers;

public class StoresController(IMediator mediator) : BaseApiController(mediator)
{
    /// <summary>Get all stores</summary>
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken ct)
    {
        var result = await Mediator.Send(new GetAllStoresQuery(), ct);
        return HandleResult(result);
    }

    /// <summary>Get store by id</summary>
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken ct)
    {
        var result = await Mediator.Send(new GetStoreQuery(id), ct);
        return HandleResult(result);
    }

    /// <summary>Get all products of a store</summary>
    [HttpGet("{id:guid}/products")]
    public async Task<IActionResult> GetProducts(Guid id, CancellationToken ct)
    {
        var result = await Mediator.Send(new GetStoreProductsQuery(id), ct);
        return HandleResult(result);
    }
}

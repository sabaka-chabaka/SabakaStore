using MediatR;
using Microsoft.AspNetCore.Mvc;
using SabakaStore.Application.Features.Products.Queries.GetAllProducts;
using SabakaStore.Application.Features.Products.Queries.GetProduct;

namespace SabakaStore.API.Controllers;

public class ProductsController(IMediator mediator) : BaseApiController(mediator)
{
    /// <summary>Get all products</summary>
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken ct)
    {
        var result = await Mediator.Send(new GetAllProductsQuery(), ct);
        return HandleResult(result);
    }

    /// <summary>Get product by id</summary>
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken ct)
    {
        var result = await Mediator.Send(new GetProductQuery(id), ct);
        return HandleResult(result);
    }
}

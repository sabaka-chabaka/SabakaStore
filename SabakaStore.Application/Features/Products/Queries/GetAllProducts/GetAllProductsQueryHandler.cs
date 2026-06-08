using MediatR;
using SabakaStore.Application.Common.Result;
using SabakaStore.Domain.Entities;
using SabakaStore.Domain.Repositories;

namespace SabakaStore.Application.Features.Products.Queries.GetAllProducts;

public class GetAllProductsQueryHandler(IProductRepository productRepository)
    : IRequestHandler<GetAllProductsQuery, Result<List<Product>>>
{
    public async Task<Result<List<Product>>> Handle(GetAllProductsQuery request, CancellationToken ct)
    {
        var products = await productRepository.GetAllAsync();
        return products;
    }
}

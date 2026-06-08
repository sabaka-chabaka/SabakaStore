using MediatR;
using SabakaStore.Application.Common.Errors;
using SabakaStore.Application.Common.Result;
using SabakaStore.Domain.Entities;
using SabakaStore.Domain.Repositories;

namespace SabakaStore.Application.Features.Products.Queries.GetProduct;

public class GetProductQueryHandler(IProductRepository productRepository)
    : IRequestHandler<GetProductQuery, Result<Product>>
{
    public async Task<Result<Product>> Handle(GetProductQuery request, CancellationToken ct)
    {
        var product = await productRepository.GetByIdAsync(request.ProductId);
        if (product is null)
            return ProductErrors.NotFound;

        return product;
    }
}

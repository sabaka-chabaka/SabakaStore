using MediatR;
using SabakaStore.Application.Common.Errors;
using SabakaStore.Application.Common.Result;
using SabakaStore.Domain.Entities;
using SabakaStore.Domain.Repositories;

namespace SabakaStore.Application.Features.Stores.Queries.GetStoreProducts;

public class GetStoreProductsQueryHandler(IStoreRepository storeRepository)
    : IRequestHandler<GetStoreProductsQuery, Result<List<Product>>>
{
    public async Task<Result<List<Product>>> Handle(GetStoreProductsQuery request, CancellationToken ct)
    {
        var store = await storeRepository.GetByIdAsync(request.StoreId);
        if (store is null)
            return StoreErrors.NotFound;

        var products = await storeRepository.GetAllProductsAsync(request.StoreId);
        return products;
    }
}

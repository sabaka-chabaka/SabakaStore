using MediatR;
using SabakaStore.Application.Common.Errors;
using SabakaStore.Application.Common.Result;
using SabakaStore.Domain.Entities;
using SabakaStore.Domain.Repositories;

namespace SabakaStore.Application.Features.Stores.Queries.GetStore;

public class GetStoreQueryHandler(IStoreRepository storeRepository)
    : IRequestHandler<GetStoreQuery, Result<Store>>
{
    public async Task<Result<Store>> Handle(GetStoreQuery request, CancellationToken ct)
    {
        var store = await storeRepository.GetByIdAsync(request.StoreId);
        if (store is null)
            return StoreErrors.NotFound;

        return store;
    }
}

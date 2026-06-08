using MediatR;
using SabakaStore.Application.Common.Result;
using SabakaStore.Domain.Entities;
using SabakaStore.Domain.Repositories;

namespace SabakaStore.Application.Features.Stores.Queries.GetAllStores;

public class GetAllStoresQueryHandler(IStoreRepository storeRepository)
    : IRequestHandler<GetAllStoresQuery, Result<List<Store>>>
{
    public async Task<Result<List<Store>>> Handle(GetAllStoresQuery request, CancellationToken ct)
    {
        var stores = await storeRepository.GetAllAsync();
        return stores;
    }
}

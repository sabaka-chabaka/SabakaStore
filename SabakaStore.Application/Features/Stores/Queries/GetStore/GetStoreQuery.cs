using MediatR;
using SabakaStore.Application.Common.Result;
using SabakaStore.Domain.Entities;

namespace SabakaStore.Application.Features.Stores.Queries.GetStore;

public record GetStoreQuery(Guid StoreId) : IRequest<Result<Store>>;

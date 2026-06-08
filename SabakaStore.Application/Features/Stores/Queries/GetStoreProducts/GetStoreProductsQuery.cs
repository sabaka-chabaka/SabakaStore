using MediatR;
using SabakaStore.Application.Common.Result;
using SabakaStore.Domain.Entities;

namespace SabakaStore.Application.Features.Stores.Queries.GetStoreProducts;

public record GetStoreProductsQuery(Guid StoreId) : IRequest<Result<List<Product>>>;

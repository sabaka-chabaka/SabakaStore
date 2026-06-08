using MediatR;
using SabakaStore.Application.Common.Result;
using SabakaStore.Domain.Entities;

namespace SabakaStore.Application.Features.Stores.Queries.GetAllStores;

public record GetAllStoresQuery : IRequest<Result<List<Store>>>;

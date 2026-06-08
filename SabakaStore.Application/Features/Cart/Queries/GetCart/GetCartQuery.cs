using MediatR;
using SabakaStore.Application.Common.Result;
using SabakaStore.Domain.Entities;

namespace SabakaStore.Application.Features.Cart.Queries.GetCart;

public record GetCartQuery(Guid UserId) : IRequest<Result<Domain.Entities.Cart>>;

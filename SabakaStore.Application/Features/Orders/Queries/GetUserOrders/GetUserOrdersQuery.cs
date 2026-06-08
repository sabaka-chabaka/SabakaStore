using MediatR;
using SabakaStore.Application.Common.Result;
using SabakaStore.Domain.Entities;

namespace SabakaStore.Application.Features.Orders.Queries.GetUserOrders;

public record GetUserOrdersQuery(Guid UserId) : IRequest<Result<Order>>;

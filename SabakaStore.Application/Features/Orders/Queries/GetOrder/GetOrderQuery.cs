using MediatR;
using SabakaStore.Application.Common.Result;
using SabakaStore.Domain.Entities;

namespace SabakaStore.Application.Features.Orders.Queries.GetOrder;

public record GetOrderQuery(Guid OrderId) : IRequest<Result<Order>>;

using MediatR;
using SabakaStore.Application.Common.Result;
using SabakaStore.Domain.Entities;

namespace SabakaStore.Application.Features.Orders.Queries.GetAllOrders;

public record GetAllOrdersQuery : IRequest<Result<List<Order>>>;

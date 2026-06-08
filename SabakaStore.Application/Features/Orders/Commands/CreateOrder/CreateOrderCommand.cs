using MediatR;
using SabakaStore.Application.Common.Result;

namespace SabakaStore.Application.Features.Orders.Commands.CreateOrder;

public record CreateOrderCommand(Guid UserId) : IRequest<Result<Guid>>;

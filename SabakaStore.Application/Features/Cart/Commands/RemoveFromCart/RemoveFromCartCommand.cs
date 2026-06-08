using MediatR;
using SabakaStore.Application.Common.Result;

namespace SabakaStore.Application.Features.Cart.Commands.RemoveFromCart;

public record RemoveFromCartCommand(Guid UserId, Guid ProductId) : IRequest<Result>;

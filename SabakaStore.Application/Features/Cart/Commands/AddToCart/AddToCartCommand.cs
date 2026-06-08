using MediatR;
using SabakaStore.Application.Common.Result;

namespace SabakaStore.Application.Features.Cart.Commands.AddToCart;

public record AddToCartCommand(Guid UserId, Guid ProductId) : IRequest<Result>;

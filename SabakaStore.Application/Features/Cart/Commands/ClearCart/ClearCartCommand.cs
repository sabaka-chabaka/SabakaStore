using MediatR;
using SabakaStore.Application.Common.Result;

namespace SabakaStore.Application.Features.Cart.Commands.ClearCart;

public record ClearCartCommand(Guid UserId) : IRequest<Result>;

using MediatR;
using SabakaStore.Application.Common.Result;

namespace SabakaStore.Application.Features.Auth.Commands.Login;

public record LoginCommand(
    string Email,
    string Password) : IRequest<Result<string>>;

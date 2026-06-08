using MediatR;
using SabakaStore.Application.Common.Result;

namespace SabakaStore.Application.Features.Auth.Commands.Register;

public record RegisterCommand(
    string Name,
    string Email,
    string Password) : IRequest<Result<string>>;

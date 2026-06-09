using MediatR;
using Microsoft.AspNetCore.Mvc;
using SabakaStore.Application.Features.Auth.Commands.Login;
using SabakaStore.Application.Features.Auth.Commands.Register;

namespace SabakaStore.API.Controllers;

public class AuthController(IMediator mediator) : BaseApiController(mediator)
{
    /// <summary>Register a new user</summary>
    [HttpPost("register")]
    public async Task<IActionResult> Register(
        [FromBody] RegisterCommand command,
        CancellationToken ct)
    {
        var result = await Mediator.Send(command, ct);
        return HandleResult(result);
    }

    /// <summary>Login and receive JWT token</summary>
    [HttpPost("login")]
    public async Task<IActionResult> Login(
        [FromBody] LoginCommand command,
        CancellationToken ct)
    {
        var result = await Mediator.Send(command, ct);
        return HandleResult(result);
    }
}

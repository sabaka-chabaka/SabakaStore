using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SabakaStore.Application.Features.Users.Queries.GetUser;

namespace SabakaStore.API.Controllers;

[Authorize]
public class UsersController(IMediator mediator) : BaseApiController(mediator)
{
    /// <summary>Get current user profile</summary>
    [HttpGet("me")]
    public async Task<IActionResult> GetMe(CancellationToken ct)
    {
        var result = await Mediator.Send(new GetUserQuery(CurrentUserId), ct);
        return HandleResult(result);
    }

    /// <summary>Get user by id</summary>
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken ct)
    {
        var result = await Mediator.Send(new GetUserQuery(id), ct);
        return HandleResult(result);
    }
}

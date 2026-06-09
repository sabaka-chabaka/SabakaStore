using MediatR;
using Microsoft.AspNetCore.Mvc;
using SabakaStore.Application.Common.Result;

namespace SabakaStore.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public abstract class BaseApiController(IMediator mediator) : ControllerBase
{
    protected readonly IMediator Mediator = mediator;

    protected IActionResult HandleResult<T>(Result<T> result)
    {
        if (result.IsSuccess)
            return Ok(result.Value);

        return result.Error!.Code switch
        {
            var c when c.EndsWith("NotFound") => NotFound(result.Error),
            var c when c.EndsWith("InvalidCredentials") => Unauthorized(result.Error),
            var c when c.EndsWith("AlreadyExists") => Conflict(result.Error),
            _ => BadRequest(result.Error)
        };
    }

    protected IActionResult HandleResult(Result result)
    {
        if (result.IsSuccess)
            return NoContent();

        return result.Error!.Code switch
        {
            var c when c.EndsWith("NotFound") => NotFound(result.Error),
            _ => BadRequest(result.Error)
        };
    }

    protected Guid CurrentUserId =>
        Guid.Parse(User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)!.Value);
}

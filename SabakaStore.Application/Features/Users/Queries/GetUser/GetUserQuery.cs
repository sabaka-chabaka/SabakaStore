using MediatR;
using SabakaStore.Application.Common.Result;
using SabakaStore.Domain.Entities;

namespace SabakaStore.Application.Features.Users.Queries.GetUser;

public record GetUserQuery(Guid UserId) : IRequest<Result<User>>;

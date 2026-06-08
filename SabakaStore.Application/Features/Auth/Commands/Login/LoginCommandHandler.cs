using MediatR;
using SabakaStore.Application.Common.Errors;
using SabakaStore.Application.Common.Interfaces;
using SabakaStore.Application.Common.Result;
using SabakaStore.Domain.Repositories;

namespace SabakaStore.Application.Features.Auth.Commands.Login;

public class LoginCommandHandler(
    IUserRepository userRepository,
    IPasswordHasher passwordHasher,
    IJwtProvider jwtProvider) : IRequestHandler<LoginCommand, Result<string>>
{
    public async Task<Result<string>> Handle(LoginCommand request, CancellationToken ct)
    {
        var user = await userRepository.GetByEmailAsync(request.Email, ct);
        if (user is null)
            return UserErrors.InvalidCredentials;

        if (!passwordHasher.Verify(request.Password, user.PasswordHash))
            return UserErrors.InvalidCredentials;

        return jwtProvider.Generate(user);
    }
}

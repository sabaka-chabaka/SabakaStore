using SabakaStore.Domain.Entities;

namespace SabakaStore.Application.Common.Interfaces;

public interface IJwtProvider
{
    string Generate(User user);
}

using SabakaStore.Domain.Entities;

namespace SabakaStore.Domain.Repositories;

public interface ICartRepository : IRepository<Cart>
{
    Task<Cart?> GetByUserIdAsync(Guid userId);
}
using SabakaStore.Domain.Entities;

namespace SabakaStore.Domain.Repositories;

public interface IOrderRepository : IRepository<Order>
{
    Task<Order?> GetByUserIdAsync(Guid userId);
    Task<Order?> GetByIdAsync(Guid id);
    Task<List<Order>> GetAllAsync();
}
using SabakaStore.Domain.Entities;

namespace SabakaStore.Domain.Repositories;

public interface IStoreRepository
{
    Task<List<Store>> GetAllAsync();
    Task<Store?> GetByIdAsync(Guid id);
    Task<List<Product>> GetAllProductsAsync(Guid id);
}
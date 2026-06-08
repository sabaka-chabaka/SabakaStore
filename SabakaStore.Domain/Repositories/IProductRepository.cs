using SabakaStore.Domain.Entities;

namespace SabakaStore.Domain.Repositories;

public interface IProductRepository : IRepository<Product>
{
    Task<Product?> GetByIdAsync(Guid id);
    Task<List<Product>> GetAllAsync();
}
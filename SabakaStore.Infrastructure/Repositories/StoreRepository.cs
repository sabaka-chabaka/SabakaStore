using Microsoft.EntityFrameworkCore;
using SabakaStore.Domain.Entities;
using SabakaStore.Domain.Repositories;
using SabakaStore.Infrastructure.Persistence;

namespace SabakaStore.Infrastructure.Repositories;

public class StoreRepository(AppDbContext db) : IStoreRepository
{
    private readonly DbSet<Store> _set = db.Set<Store>();

    public async Task<List<Store>> GetAllAsync() =>
        await _set
            .AsNoTracking()
            .ToListAsync();

    public async Task<Store?> GetByIdAsync(Guid id) =>
        await _set
            .Include(s => s.ProductsId)
            .FirstOrDefaultAsync(s => s.Id == id);

    public async Task<List<Product>> GetAllProductsAsync(Guid id) =>
        await _set
            .Where(s => s.Id == id)
            .SelectMany(s => s.ProductsId)
            .AsNoTracking()
            .ToListAsync();
}

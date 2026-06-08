using Microsoft.EntityFrameworkCore;
using SabakaStore.Domain.Entities;
using SabakaStore.Domain.Repositories;
using SabakaStore.Infrastructure.Persistence;

namespace SabakaStore.Infrastructure.Repositories;

public class ProductRepository(AppDbContext db) : BaseRepository<Product>(db), IProductRepository
{
    public async Task<Product?> GetByIdAsync(Guid id) =>
        await Set
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == id);

    public async Task<List<Product>> GetAllAsync() =>
        await Set
            .AsNoTracking()
            .ToListAsync();
}

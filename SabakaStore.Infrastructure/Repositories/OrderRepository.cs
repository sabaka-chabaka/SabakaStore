using Microsoft.EntityFrameworkCore;
using SabakaStore.Domain.Entities;
using SabakaStore.Domain.Repositories;
using SabakaStore.Infrastructure.Persistence;

namespace SabakaStore.Infrastructure.Repositories;

public class OrderRepository(AppDbContext db) : BaseRepository<Order>(db), IOrderRepository
{
    public async Task<Order?> GetByUserIdAsync(Guid userId) =>
        await Set
            .Include(o => o.Products)
            .FirstOrDefaultAsync(o => o.UserId == userId);

    public async Task<Order?> GetByIdAsync(Guid id) =>
        await Set
            .Include(o => o.Products)
            .FirstOrDefaultAsync(o => o.Id == id);

    public async Task<List<Order>> GetAllAsync() =>
        await Set
            .Include(o => o.Products)
            .AsNoTracking()
            .ToListAsync();
}

using Microsoft.EntityFrameworkCore;
using SabakaStore.Domain.Entities;
using SabakaStore.Domain.Repositories;
using SabakaStore.Infrastructure.Persistence;

namespace SabakaStore.Infrastructure.Repositories;

public class CartRepository(AppDbContext db) : BaseRepository<Cart>(db), ICartRepository
{
    public async Task<Cart?> GetByUserIdAsync(Guid userId) =>
        await Set
            .Include(c => c.ProductsId)
            .FirstOrDefaultAsync(c => c.UserId == userId);
}

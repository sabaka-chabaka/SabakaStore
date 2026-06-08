using Microsoft.EntityFrameworkCore;
using SabakaStore.Domain.Entities;
using SabakaStore.Domain.Repositories;
using SabakaStore.Infrastructure.Persistence;

namespace SabakaStore.Infrastructure.Repositories;

public class UserRepository(AppDbContext db) : BaseRepository<User>(db), IUserRepository
{
    public async Task<User?> GetByEmailAsync(string email, CancellationToken ct = default) =>
        await Set
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Email == email, ct);

    public async Task<bool> ExistsByEmailAsync(string email, CancellationToken ct = default) =>
        await Set.AnyAsync(u => u.Email == email, ct);
}

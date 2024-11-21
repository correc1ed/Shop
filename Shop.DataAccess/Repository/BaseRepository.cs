using Microsoft.EntityFrameworkCore;
using Shop.Abstractions.Repository;

namespace Shop.DataAccess.Repository;
public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
{
    protected readonly EfContext _context;

    public BaseRepository(EfContext context)
    {
        _context = context;
    }

    public DbSet<TEntity> Entities => _context.Set<TEntity>();

    public async Task<IEnumerable<TEntity>> GetAllAsync()
        => await Entities.ToListAsync();

    public async Task<TEntity?> GetByIdAsync(Guid id)
        => await Entities.FindAsync(id);

    public async Task AddAsync(TEntity entity)
    {
        await Entities.AddAsync(entity);
        await SaveChangesAsync();
    }

    public async Task UpdateAsync(TEntity entity)
    {
        Entities.Update(entity);
        await SaveChangesAsync();
    }

    public async Task RemoveAsync(TEntity entity)
    {
        Entities.Remove(entity);
        await SaveChangesAsync();
    }

    protected async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}

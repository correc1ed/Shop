using Microsoft.EntityFrameworkCore;

namespace Shop.Abstractions.Repository;
public interface IBaseRepository<TEntity> where TEntity : class
{
    DbSet<TEntity> Entities { get; }

    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<TEntity?> GetByIdAsync(Guid id);
    Task AddAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task RemoveAsync(TEntity entity);
}

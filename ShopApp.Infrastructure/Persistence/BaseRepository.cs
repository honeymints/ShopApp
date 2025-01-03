using Microsoft.EntityFrameworkCore;
using ShopApp.Domain.Common;
using ShopApp.Infrastructure.Persistence.Common;

namespace ShopApp.Infrastructure.Persistence;

public abstract class BaseRepository<T> where T : BaseEntity
{
    protected readonly AppDbContext _context;

    public BaseRepository(AppDbContext context)
    {
        _context = context;
    }

    public virtual async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }

    public virtual async Task InsertAsync(T entity)
    {
        entity.CreateDate = DateTime.UtcNow;
        await _context.Set<T>().AddAsync(entity);
    }

    public virtual async Task InsertRangeAsync(ICollection<T> entities)
    {
        entities.ToList().ForEach(e => e.CreateDate = DateTime.UtcNow);

        await _context.Set<T>().AddRangeAsync(entities);
    }

    public virtual async Task<T?> Get(Guid id)
    {
        var entity = await _context.FindAsync<T>(id);
        return entity;
    }

    public virtual async Task DeleteAsync(Guid id)
    {
        var entity = await Get(id);
        _context.Set<T>().Remove(entity);
    }

    public virtual async Task DeleteRangeAsync(Guid[] ids)
    {
        var entities = await GetAll();

        entities = entities.Where(x => ids.Contains(x.Id)).ToList();

        _context.Set<T>().RemoveRange(entities);
    }

    public virtual async Task UpdateAsync(T entity)
    {
        entity.UpdateDate = DateTime.UtcNow;
        _context.Entry(entity).State = EntityState.Modified;
    }

    public virtual async Task<IReadOnlyCollection<T>> GetAll()
    {
        var entities = await _context.Set<T>()
        .AsNoTracking()
        .ToListAsync();
        return entities;
    }

    public virtual async Task<bool> IsExists(Guid id)
    {
        return await _context.FindAsync<T>(id) != null;
    }
    public virtual async Task BeginTransaction()
    {
        _context.Database.BeginTransaction();
    }

    public virtual async Task CommitTransaction()
    {
        _context.Database.CommitTransaction();
    }

    public virtual async Task RollbackTransaction()
    {
        _context.Database.RollbackTransaction();
    }

    public async Task Dispose()
    {
        throw new NotImplementedException();
    }
}

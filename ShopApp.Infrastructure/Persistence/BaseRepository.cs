using ShopApp.Application.Persistence;
using ShopApp.Domain.Common;

namespace ShopApp.Infrastructure.Persistence;

public abstract class BaseRepository<T> where T : BaseEntity
{
    protected readonly AppDbContext _context;

    public BaseRepository(AppDbContext context)
    {
        _context = context;
    }

    public virtual void Save()
    {
        _context.SaveChanges();
    }

    public virtual void Insert(T entity)
    {
        entity.CreateDate = DateTime.UtcNow;
        _context.Set<T>().Add(entity);
    }

    public virtual T? FindById(Guid id)
    {
        return _context?.Find<T>(id);
    }

    public virtual void Delete(Guid id)
    {
        var entity = FindById(id);
        _context.Set<T>().Remove(entity);
    }
    
    public virtual void Update(T entity)
    {
        entity.UpdateDate = DateTime.UtcNow;
        _context.Set<T>().Update(entity);
    }

    public virtual void BeginTransaction()
    {
        _context.Database.BeginTransaction();
    }

    public virtual void CommitTransaction()
    {
        _context.Database.CommitTransaction();
    }

    public virtual void RollbackTransaction()
    {
        _context.Database.RollbackTransaction();
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}

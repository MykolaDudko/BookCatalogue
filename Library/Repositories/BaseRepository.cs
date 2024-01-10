using Library.Context;
using Library.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Library.Repositories;
public abstract class BaseRepository<TEntity> where TEntity : class, IEntity
{
    private readonly DbSet<TEntity> _set;
    private readonly BookContext _dbContext;
    public BaseRepository(BookContext dbContext)
    {
        _dbContext = dbContext;
        _set = _dbContext.Set<TEntity>();
    }

    public virtual async Task<int> AddAsync(TEntity entity, CancellationToken ct = default)
    {
        await _set.AddAsync(entity, cancellationToken: ct);
        await _dbContext.SaveChangesAsync(cancellationToken: ct);
        return entity.Id;
    }
    public virtual async Task<TEntity> GetAsync(IQueryable<TEntity> query, CancellationToken ct = default)
    {
        var entity = await query.FirstAsync(cancellationToken: ct);
        return entity;
    }
    public virtual async Task<List<TEntity>> GetAllAsync(CancellationToken ct = default)
    {
        var entity = await _set.AsNoTracking().ToListAsync(cancellationToken: ct);
        return entity;
    }
    public virtual async Task DeleteAsync(IQueryable<TEntity> query, CancellationToken ct = default)
    {
        var entity = await query.FirstAsync(cancellationToken: ct);
        _dbContext.Remove(entity);
        await _dbContext.SaveChangesAsync(cancellationToken: ct);
    }
    public virtual async Task UpdateAsync(TEntity entity, CancellationToken ct = default)
    {
        _set.Update(entity);
        await _dbContext.SaveChangesAsync(cancellationToken: ct);
    }

    public IQueryable<TEntity> GetEntityLinqQueryable(bool asNoTracking = true)
    {
        if (asNoTracking)
            return _set.AsNoTracking();

        return _set;
    }
}

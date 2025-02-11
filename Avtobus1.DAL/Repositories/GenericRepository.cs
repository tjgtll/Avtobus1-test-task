using Avtobus1.DAL.DataContext;
using Avtobus1.DAL.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Avtobus1.DAL.Repositories;
internal class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, new()
{
    private readonly Avtobus1DbContext _dbContext;

    public GenericRepository(Avtobus1DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        await _dbContext.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<int> DeleteAsync(TEntity entity)
    {
        _ = _dbContext.Remove(entity);
        return await _dbContext.SaveChangesAsync();
    }

    public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter = null)
    {
        return await _dbContext.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(filter);
    }

    public async Task<IQueryable<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> filter = null)
    {
        var query = filter == null
        ? _dbContext.Set<TEntity>()
              : _dbContext.Set<TEntity>().Where(filter);

        return query;
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        _ = _dbContext.Update(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }
}

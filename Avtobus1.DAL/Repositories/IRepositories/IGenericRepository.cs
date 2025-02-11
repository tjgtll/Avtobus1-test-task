using System.Linq.Expressions;

namespace Avtobus1.DAL.Repositories.IRepositories;
public interface IGenericRepository<TEntity> where TEntity : class
{
    Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter = null);
    Task<IQueryable<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> filter = null);
    Task<TEntity> AddAsync(TEntity entity);
    Task<TEntity> UpdateAsync(TEntity entity);
    Task<int> DeleteAsync(TEntity entity);
}

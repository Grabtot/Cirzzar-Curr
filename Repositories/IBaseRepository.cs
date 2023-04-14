using CirzzarCurr.Models;

namespace CirzzarCurr.Repositories
{
    public interface IBaseRepository<TEntity, TId> where TEntity : class, IEntity<TId>
    {
        Task<TEntity> AddAsync(TEntity entity);
        Task DeleteByIdAsync(TId id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(TId id);
        Task<TEntity> UpdateAsync(TEntity entity);
    }
}
using CirzzarCurr.Data;
using CirzzarCurr.Models;
using Microsoft.EntityFrameworkCore;

namespace CirzzarCurr.Repositories
{
    public abstract class BaseRepository<TEntity, TId> : IBaseRepository<TEntity, TId> where TEntity : class, IEntity<TId>
    {
        protected readonly DbSet<TEntity> _dbSet;
        protected readonly ApplicationDbContext _context;
        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync() => await _dbSet.ToListAsync();

        public virtual async Task<TEntity> GetByIdAsync(TId id) => await _dbSet.FindAsync(id)
            ?? throw new IndexOutOfRangeException();

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
            entity = _dbSet.Update(entity).Entity;
            await _context.SaveChangesAsync();
            return entity;
        }
        public virtual async Task DeleteByIdAsync(TId id)
        {
            _dbSet.Remove(await GetByIdAsync(id));
            await _context.SaveChangesAsync();
        }
    }
}
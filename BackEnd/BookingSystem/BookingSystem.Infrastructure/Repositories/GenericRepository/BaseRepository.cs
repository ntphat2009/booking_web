using BookingSystem.Domain.Entity;
using BookingSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Infrastructure.Repositories.GenericRepository
{
    public abstract class BaseRepository<T>
        where T : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        protected abstract Expression<Func<T, object>>? GetSortExpression(string sortBy);
        public async Task<IEnumerable<T>> GetsAsync<TKey>(
            int page, int pageSize,
            Expression<Func<T, TKey>>? sortBy = null,
            Expression<Func<T, bool>>? filter = null,
            params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet.AsNoTracking();
            if (filter != null) query = query.Where(filter);
            foreach (var include in includes) query = query.Include(include);
            if (sortBy != null) query = query.OrderByDescending(sortBy);
            return await query.Skip((page - 1) * pageSize)
                              .Take(pageSize)
                              .ToListAsync() ?? [];
        }
        public async Task<T?> GetAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, bool>>? filter = null, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet.AsNoTracking();
            if (filter != null) query = query.Where(filter);
            foreach (var include in includes) query = query.Include(include);
            return await query.FirstOrDefaultAsync(predicate);
        }
        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await SaveChangeAsync();
        }
        public async Task DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            await SaveChangeAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await SaveChangeAsync();
        }

        private async Task SaveChangeAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<T?> GetByIdAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, bool>>? filter = null, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet.AsNoTracking();
            if (filter != null) query = query.Where(filter);
            foreach (var include in includes) query = query.Include(include);
            return await query.FirstOrDefaultAsync(predicate);
        }
    }
}

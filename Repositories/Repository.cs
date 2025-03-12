using System.Linq.Expressions;
using GerenciamentoFinanceiro.Data;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoFinanceiro.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            return entity;
        }

        public Task<T> DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            return Task.FromResult(entity);
        }

        public Task<T> UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            return Task.FromResult(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T?> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(predicate);
        }
    }
}



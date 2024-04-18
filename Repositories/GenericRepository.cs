using RefactorBEcapstone.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace RefactorBEcapstone.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly RefactorDbContext _context;

        public GenericRepository(RefactorDbContext context) => _context = context;

        public async Task<TEntity> AddAsync(TEntity model, bool saveChanges = true)
        {
            _context.Set<TEntity>().Add(model);
            if (saveChanges)
                await _context.SaveChangesAsync();
            return model;
        }

        public async Task<TEntity?> GetByIdAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
        {
            var query = _context.Set<TEntity>().AsQueryable();

            if (include != null)
            {
                query = include(query);
            }

            return await query.FirstOrDefaultAsync(filter);
        }

        public async Task<TEntity> Update(TEntity model, bool saveChanges = true)
        {
            _context.Entry(model).State = EntityState.Modified;
            if (saveChanges)
            {
                await _context.SaveChangesAsync();
            }
            return model;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
        {
            return await Task.Run(() => {
                var query = _context.Set<TEntity>().AsQueryable();

                if (include != null)
                {
                    query = include(query);
                }

                return query.ToList();
            });
        }

    }
}

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
    }
}

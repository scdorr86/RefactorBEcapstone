using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace RefactorBEcapstone.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<TEntity> AddAsync(TEntity model, bool saveChanges = true);
        Task<TEntity> Update(TEntity objModel, bool saveChanges = true);

        Task<TEntity> GetByIdAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null);
        Task<IEnumerable<TEntity>> GetAllAsync(Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null);

        Task<TEntity> SoftDelete(TEntity objModel);
    }
}

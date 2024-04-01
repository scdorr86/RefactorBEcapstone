namespace RefactorBEcapstone.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<TEntity> AddAsync(TEntity model, bool saveChanges = true);

    }
}

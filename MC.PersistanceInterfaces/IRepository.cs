namespace MC.PersistanceInterfaces
{
    public interface IRepository<TEntity, TKey>
    {
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(TKey id);
        Task<TEntity> AddAsync(TEntity movie);
        Task<TEntity> UpdateAsync(TEntity movie);
        Task DeleteAsync(TKey id);
    }
}

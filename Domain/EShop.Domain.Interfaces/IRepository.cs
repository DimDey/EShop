namespace EShop.Domain.Interfaces
{
    public interface IRepository <TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAll();
        
        Task Add(TEntity entity);
        Task Delete(TEntity entity);
        Task Update(TEntity entity);
        Task<TEntity?> Get(int id);
        // TODO: REFACTOR TO ASYNC METHOD
        IEnumerable<TEntity> Get(Func<TEntity, bool> predicate);

    }
}

using System.Linq.Expressions;

namespace EShop.Domain.Interfaces
{
    public interface IRepository <TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAll();
        
        Task Add(TEntity entity);
        Task Delete(TEntity entity);
        Task Update(TEntity entity);
        Task<TEntity?> Get(int id);
        Task<TEntity?> Get(Expression<Func<TEntity, bool>> predicate);

    }
}

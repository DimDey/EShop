using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Infrastructure.Repository
{
    public interface IRepository <TEntity> where TEntity : class
    {
        IEnumerable<TEntity> All { get; }
        Task Add(TEntity entity);
        Task Delete(TEntity entity);
        Task Update(TEntity entity);
        Task<TEntity> Get(int id);

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.Talabat.Core.Domain.Contracts.Persistance
{
    public interface IGenericRepository<TEntity, Tkey>
        where TEntity : BaseEntity<Tkey>
        where Tkey : IEquatable<Tkey>
    {

        Task<IReadOnlyList<TEntity>> GetAllAsync(bool withTracking = false);
        Task<IReadOnlyList<TEntity>> GetAllWithSpecAsync(ISpecifications<TEntity,Tkey> specifications, bool withTracking = false);
      
        Task<TEntity?> GetAsync(Tkey id);
        Task<TEntity?> GetWithSpecAsync(ISpecifications<TEntity, Tkey> spec);
        Task<int> GetCountAsync(ISpecifications<TEntity, Tkey> specifications);

        Task AddAsync(TEntity entity);
        void UpdateAsync(TEntity entity);
        void DeleteAsync(TEntity entity);



    }
}

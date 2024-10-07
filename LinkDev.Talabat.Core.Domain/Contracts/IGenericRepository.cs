using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.Talabat.Core.Domain.Contracts
{
	public interface IGenericRepository<TEntity,Tkey> 
		where TEntity : BaseEnitity<Tkey>
		where Tkey : IEquatable<Tkey>
		{

		Task<IEnumerable<TEntity>> GetAllAsync(bool withTracking=false);

		Task<TEntity?> GetAsync(Tkey id);

		Task AddAsync(TEntity entity);
		void UpdateAsync(TEntity entity);
		void DeleteAsync(TEntity entity);
	
	
	
		}
}

using LinkDev.Talabat.Core.Domain.Comman;
using LinkDev.Talabat.Core.Domain.Contracts.Persistance;
using LinkDev.Talabat.Infrastructure.Peresistance.Data;
using LinkDev.Talabat.Infrastrucutre.Infrastructure.Date;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.Talabat.Infrastructure.Peresistance.Repositries
{
    internal class GenericRepo<TEnitity, Tkey>(StoreContext storeContext) : IGenericRepository<TEnitity, Tkey>
		where TEnitity : BaseAuditableEntitiy<Tkey>
		where Tkey : IEquatable<Tkey>
	{
		public async Task<IEnumerable<TEnitity>> GetAllAsync(bool withTracking = false)
		=> withTracking ? await storeContext.Set<TEnitity>().AsNoTracking().ToListAsync():
					      await storeContext.Set<TEnitity>().ToListAsync();

		public async Task<TEnitity?> GetAsync(Tkey id)
		=> await storeContext.Set<TEnitity>().FindAsync(id);
		public async Task AddAsync(TEnitity entity)
		=> await storeContext.Set<TEnitity>().AddAsync(entity);


		public void UpdateAsync(TEnitity entity)
				=> storeContext.Set<TEnitity>().Update(entity);

		public void DeleteAsync(TEnitity entity)
				=>  storeContext.Set<TEnitity>().Remove(entity);

	}
}

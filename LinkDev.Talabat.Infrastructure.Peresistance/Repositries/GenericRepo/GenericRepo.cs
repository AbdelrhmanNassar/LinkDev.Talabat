using LinkDev.Talabat.Core.Domain.Comman;
using LinkDev.Talabat.Core.Domain.Contracts;
using LinkDev.Talabat.Core.Domain.Contracts.Persistance;
using LinkDev.Talabat.Core.Domain.Enities.Product;
using LinkDev.Talabat.Infrastrucutre.Infrastructure._Data;
using Microsoft.EntityFrameworkCore;

namespace LinkDev.Talabat.Infrastructure.Peresistance.Repositries.GenericRepo
{
	internal class GenericRepo<TEnitity, Tkey>(StoreDbContext storeContext) : IGenericRepository<TEnitity, Tkey>
        where TEnitity : BaseEntity<Tkey>
        where Tkey : IEquatable<Tkey>
    {
        public async Task<IReadOnlyList<TEnitity>> GetAllAsync(bool withTracking = false)
        {
            if (typeof(TEnitity) == typeof(Product))// not achive  open closed principle (specification design pattern To Solve this Problem)
            {
                // If TEntity is Product, include related entities
                return withTracking
                        ? (IReadOnlyList<TEnitity>)await storeContext.Set<Product>().Include(p => p.ProductBrand).Include(p => p.ProductCategory).ToListAsync()
                        : (IReadOnlyList<TEnitity>)await storeContext.Set<Product>().AsNoTracking().Include(p => p.ProductBrand).Include(p => p.ProductCategory).ToListAsync();
            }

            // For all other TEntity types
            return withTracking
                ? await storeContext.Set<TEnitity>().ToListAsync()
                : await storeContext.Set<TEnitity>().AsNoTracking().ToListAsync();
        }
        public async Task<TEnitity?> GetAsync(Tkey id)
		{

            if (typeof(TEnitity) == typeof(Product))// not achive open closed principle(specification design pattern To Solve this Problem)
  
				return await storeContext.Set<Product>().Where(p => p.Id.Equals(id)).Include(p => p.ProductBrand).Include(p => p.ProductCategory).FirstOrDefaultAsync(P => P.Id.Equals(id)) as TEnitity;

            return await storeContext.Set<TEnitity>().Where(p => p.Id.Equals(id)).FirstOrDefaultAsync(P => P.Id.Equals(id));
        }
        public async Task AddAsync(TEnitity entity)
        => await storeContext.Set<TEnitity>().AddAsync(entity);


        public void UpdateAsync(TEnitity entity)
                => storeContext.Set<TEnitity>().Update(entity);

        public void DeleteAsync(TEnitity entity)
                => storeContext.Set<TEnitity>().Remove(entity);

		public async Task<IReadOnlyList<TEnitity>> GetAllWithSpecAsync(ISpecifications<TEnitity, Tkey> specifications , bool withTracking = false)
		{
			return await SpecificationsEvaluator<TEnitity,Tkey>.GetQuery(storeContext.Set<TEnitity>(), specifications).ToListAsync();
		}

		public async Task<TEnitity?> GetWithSpecAsync(ISpecifications<TEnitity, Tkey> spec)
		{
			return await SpecificationsEvaluator<TEnitity, Tkey>.GetQuery(storeContext.Set<TEnitity>(), spec).FirstOrDefaultAsync()
				 ;
		}

		public async Task<int> GetCountAsync(ISpecifications<TEnitity, Tkey> specifications)
		{
			 return await SpecificationsEvaluator<TEnitity, Tkey>.GetQuery(storeContext.Set<TEnitity>(), specifications).CountAsync();
		}

      
    }
}

﻿using LinkDev.Talabat.Core.Domain.Comman;
using LinkDev.Talabat.Core.Domain.Contracts.Persistance;
using LinkDev.Talabat.Core.Domain.Enities.Product;
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
		{
			if (typeof(TEnitity) == typeof(Product))
			{
				// If TEntity is Product, include related entities
			return	 withTracking
					? (IEnumerable<TEnitity>) await storeContext.Set<Product>().Include(p => p.ProductBrand).Include(p => p.ProductCategory).ToListAsync()
					: (IEnumerable<TEnitity>)await storeContext.Set<Product>().AsNoTracking().Include(p => p.ProductBrand).Include(p => p.ProductCategory).ToListAsync();
			}

			// For all other TEntity types
			return withTracking
				? await storeContext.Set<TEnitity>().ToListAsync()
				: await storeContext.Set<TEnitity>().AsNoTracking().ToListAsync();
		}
		public async Task<TEnitity?> GetAsync(Tkey id)
		{
			if (typeof(TEnitity) == typeof(Product))
			
				return await storeContext.Set<Product>().Include(p => p.ProductBrand).Include(p => p.ProductCategory).FirstOrDefaultAsync(P=>P.Id.Equals( id )) as TEnitity;

			return  await storeContext.Set<TEnitity>().FirstOrDefaultAsync(P => P.Id.Equals(id));
		}
		public async Task AddAsync(TEnitity entity)
		=> await storeContext.Set<TEnitity>().AddAsync(entity);


		public void UpdateAsync(TEnitity entity)
				=> storeContext.Set<TEnitity>().Update(entity);

		public void DeleteAsync(TEnitity entity)
				=>  storeContext.Set<TEnitity>().Remove(entity);

	}
}

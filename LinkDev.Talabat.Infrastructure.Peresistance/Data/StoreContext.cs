using LinkDev.Talabat.Core.Domain.Comman;
using LinkDev.Talabat.Core.Domain.Enities.Product;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.Talabat.Infrastrucutre.Infrastructure.Date
{
	public class StoreContext :DbContext
	{
      public DbSet<Product> Products { get; set; }
      public DbSet<ProductBrand> Brands { get; set; }
      public DbSet<ProductCategory> Categories { get; set; }

        public StoreContext(DbContextOptions options ):base(options)
        {
            
        }
	
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());//i prefer this
		///	modelBuilder.ApplyConfigurationsFromAssembly(typeof(StoreContext).Assembly);
		}

		public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
		{
		//	//other implemention or condition
		//	#region Implemention 1 i don't like it because i think the performance will not be good
		//	foreach (var entry in this.ChangeTracker.Entries<BaseAuditableEntitiy<int>>()
		//			.Where(entry => entry.State is EntityState.Added or EntityState.Modified)
		//			)
		//	{
		//		if (entry is { State: EntityState.Modified or EntityState.Added })
		//		{


		//			if (entry.State == EntityState.Added)
		//			{
		//				entry.Entity.CreatedBy = "";
		//				entry.Entity.CreatedOn = DateTime.UtcNow;
		//			}
		//			entry.Entity.LastModifiedBy = "";
		//			entry.Entity.LastModifiedOn = DateTime.UtcNow;
		//		}
		//	}
		//	#endregion
		//	#region This is A better impelemention as i think
		//	foreach (var entry in this.ChangeTracker.Entries<BaseAuditableEntitiy<int>>())
		//	{
		//		if (entry is { State: EntityState.Modified or EntityState.Added })
		//		{


		//			if (entry.State == EntityState.Added)
		//			{
		//				entry.Entity.CreatedBy = "";
		//				entry.Entity.CreatedOn = DateTime.UtcNow;
		//			}
		//			entry.Entity.LastModifiedBy = "";
		//			entry.Entity.LastModifiedOn = DateTime.UtcNow;
		//		}
		//	} 
	

		//	#endregion
			return base.SaveChangesAsync(cancellationToken);
		}
	}
}

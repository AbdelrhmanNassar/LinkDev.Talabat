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
	}
}

using LinkDev.Talabat.Core.Domain.Contracts.Persistance.DbInitializers;
using LinkDev.Talabat.Core.Domain.Enities.Product;
using LinkDev.Talabat.Infrastructure.Peresistance._Common;
using LinkDev.Talabat.Infrastrucutre.Infrastructure._Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LinkDev.Talabat.Infrastructure.Peresistance._Date
{
    internal sealed class StoreDbContextInitialzer(StoreDbContext context) : DbContextInitializer(context),IStoreContextInitialzer
	{
	

		public override async Task SeedAsync()
		{
			if (!context.Brands.Any())
			{
				var brandsInJson = await File.ReadAllTextAsync("../LinkDev.Talabat.Infrastructure.Peresistance/Data/Seeds/brands.json");

				var listOfBrands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsInJson);

				if (listOfBrands != null && listOfBrands.Count > 0)
				{

					await context.Brands.AddRangeAsync(listOfBrands);


					context.SaveChanges();



				}
			}

			if (!context.Categories.Any())
			{
				var categorysInJson = await File.ReadAllTextAsync("../LinkDev.Talabat.Infrastructure.Peresistance/Data/Seeds/categories.json");

				var listOfCategories = JsonSerializer.Deserialize<List<ProductCategory>>(categorysInJson);

				if (listOfCategories != null && listOfCategories.Count > 0)
				{

					await context.Categories.AddRangeAsync(listOfCategories);


					context.SaveChanges();



				}
			}
			if (!context.Products.Any())
			{
				var productsInJson = await File.ReadAllTextAsync("../LinkDev.Talabat.Infrastructure.Peresistance/Data/Seeds/products.json");

				var listOfProducts = JsonSerializer.Deserialize<List<Product>>(productsInJson);

				if (listOfProducts != null && listOfProducts.Count > 0)
				{

					await context.Products.AddRangeAsync(listOfProducts);


					context.SaveChanges();



				}
			}
		}
	}
}

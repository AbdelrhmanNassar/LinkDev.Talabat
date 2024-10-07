using LinkDev.Talabat.Core.Domain.Enities.Product;
using LinkDev.Talabat.Infrastrucutre.Infrastructure.Date;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LinkDev.Talabat.Infrastructure.Peresistance.Data
{
	public static class StoreDbContextSeed
	{
		public static async Task Seed(StoreContext storeContext)
		{
			if (!storeContext.Brands.Any()) {
				var brandsInJson = await File.ReadAllTextAsync("../LinkDev.Talabat.Infrastructure.Peresistance/Data/Seeds/brands.json");

				var listOfBrands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsInJson);

				if (listOfBrands != null && listOfBrands.Count > 0) {
				
					await	storeContext.Brands.AddRangeAsync(listOfBrands);

			
					storeContext.SaveChanges();



				}
			}

			if (!storeContext.Categories.Any()) {
				var categorysInJson = await File.ReadAllTextAsync("../LinkDev.Talabat.Infrastructure.Peresistance/Data/Seeds/categories.json");

				var listOfCategories = JsonSerializer.Deserialize<List<ProductCategory>>(categorysInJson);

				if (listOfCategories != null && listOfCategories.Count > 0) {
				
					await	storeContext.Categories.AddRangeAsync(listOfCategories);

			
					storeContext.SaveChanges();



				}
			}
			if (!storeContext.Products.Any()) {
				var	productsInJson = await File.ReadAllTextAsync("../LinkDev.Talabat.Infrastructure.Peresistance/Data/Seeds/products.json");

				var listOfProducts = JsonSerializer.Deserialize<List<Product>>(productsInJson);

				if (listOfProducts != null && listOfProducts.Count > 0) {
				
					await	storeContext.Products.AddRangeAsync(listOfProducts);

			
					storeContext.SaveChanges();



				}
			}

		}
	}
}

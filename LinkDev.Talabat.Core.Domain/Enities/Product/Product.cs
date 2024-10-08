namespace LinkDev.Talabat.Core.Domain.Enities.Product
{
	public class Product :BaseAuditableEntitiy<int>
	{
        public required string Name { get; set; }

		public required string Description { get; set; }

        public string? PictureUrl { get; set; }

		public decimal Price { get; set; }


		public int? BrandId { get; set; }//FK of Brand i will configure also it in congirutions because the  name
		public virtual ProductBrand? ProductBrand { get; set; }
		
		public int? CategoryId { get; set; }//FK of Category i will configure also it in congirutions because the  name
		public virtual ProductCategory? ProductCategory { get; set; }

    }
}

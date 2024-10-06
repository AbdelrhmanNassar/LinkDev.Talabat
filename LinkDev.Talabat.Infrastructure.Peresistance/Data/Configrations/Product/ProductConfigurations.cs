using LinkDev.Talabat.Infrastructure.Peresistance.Data.Configrations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LinkDev.Talabat.Infrastructure.Peresistance.Data.Configrations.Product
{
	public class ProductConfigurations : BaseEnitityConfigurations<LinkDev.Talabat.Core.Domain.Enities.Product.Product,int>
	{
		public override void Configure(EntityTypeBuilder<LinkDev.Talabat.Core.Domain.Enities.Product.Product> builder)
		{
			base.Configure(builder);
			builder.Property(P => P.Name)
				.IsRequired()
				.HasMaxLength(50);

			builder.Property(P => P.Description)
				.IsRequired()
				;

			builder.Property(P => P.Price)
				.IsRequired()
				.HasColumnType("decimal(9,2)");

			builder.HasOne(P => P.ProductBrand)
				.WithMany().
				HasForeignKey(P => P.BrandId).
				OnDelete(DeleteBehavior.SetNull);
			
			builder.HasOne(P => P.ProductCategory)
				.WithMany().
				HasForeignKey(P => P.CategoryId).
				OnDelete(DeleteBehavior.SetNull);
		}
	}
}

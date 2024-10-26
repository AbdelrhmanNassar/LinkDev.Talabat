using LinkDev.Talabat.Core.Domain.Comman;
using LinkDev.Talabat.Core.Domain.Enities.Product;
using LinkDev.Talabat.Infrastructure.Peresistance._Common;
using LinkDev.Talabat.Infrastructure.Peresistance._Data.Configrations.Base;
using LinkDev.Talabat.Infrastrucutre.Infrastructure._Data;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.Talabat.Infrastructure.Peresistance._Data.Configrations.Product
{
  

    internal class BrandConfigurations : BaseAuditableEnitityConfigurations<ProductBrand,int>
	{
		public override void Configure(EntityTypeBuilder<ProductBrand> builder)
		{
			base.Configure(builder);

			builder.Property(B=>B.Name)
				.HasMaxLength(25).
				IsRequired();
		}
	}
}

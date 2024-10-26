using LinkDev.Talabat.Core.Domain.Enities.Identity;
using LinkDev.Talabat.Infrastructure.Peresistance._Common;
using LinkDev.Talabat.Infrastructure.Peresistance.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.Talabat.Infrastructure.Peresistance._Identity.Configurations
{
	[DbContextTypeAttribute(typeof(StoreIdentityDbContext))]
	internal class AddressConfigurations : IEntityTypeConfiguration<Address>
	{
		public void Configure(EntityTypeBuilder<Address> builder)
		{
			builder.ToTable("Addresses");
			builder.Property(nameof(Address.Id)).ValueGeneratedOnAdd();
			builder.Property(nameof(Address.City)).HasColumnType("nvarchar") .HasMaxLength(50);
			builder.Property(nameof(Address.Street)).HasColumnType("nvarchar") .HasMaxLength(50);
			builder.Property(nameof(Address.Country)).HasColumnType("nvarchar") .HasMaxLength(50);
			builder.Property(nameof(Address.FirstName)).HasColumnType("nvarchar") .HasMaxLength(50);
			builder.Property(nameof(Address.LastName)).HasColumnType("nvarchar") .HasMaxLength(50);
			

		}
	}
}

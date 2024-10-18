using LinkDev.Talabat.Core.Domain.Enities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.Talabat.Infrastructure.Peresistance._Identity.Configurations
{
	internal class ApplicationUserConfigurations : IEntityTypeConfiguration<ApplicationUser>
	{
		public void Configure(EntityTypeBuilder<ApplicationUser> builder)
		{
			builder.Property(e=>e.DisplayName)
				.HasMaxLength(100)
				.IsRequired();

			builder.HasOne(u => u.Address)
				.WithOne(a => a.User)
				.HasForeignKey<Address>(a => a.UserId);
				
		}
	}
}

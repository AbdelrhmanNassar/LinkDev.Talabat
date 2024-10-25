using LinkDev.Talabat.Core.Domain.Comman;
using LinkDev.Talabat.Infrastructure.Peresistance._Common;
using LinkDev.Talabat.Infrastrucutre.Infrastructure._Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.Talabat.Infrastructure.Peresistance._Data.Configrations.Base
{
	//[DbContextTypeAttribute(typeof(StoreDbContext))]
	//any one inhirts from you will take this attribute
	[DbContextTypeAttribute(typeof(StoreDbContext))]
	public class BaseEnitiyConfigurations<TEntity,Tkey> : IEntityTypeConfiguration<TEntity>
		where TEntity : BaseEntity<Tkey>
		where Tkey : IEquatable<Tkey>

	{
		public virtual void Configure(EntityTypeBuilder<TEntity> builder)
		{
			builder.Property(E => E.Id)
		 .ValueGeneratedOnAdd();
		}
	}
}

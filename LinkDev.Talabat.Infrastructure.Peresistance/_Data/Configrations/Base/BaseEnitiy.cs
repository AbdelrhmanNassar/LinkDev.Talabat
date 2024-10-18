using LinkDev.Talabat.Core.Domain.Comman;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.Talabat.Infrastructure.Peresistance._Data.Configrations.Base
{
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

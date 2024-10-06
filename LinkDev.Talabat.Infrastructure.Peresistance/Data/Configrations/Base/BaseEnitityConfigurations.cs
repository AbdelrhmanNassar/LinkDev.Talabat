using LinkDev.Talabat.Core.Domain.Comman;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.Talabat.Infrastructure.Peresistance.Data.Configrations.Base
{
    public class BaseEnitityConfigurations<TEntity,TKey> : IEntityTypeConfiguration<TEntity>
        where TEntity : BaseEnitity<TKey> where TKey : IEquatable<TKey>
    {//very important

        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(E => E.Id)
            .ValueGeneratedOnAdd();

            builder.Property(E => E.CreatedBy)
            .IsRequired();

            builder.Property(E => E.CreatedOn)
            .IsRequired();
            //.HasDefaultValueSql();

            builder.Property(E => E.LastModigiedBy)
            .IsRequired();

            builder.Property(E => E.LastModifiedOn)
            .IsRequired();
            //.HasDefaultValueSql();


        }
    }
}

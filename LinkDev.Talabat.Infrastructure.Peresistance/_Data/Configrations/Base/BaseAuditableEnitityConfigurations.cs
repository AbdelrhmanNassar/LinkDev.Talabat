using LinkDev.Talabat.Core.Domain.Comman;
using LinkDev.Talabat.Infrastructure.Peresistance._Data.Configrations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.Talabat.Infrastructure.Peresistance._Data.Configrations.Base
{
    public class BaseAuditableEnitityConfigurations<TEntity,TKey> :BaseEnitiyConfigurations<TEntity,TKey>
        where TEntity : BaseAuditableEntitiy<TKey> where TKey : IEquatable<TKey>
    {//very important

        public override void Configure(EntityTypeBuilder<TEntity> builder)
        {

            base.Configure(builder);



            builder.Property(E => E.CreatedBy)
            .IsRequired();

            builder.Property(E => E.CreatedOn)
            .IsRequired();
            //.HasDefaultValueSql();

            builder.Property(E => E.LastModifiedBy)
            .IsRequired();

            builder.Property(E => E.LastModifiedOn)
            .IsRequired();
            //.HasDefaultValueSql();


        }
    }
}

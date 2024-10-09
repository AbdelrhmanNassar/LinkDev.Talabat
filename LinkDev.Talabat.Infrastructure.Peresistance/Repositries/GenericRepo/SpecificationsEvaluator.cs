using LinkDev.Talabat.Core.Domain.Comman;
using LinkDev.Talabat.Core.Domain.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.Talabat.Infrastructure.Peresistance.Repositries.GenericRepo
{
	internal static class SpecificationsEvaluator<TEntity,Tkey>
		where TEntity : BaseEntity<Tkey>
		where Tkey : IEquatable<Tkey>
	{
		public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, Core.Domain.Contracts.ISpecifications<TEntity, Tkey> specifications)
		{
			var query = inputQuery;

			if (specifications.Criteria is not null)
			{
				query = query.Where(specifications.Criteria);
			}

			query = specifications.Includes.Aggregate(query, (currentQuery, include) => currentQuery.Include(include));

			return query;
		}

	}
}

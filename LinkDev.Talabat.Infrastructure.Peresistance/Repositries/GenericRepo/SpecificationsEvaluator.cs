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
			if (specifications.OrderBy is not null) //you could start the condition by what ever you want because i handled this issue(could orderBy-orderBy has value at same time)
				query = query.OrderBy(specifications.OrderBy);
			else
				query = query.OrderByDescending(specifications.OrderByDesc);

			if(specifications.EnablePagenation is true)
			query =	query.Skip(specifications.Skip).Take(specifications.Take);
		 



			query = specifications.Includes.Aggregate(query, (currentQuery, include) => currentQuery.Include(include));

			return query;
		}

	}
}

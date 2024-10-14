using LinkDev.Talabat.Core.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.Talabat.Core.Domain.NewFolder
{
	public class BaseSpecifications<TEntity, Tkey> : ISpecifications<TEntity, Tkey>
		where TEntity : BaseAuditableEntitiy<Tkey>
		where Tkey : IEquatable<Tkey>
	{
		//public Expression<Predicate<TEntity>> Criteria { get; set; } = null;
		public List<Expression<Func<TEntity, object>>> Includes { get; set; } = new List<Expression<Func<TEntity, object>>>();
		public Expression<Func<TEntity, bool>>? Criteria { get; set; }
		public Expression<Func<TEntity, object>>? OrderBy { get; set; }
		public Expression<Func<TEntity, object>>? OrderByDesc { get; set; }

		public int Take { get; set; }
		public int Skip { get; set; }
		public bool EnablePagenation { get; set; } //false by defualt
		public BaseSpecifications(Expression<Func<TEntity, bool>> expression)
		{
			//Criteria
			Criteria = expression;

		}
		public BaseSpecifications(Tkey id)
		{

			Criteria = E => E.Id.Equals(id);
		}
		//public BaseSpecifications()
		//{

		//}

		private protected virtual void AddIncludes()
		{

		}

		private protected virtual void AddOrderBy(Expression<Func<TEntity, object>>? orderBy) {
			this.OrderBy = orderBy;

		}
		private protected virtual void AddOrderByDesc(Expression<Func<TEntity, object>>? orderByDecs) {

			this.OrderByDesc = orderByDecs;
		}

		private protected void AddPageination (int skip ,int take){
			EnablePagenation = true;
			this.Skip = skip;
			this.Take = take;

			}


	}
}

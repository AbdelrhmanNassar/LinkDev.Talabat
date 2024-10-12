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
		public List<Expression<Func<TEntity, object>>> Includes { get; set; } = new ();
		public Expression<Func<TEntity, bool>>? Criteria { get ; set ; }

		public BaseSpecifications()
        {
			//Criteria
			Includes = new List<Expression<Func<TEntity, object>>> ();
		}
        public BaseSpecifications(Tkey id)
        {

			Criteria = E => E.Id.Equals(id); 
			Includes = new List<Expression<Func<TEntity, object>>>();
		}
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.Talabat.Core.Domain.Contracts
{
	public interface ISpecifications<TEnitiy,Tkey> where TEnitiy :BaseEntity<Tkey>
		where Tkey : IEquatable<Tkey>
	{
        public Expression<Func<TEnitiy,bool>> Criteria { get; set; }

        public List<Expression<Func<TEnitiy,object>>> Includes { get; set; }
    }
}

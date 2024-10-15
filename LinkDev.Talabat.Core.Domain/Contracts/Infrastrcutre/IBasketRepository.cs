using LinkDev.Talabat.Core.Domain.Enities.Basket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.Talabat.Core.Domain.Contracts.Infrastrcutre
{
	public interface IBasketRepository
	{
		Task<CustomerBasket?> GetAsync(string id);
		Task<CustomerBasket?> UpdateAsync(CustomerBasket basket,TimeSpan timeSpan);
		Task<bool> DeleteAsync(string id);
	}
}

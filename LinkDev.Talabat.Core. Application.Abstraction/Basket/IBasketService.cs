using LinkDev.Talabat.Core._Application.Abstraction.Basket.Mdoels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.Talabat.Core._Application.Abstraction.Basket
{
    public interface IBasketService
    {
		Task<CustomerBusketDto?> GetCustomerBasketAsync(string id);
		Task<CustomerBusketDto?> UpdateCustomerBasketAsync(CustomerBusketDto basket);
		Task DeleteCustomerBasketAsync(string id);
	}
}

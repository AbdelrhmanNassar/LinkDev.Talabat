using LinkDev.Talabat.Core.Domain.Contracts.Infrastrcutre;
using LinkDev.Talabat.Core.Domain.Enities.Basket;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LinkDev.Talabat.Infrastrucutre.Infrastructure.BasketRepo
{
	public class BasketRepositry : IBasketRepository
	{
		private readonly IConnectionMultiplexer redix;

		public BasketRepositry(IConnectionMultiplexer redix)
        {
			this.redix = redix;
		}
        public Task<bool> DeleteAsync(string id)
		{
			return redix.GetDatabase().KeyDeleteAsync(id);
		}

		public async Task<CustomerBasket?> GetAsync(string id)
		{
			var basket =  await redix.GetDatabase().StringGetAsync(id);
			return basket.IsNullOrEmpty ?null :JsonSerializer.Deserialize<CustomerBasket>(basket!);
		}

        public async Task<CustomerBasket?> UpdateAsync(CustomerBasket basket, TimeSpan timeSpan)
        {
            var value = JsonSerializer.Serialize(basket);

            var updated = await redix.GetDatabase().StringSetAsync(basket.Id, value, timeSpan);
            if (updated) return basket;
            return
                 null;
        }
    }
}

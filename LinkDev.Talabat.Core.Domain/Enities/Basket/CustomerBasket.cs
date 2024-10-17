﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.Talabat.Core.Domain.Enities.Basket
{
	public class CustomerBasket
	{
        public string Id { get; set; }
        public IEnumerable<BasketItem> Items { get; set; } = new List<BasketItem>();
    }
}

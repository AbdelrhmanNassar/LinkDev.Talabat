﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.Talabat.Core.Domain.Enities.Basket
{
	public class BasketItem 
	{
        public required int Id { get; set; }
        public required string ProductName { get; set; }
		public string? PictureUrl { get; set; }
		public decimal Price { get; set; }
		public int Quantity { get; set; }
		public string? Brand { get; set; }
		public string? Category { get; set; }
	}
}

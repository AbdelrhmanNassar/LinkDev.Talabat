﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.Talabat.Core._Application.Abstraction.Basket.Mdoels
{
	public class BasketItemDto
	{
		[Required]
		public int Id { get; set; }

		public required string ProductName { get; set; }
		public string? PictureUrl { get; set; }
		[Required]
		[Range(.1, double.MaxValue,ErrorMessage = "Price Must be grater than Zero")]
		public decimal Price { get; set; }
		[Required]
		[Range(1, double.MaxValue, ErrorMessage = "Qunatity Must be at least one item")]
		public int Quantity { get; set; }
		public string? Brand { get; set; }
		public string? Category { get; set; }
	}
}

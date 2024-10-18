﻿using LinkDev.Talabat.Core._Application.Abstraction.Auth;
using LinkDev.Talabat.Core._Application.Abstraction.Basket;
using LinkDev.Talabat.Core.Application.Abstraction.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.Talabat.Core.Application.Abstraction.ServiceManager
{
	public interface IServiceManager
	{
		public IProductService ProductService { get; }
		public IBasketService BasketService { get; }

		public IAuthService AuthService { get; }



	}
}

using LinkDev.Talabat.Core.Domain.Comman;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.Talabat.Core.Domain.Enities.Product
{
	public class ProductBrand :BaseEnitity<int>
	{
        public required string Name { get; set; }
    }
}

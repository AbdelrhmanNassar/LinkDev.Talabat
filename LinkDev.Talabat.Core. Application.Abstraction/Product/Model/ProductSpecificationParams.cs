using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.Talabat.Core._Application.Abstraction.Product.Model
{
	public class ProductSpecificationParams
	{
		public int? BrandId { get; set; }
		public int? CategoryId { get; set; }
		public string? Sort { get; set; }
		public int PageIndex { get; set; }

	

		private int maxSize = 10;
		private int pageSize = 1;
		public int PageSize
		{
			get { return pageSize; }
			set { pageSize = value > maxSize ? maxSize : value ; }
		}

	}
	
}

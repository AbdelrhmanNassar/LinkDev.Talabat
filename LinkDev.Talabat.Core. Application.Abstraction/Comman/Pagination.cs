using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.Talabat.Core._Application.Abstraction.Comman
{
	public class Pagination<T>
	{
		public Pagination(int pageIndex, int pageSize, IEnumerable<T> products)
		{
			PageIndex = pageIndex;
			PageSize = pageSize;
			Data = products;
		}

		public int Count { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }

        public  IEnumerable<T> Data { get; set; }
        public Pagination(int pageIndex,int pageSize, IEnumerable<T> data, int count)
        {
			PageIndex = pageIndex;
			PageSize = pageSize;
			Count = count;
			Data = data;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.Talabat.Core.Application.Abstraction
{
	public class NotFoundException :ApplicationException
	{
        public NotFoundException():base("NotFound Exception")
        {
            
        }
    }
}

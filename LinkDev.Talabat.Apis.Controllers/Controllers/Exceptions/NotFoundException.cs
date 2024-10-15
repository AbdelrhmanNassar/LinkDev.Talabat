using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.Talabat.Apis.Controllers.Controllers.Exceptions
{
	public class NotFoundException :ApplicationException
	{
        public NotFoundException():base("NotFound Exception")
        {
            
        }
    }
}

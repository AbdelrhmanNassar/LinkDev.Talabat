using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.Talabat.Core.Application.Exceptions
{
	public class UnAuthorizedException(string message) :ApplicationException(message)
	{
	}
}

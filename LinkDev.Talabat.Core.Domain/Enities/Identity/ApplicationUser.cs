using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.Talabat.Core.Domain.Enities.Identity
{
	public class ApplicationUser : IdentityUser<string>  //key will be string
	{
        public required string DisplayName { get; set; }
        public virtual Address? Address { get; set; }

    }
}

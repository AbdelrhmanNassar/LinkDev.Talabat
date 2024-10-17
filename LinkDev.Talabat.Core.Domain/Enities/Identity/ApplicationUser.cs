using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.Talabat.Core.Domain.Enities.Identity
{
	internal class ApplicationUser : IdentityUser<int>  //key will be string
	{
        public required string DisplayName { get; set; }
        public Address? Address { get; set; }

    }
}

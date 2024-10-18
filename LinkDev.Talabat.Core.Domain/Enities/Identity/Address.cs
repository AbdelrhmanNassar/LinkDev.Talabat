
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.Talabat.Core.Domain.Enities.Identity
{
	public class Address
	{
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string City { get; set; }
        public required string Country { get; set; }
        public required string Street{ get; set; }

        public  required string UserId { get; set; }
        public virtual required ApplicationUser User { get; set; } //Actualy i don't need this but because i want to raise an error
    }
}

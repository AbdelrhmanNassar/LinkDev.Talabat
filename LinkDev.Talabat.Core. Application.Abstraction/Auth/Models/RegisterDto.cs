using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.Talabat.Core._Application.Abstraction.Auth.Models
{
	public class RegisterDto
	{
        [Required]
        public required string DisplayName { get; set; }
		[Required]
		public required string UserName { get; set; }
		[Required]
		public required string Email { get; set; }
		[Required]
		public required string Phone { get; set; }
		[Required]
		[RegularExpression("(?=^.{6,10}$)(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&()_+}{\":;'?/<>.,])(?!.*\\s).*",
	ErrorMessage = "Password must have at least 1 uppercase letter, 1 lowercase letter, 1 number, 1 special character, and be 6-10 characters long.")]

		public required string Password { get; set; }
    }
}

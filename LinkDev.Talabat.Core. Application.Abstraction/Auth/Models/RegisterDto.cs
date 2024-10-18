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
		[RegularExpression("^(?=.{6,10}$)(?=.*\\d)(?=.*[A-Z])(?=.*[a-z])(?=.*[!@#$%^&*()_+{}\":;'?/>&lt;,])(?!.*\\s)\r\n")]
		public required string Password { get; set; }
    }
}

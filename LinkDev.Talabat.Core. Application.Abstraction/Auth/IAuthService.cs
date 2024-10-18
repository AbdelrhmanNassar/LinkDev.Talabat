using LinkDev.Talabat.Core._Application.Abstraction.Auth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.Talabat.Core._Application.Abstraction.Auth
{
	public interface IAuthService
	{
		 Task<UserDto> LoginAsync(LoginDto model); 
		 Task<UserDto> RegisterAsync(RegisterDto model); 

	}
}

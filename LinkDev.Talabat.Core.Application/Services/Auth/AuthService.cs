using LinkDev.Talabat.Core._Application.Abstraction.Auth;
using LinkDev.Talabat.Core._Application.Abstraction.Auth.Models;
using LinkDev.Talabat.Core.Application.Exceptions;
using LinkDev.Talabat.Core.Domain.Enities.Identity;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.Talabat.Core.Application.Services.Auth
{
	internal class AuthService(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager) : IAuthService
	{
		public async Task<UserDto> LoginAsync(LoginDto model)
		{
			var user = await userManager.FindByEmailAsync(model.Email);
			if (user is null)
				throw new BadRequestException("Invalid Login");
			var result = await signInManager.CheckPasswordSignInAsync(user ,model.Password, true);

			if(!result.Succeeded)
				throw new BadRequestException("Invalid Login");

			var response = new UserDto() { 
				DisplayName=user.DisplayName,
				Email=user.Email,
				Id =user.Id,
				Token="Jwt"

			};
			return response;
		}

		public async Task<UserDto> RegisterAsync(RegisterDto model)
		{
			var user = new ApplicationUser()
			{
				DisplayName = model.DisplayName,
				Email = model.Email,
				UserName = model.UserName,
				PhoneNumber = model.Phone
			};
			var result = await userManager.CreateAsync(user, model.Password);
			if (!result.Succeeded)
				throw new ValidationException() { Errors = result.Errors.Select(e => e.Description) };

			var response = new UserDto()
			{
				DisplayName = user.DisplayName,
				Email = user.Email,
				Id = user.Id,
				Token = "Jwt"

			};
			return response;
		}
	}
}

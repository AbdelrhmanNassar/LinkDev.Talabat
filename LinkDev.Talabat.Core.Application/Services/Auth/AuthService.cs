using LinkDev.Talabat.Core._Application.Abstraction.Auth;
using LinkDev.Talabat.Core._Application.Abstraction.Auth.Models;
using LinkDev.Talabat.Core.Application.Exceptions;
using LinkDev.Talabat.Core.Domain.Enities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

using System.Text;

namespace LinkDev.Talabat.Core.Application.Services.Auth
{
	internal class AuthService(UserManager<ApplicationUser> userManager,
		SignInManager<ApplicationUser> signInManager,
		IOptions<JwtSettings> jwtSettings ) : IAuthService
	{
		private readonly JwtSettings JwtSettings = jwtSettings.Value;

		public async Task<UserDto> LoginAsync(LoginDto model)
		{
			var user = await userManager.FindByEmailAsync(model.Email);
			if (user is null)
				throw new UnAuthorizedException("Invalid Login");
			var result = await signInManager.CheckPasswordSignInAsync(user ,model.Password, true);
			

			if(!result.Succeeded)
				throw new UnAuthorizedException("Invalid Login");

			var response = new UserDto() { 
				DisplayName=user.DisplayName,
				Email=user.Email!,
				Id =user.Id,
				Token= await GenerateToken(user)

			};
			return response;
		}

		public async Task<UserDto> RegisterAsync(RegisterDto model)
		{
			var user = new ApplicationUser()
			{
				Id = Guid.NewGuid().ToString(),
				DisplayName = model.DisplayName,
				Email = model.Email,
				UserName = model.UserName,
				PhoneNumber = model.Phone
			};
			var result = await userManager.CreateAsync(user, model.Password);
			if (!result.Succeeded)
			{
				var errors = result.Errors.Select(e => e.Description);

				throw new ValidationException(errors);
			}
			var response = new UserDto()
			{
				DisplayName = user.DisplayName,
				Email = user.Email,
				Id = user.Id,
				Token = await GenerateToken(user)

			};
			return response;
		}

		public async Task<string> GenerateToken(ApplicationUser applicationUser)
		{
			//Private Clamis
			var privateClamis = new List<Claim>()
			{
				new Claim(ClaimTypes.PrimarySid,applicationUser.Id),
				new Claim(ClaimTypes.Email,applicationUser.Email!),
				new Claim(ClaimTypes.GivenName,applicationUser.DisplayName)
			}.Union(await userManager.GetClaimsAsync(applicationUser)).ToList();

			var roles = await userManager.GetRolesAsync(applicationUser);
			foreach (var role in roles)
			{
				privateClamis.Add(new Claim(ClaimTypes.Role, role.ToString()));
			}
			var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtSettings.Key));

			var tokenObj = new JwtSecurityToken(
				//payload(private claims - registered claims)
				audience: JwtSettings.Audience,
				issuer: JwtSettings.Issuer,
				expires: DateTime.UtcNow.AddMinutes(JwtSettings.DurationInMintues),
				claims: privateClamis,
				signingCredentials: new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256));//signature and header 
			return new JwtSecurityTokenHandler().WriteToken(tokenObj);

		}

		//public async Task<string> generateToken02(ApplicationUser applicationUser)
		//{
		//	#region Private claims
				
		//		var privateClaims = new List<Claim>()
		//		{
		//			new Claim(ClaimTypes.PrimarySid, applicationUser.Id),
		//			new Claim(ClaimTypes.Email, applicationUser.Email!),
		//			new Claim(ClaimTypes.GivenName, applicationUser.DisplayName)
		//		};

		//		foreach(var role in await userManager.GetRolesAsync(applicationUser))
		//			{
		//				privateClaims.Add(new Claim(ClaimTypes.Role, role));
		//			};
		//	privateClaims.Union(await userManager.GetClaimsAsync(applicationUser));
		//	#endregion

		
		//	var secKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Value.Key));

		//	var token = new JwtSecurityToken(
		//		issuer: "Talabat",
		//		audience: "Talabat Users",
		//		expires: DateTime.UtcNow.AddMinutes(60),
		//		claims: privateClaims,
		//		signingCredentials: new SigningCredentials(secKey, SecurityAlgorithms.HmacSha256)

		//		);

		//	return new JwtSecurityTokenHandler().WriteToken(token);
  //      }
	}
}

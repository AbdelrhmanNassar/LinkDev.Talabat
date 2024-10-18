using LinkDev.Talabat.Core.Application.Abstraction;
using System.Security.Claims;

namespace LinkDev.Talabat.Api.Services
{
	public class LoggedInUserServices : ILoggedInUserServices

	{
		private readonly IHttpContextAccessor? _httpContextAccessor;

		public string? UserId { get; }

		public LoggedInUserServices(IHttpContextAccessor? httpContextAccessor) // i just comment it because i don't register it yet
		{
			_httpContextAccessor = httpContextAccessor;
			UserId = _httpContextAccessor?.HttpContext?.User?.FindFirstValue(ClaimTypes.PrimarySid);
		}
	}

}

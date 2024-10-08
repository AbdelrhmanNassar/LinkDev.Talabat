using LinkDev.Talabat.Core._Application.Abstraction;
using System.Security.Claims;

namespace LinkDev.Talabat.Api.Services
{
	public class LoggedInUserServices : ILoggedInUserServices

	{
		private readonly IHttpContextAccessor _httpContextAccessor;

		public string UserId { get; }

        public LoggedInUserServices(IHttpContextAccessor httpContextAccessor)
        {
			_httpContextAccessor = httpContextAccessor;
			UserId = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier)!;
		}
    }

}

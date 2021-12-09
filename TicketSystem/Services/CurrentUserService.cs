namespace TicketSystem.Services
{
    using Microsoft.AspNetCore.Http;
    using System.Security.Claims;
    using System.Linq;

    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        private readonly ClaimsPrincipal user;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
            => this.user = httpContextAccessor.HttpContext?.User;

        public string GetId()
            => this.user
                .Claims
                .FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)
                ?.Value;

        public string GetUserName()
            => this.user?.Identity?.Name;

        public bool IsAssignedToRole(string role)
            => this.user.IsInRole(role);

    }
}

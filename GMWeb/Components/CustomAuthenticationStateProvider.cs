using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;
using System.Threading.Tasks;

namespace GMWeb.Components
{
    public class CustomAuthenticationStateProvider
        : AuthenticationStateProvider
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private AuthenticationState? _cachedState;

        public CustomAuthenticationStateProvider(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var httpContext = _httpContextAccessor.HttpContext;
            if (httpContext != null && httpContext.User.Identity?.IsAuthenticated == true)
            {
                var user = httpContext.User;
                var state = new AuthenticationState(user);
                _cachedState = state;
                return Task.FromResult(state);
            }

            if (_cachedState != null)
            {
                return Task.FromResult(_cachedState);
            }

            var identity = new ClaimsIdentity();
            var anonymousUser = new ClaimsPrincipal(identity);
            var anonymousState = new AuthenticationState(anonymousUser);
            _cachedState = anonymousState;
            return Task.FromResult(anonymousState);
        }

        public void UpdateAuthenticationState(ClaimsPrincipal principal)
        {
            _cachedState = new AuthenticationState(principal);
            NotifyAuthenticationStateChanged(Task.FromResult(_cachedState));
        }

        public void UpdateState(ClaimsPrincipal principal)
        {
            _cachedState = new AuthenticationState(principal);
            NotifyAuthenticationStateChanged(Task.FromResult(_cachedState));
        }
    }
}
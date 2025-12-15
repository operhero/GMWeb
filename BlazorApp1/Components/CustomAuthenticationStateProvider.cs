using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace BlazorApp1.Components
{
    public class CustomAuthenticationStateProvider()
        : AuthenticationStateProvider
    {
        private static AuthenticationState? _state;
        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            if (_state != null)
            {
                return Task.FromResult(_state);
            }

            var identity = new ClaimsIdentity();
            var user = new ClaimsPrincipal(identity);

            return Task.FromResult(new AuthenticationState(user));
        }

        public void UpdateAuthenticationState(ClaimsPrincipal principal)
        {
            _state = new AuthenticationState(principal);
            NotifyAuthenticationStateChanged(Task.FromResult(_state));
        }

        public void Logout()
        {
            Console.WriteLine("Logout called");
        }
    }
}
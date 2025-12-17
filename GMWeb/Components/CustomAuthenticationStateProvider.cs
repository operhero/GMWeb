using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Text.Json;

namespace GMWeb.Components
{
    public class CustomAuthenticationStateProvider
        : AuthenticationStateProvider
    {
        private static AuthenticationState? _state;
    private static string? _token;
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

        public void UpdateAuthenticationState(ClaimsPrincipal principal, string token = "")
        {
            _state = new AuthenticationState(principal);
            _token = token;
            NotifyAuthenticationStateChanged(Task.FromResult(_state));
        }

        public void Logout()
        {
            // 清除认证状态和令牌
            _state = null;
            _token = null;
            
            // 创建一个未认证的用户状态
            var identity = new ClaimsIdentity();
            var user = new ClaimsPrincipal(identity);
            _state = new AuthenticationState(user);
            
            // 通知所有监听认证状态变化的组件
            NotifyAuthenticationStateChanged(Task.FromResult(_state));
        }
        
        // 获取当前令牌
        public string? GetToken()
        {
            return _token;
        }
    }
}
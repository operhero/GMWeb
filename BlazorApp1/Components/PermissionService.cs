using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;

namespace BlazorApp1.Components;

// 权限服务，用于管理权限和菜单
public class PermissionService
{
    private readonly AuthenticationStateProvider _authenticationStateProvider;
    
    public PermissionService(AuthenticationStateProvider authenticationStateProvider)
    {
        _authenticationStateProvider = authenticationStateProvider;
    }
    
    // 获取所有可用权限（模拟数据）
    public List<Permission> GetAllPermissions()
    {
        return new List<Permission>
        {
            new Permission { Id = "dashboard_access", Name = "仪表盘访问", Description = "允许访问仪表盘页面", Type = "page" },
            new Permission { Id = "menu1_access", Name = "主菜单1访问", Description = "允许访问主菜单1", Type = "page" },
            new Permission { Id = "submenu1_1_access", Name = "子菜单1-1访问", Description = "允许访问子菜单1-1", Type = "page" },
            new Permission { Id = "submenu1_2_access", Name = "子菜单1-2访问", Description = "允许访问子菜单1-2", Type = "page" },
            new Permission { Id = "submenu1_1_1_access", Name = "三级子菜单1-1-1访问", Description = "允许访问三级子菜单1-1-1", Type = "page" },
            new Permission { Id = "submenu1_1_2_access", Name = "三级子菜单1-1-2访问", Description = "允许访问三级子菜单1-1-2", Type = "page" },
            new Permission { Id = "menu2_access", Name = "主菜单2访问", Description = "允许访问主菜单2", Type = "page" },
            new Permission { Id = "submenu2_1_access", Name = "子菜单2-1访问", Description = "允许访问子菜单2-1", Type = "page" },
            new Permission { Id = "submenu2_2_access", Name = "子菜单2-2访问", Description = "允许访问子菜单2-2", Type = "page" },
            new Permission { Id = "counter_access", Name = "计数器访问", Description = "允许访问计数器页面", Type = "page" },
            new Permission { Id = "weather_access", Name = "天气访问", Description = "允许访问天气页面", Type = "page" }
        };
    }
    
    // 获取所有菜单（模拟数据）
    public List<MenuItem> GetAllMenus()
    {
        return new List<MenuItem>
        {
            new MenuItem
            {
                Id = "dashboard",
                Title = "仪表盘",
                Icon = "bi bi-house-door-fill-nav-menu",
                Url = "/dashboard",
                ParentId = string.Empty,
                RequiredPermission = "dashboard_access",
                IsClosable = false,
                Order = 0
            },
            new MenuItem
            {
                Id = "main-menu-1",
                Title = "主菜单1",
                Icon = "bi bi-folder-fill-nav-menu",
                Url = string.Empty,
                ParentId = string.Empty,
                RequiredPermission = "menu1_access",
                Order = 1
            },
            new MenuItem
            {
                Id = "submenu1-1",
                Title = "子菜单1-1",
                Icon = "bi bi-file-earmark-fill-nav-menu",
                Url = "/submenu1-1",
                ParentId = "main-menu-1",
                RequiredPermission = "submenu1_1_access",
                Order = 0
            },
            new MenuItem
            {
                Id = "submenu1-2",
                Title = "子菜单1-2",
                Icon = "bi bi-file-earmark-fill-nav-menu",
                Url = "/submenu1-2",
                ParentId = "main-menu-1",
                RequiredPermission = "submenu1_2_access",
                Order = 1
            },
            new MenuItem
            {
                Id = "sub-menu-1-1",
                Title = "二级子菜单",
                Icon = "bi bi-folder-fill-nav-menu",
                Url = string.Empty,
                ParentId = "submenu1-1",
                RequiredPermission = string.Empty, // 没有直接权限要求，继承父菜单权限
                Order = 0
            },
            new MenuItem
            {
                Id = "submenu1-1-1",
                Title = "三级子菜单1-1-1",
                Icon = "bi bi-file-earmark-fill-nav-menu",
                Url = "/submenu1-1-1",
                ParentId = "sub-menu-1-1",
                RequiredPermission = "submenu1_1_1_access",
                Order = 0
            },
            new MenuItem
            {
                Id = "submenu1-1-2",
                Title = "三级子菜单1-1-2",
                Icon = "bi bi-file-earmark-fill-nav-menu",
                Url = "/submenu1-1-2",
                ParentId = "sub-menu-1-1",
                RequiredPermission = "submenu1_1_2_access",
                Order = 1
            },
            new MenuItem
            {
                Id = "main-menu-2",
                Title = "主菜单2",
                Icon = "bi bi-folder-fill-nav-menu",
                Url = string.Empty,
                ParentId = string.Empty,
                RequiredPermission = "menu2_access",
                Order = 2
            },
            new MenuItem
            {
                Id = "submenu2-1",
                Title = "子菜单2-1",
                Icon = "bi bi-file-earmark-fill-nav-menu",
                Url = "/submenu2-1",
                ParentId = "main-menu-2",
                RequiredPermission = "submenu2_1_access",
                Order = 0
            },
            new MenuItem
            {
                Id = "submenu2-2",
                Title = "子菜单2-2",
                Icon = "bi bi-file-earmark-fill-nav-menu",
                Url = "/submenu2-2",
                ParentId = "main-menu-2",
                RequiredPermission = "submenu2_2_access",
                Order = 1
            },
            new MenuItem
            {
                Id = "counter",
                Title = "计数器",
                Icon = "bi bi-plus-square-fill-nav-menu",
                Url = "/counter",
                ParentId = string.Empty,
                RequiredPermission = "counter_access",
                Order = 3
            },
            new MenuItem
            {
                Id = "weather",
                Title = "天气",
                Icon = "bi bi-list-nested-nav-menu",
                Url = "/weather",
                ParentId = string.Empty,
                RequiredPermission = "weather_access",
                Order = 4
            }
        };
    }
    
    // 根据用户权限获取可访问的菜单
    public async Task<List<MenuItem>> GetMenusForUserAsync()
    {
        var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
        var user = authState.User;
        
        Console.WriteLine($"[DEBUG] User authenticated: {user.Identity?.IsAuthenticated}");
        Console.WriteLine($"[DEBUG] User name: {user.Identity?.Name}");
        
        // 输出用户的所有声明
        var claims = user.Claims.ToList();
        Console.WriteLine($"[DEBUG] User claims count: {claims.Count}");
        foreach (var claim in claims)
        {
            Console.WriteLine($"[DEBUG] Claim: {claim.Type} = {claim.Value}");
        }
        
        // 获取所有菜单
        var allMenus = GetAllMenus();
        Console.WriteLine($"[DEBUG] All menus count: {allMenus.Count}");
        
        // 检查用户是否已认证
        if (!user.Identity?.IsAuthenticated ?? false)
        {
            // 如果用户未认证，返回空菜单
            Console.WriteLine("[DEBUG] User not authenticated, returning empty menu");
            return new List<MenuItem>();
        }
        
        // 根据用户权限过滤菜单
        var filteredMenus = FilterMenusByPermission(allMenus, user);
        Console.WriteLine($"[DEBUG] Filtered menus count: {filteredMenus.Count}");
        
        // 构建菜单树结构
        var menuTree = BuildMenuTree(filteredMenus);
        Console.WriteLine($"[DEBUG] Menu tree count: {menuTree.Count}");
        
        return menuTree;
    }
    
    // 根据权限过滤菜单
    private List<MenuItem> FilterMenusByPermission(List<MenuItem> menus, ClaimsPrincipal user)
    {
        var filtered = new List<MenuItem>();
        
        foreach (var menu in menus)
        {
            // 检查用户是否有访问该菜单的权限
            if (HasPermission(menu, user))
            {
                filtered.Add(menu);
            }
        }
        
        return filtered;
    }
    
    // 检查用户是否有访问菜单的权限
    private bool HasPermission(MenuItem menu, ClaimsPrincipal user)
    {
        // 如果菜单不需要权限，则允许访问
        if (string.IsNullOrEmpty(menu.RequiredPermission))
        {
            return true;
        }
        
        // 检查用户是否有该权限
        // 先检查角色权限
        if (user.IsInRole(menu.RequiredPermission))
        {
            return true;
        }
        
        // 再检查声明权限
        if (user.HasClaim(ClaimTypes.Role, menu.RequiredPermission))
        {
            return true;
        }
        
        // 最后检查所有声明，确保没有遗漏
        var claims = user.Claims.ToList();
        return claims.Any(c => c.Value == menu.RequiredPermission);
    }
    
    // 构建菜单树结构
    private List<MenuItem> BuildMenuTree(List<MenuItem> menus)
    {
        // 先将所有菜单按ParentId分组，使用空字符串作为顶级菜单的键
        var menuGroups = new Dictionary<string, List<MenuItem>>();
        
        foreach (var menu in menus)
        {
            // 使用空字符串代替null作为顶级菜单的键
            var parentKey = menu.ParentId ?? string.Empty;
            if (!menuGroups.ContainsKey(parentKey))
            {
                menuGroups[parentKey] = new List<MenuItem>();
            }
            menuGroups[parentKey].Add(menu);
        }
        
        // 设置每个菜单的子菜单
        foreach (var menu in menus)
        {
            if (menuGroups.ContainsKey(menu.Id))
            {
                menu.Children = menuGroups[menu.Id].OrderBy(m => m.Order).ToList();
            }
        }
        
        // 返回顶级菜单（ParentId为null的菜单）
        var topLevelMenus = menuGroups.TryGetValue(string.Empty, out var value) ? value : new List<MenuItem>();
        return topLevelMenus.OrderBy(m => m.Order).ToList();
    }
}

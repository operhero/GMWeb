namespace BlazorApp1.Components;

// 权限模型
public class Permission
{
    // 权限ID
    public string Id { get; set; }
    
    // 权限名称
    public string Name { get; set; }
    
    // 权限描述
    public string Description { get; set; }
    
    // 权限类型（例如：页面访问、功能操作等）
    public string Type { get; set; }
}

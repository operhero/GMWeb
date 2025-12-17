namespace GMWeb.Models;

// 导航菜单项模型
public class MenuItem
{
    // 菜单项ID
    public string Id { get; set; } = string.Empty;
    
    // 菜单项标题
    public string Title { get; set; } = string.Empty;
    
    // 菜单项图标
    public string Icon { get; set; } = string.Empty;
    
    // 菜单项对应的URL
    public string Url { get; set; } = string.Empty;
    
    // 父菜单项ID（用于树状结构）
    public string ParentId { get; set; } = string.Empty;
    
    // 是否有子菜单
    public bool HasChildren => Children.Any();
    
    // 子菜单项列表
    public List<MenuItem> Children { get; set; } = new List<MenuItem>();
    
    // 需要的权限标识
    public string RequiredPermission { get; set; } = string.Empty;
    
    // 是否为默认不可关闭的菜单项
    public bool IsClosable { get; set; } = true;
    
    // 菜单项排序
    public int Order { get; set; }
}
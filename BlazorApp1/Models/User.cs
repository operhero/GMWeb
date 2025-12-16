namespace BlazorApp1.Models;

public class User
{
    public int Uid { get; set; }
    public string Uname { get; set; }
    public string Pwd { get; set; }
    public string Salt { get; set; }
    public int CreateTime { get; set; }
    public int SysId { get; set; }
    public int RoleId { get; set; }
    public string Award { get; set; }
    public int DrowTime { get; set; }
    public int Extra { get; set; }
}
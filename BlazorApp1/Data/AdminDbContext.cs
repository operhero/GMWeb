using BlazorApp1.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp1.Data;

public class AdminDbContext : DbContext
{
    public AdminDbContext(DbContextOptions<AdminDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("user");
            entity.HasKey(e => e.Uid);
            entity.Property(e => e.Uid).HasColumnName("uid");
            entity.Property(e => e.Uname).HasColumnName("uname"); // 这个字段在数据库中可能缺失，需要添加
            entity.Property(e => e.Pwd).HasColumnName("pwd").HasMaxLength(32);
            entity.Property(e => e.Salt).HasColumnName("salt").HasMaxLength(8);
            entity.Property(e => e.CreateTime).HasColumnName("createTime");
            entity.Property(e => e.SysId).HasColumnName("sysId");
            entity.Property(e => e.RoleId).HasColumnName("roleId");
            entity.Property(e => e.Award).HasColumnName("award").HasMaxLength(256);
            entity.Property(e => e.DrowTime).HasColumnName("drowTime");
            entity.Property(e => e.Extra).HasColumnName("extra");
        });
    }
}
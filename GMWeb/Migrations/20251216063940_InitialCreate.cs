using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GMWeb.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            // 只添加uname字段，因为表已经存在
            migrationBuilder.AddColumn<string>(
                name: "uname",
                table: "user",
                type: "varchar(50)",
                nullable: false
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // 只删除uname字段，因为表已经存在
            migrationBuilder.DropColumn(
                name: "uname",
                table: "user");
        }
    }
}

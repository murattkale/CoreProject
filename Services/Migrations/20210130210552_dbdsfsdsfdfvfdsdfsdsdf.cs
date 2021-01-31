using Microsoft.EntityFrameworkCore.Migrations;

namespace Services.Migrations
{
    public partial class dbdsfsdsfdfvfdsdfsdsdf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LoginCount",
                table: "User",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LoginCount",
                table: "User");
        }
    }
}

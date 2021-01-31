using Microsoft.EntityFrameworkCore.Migrations;

namespace Services.Migrations
{
    public partial class dbdsfsdsfdfvfdsdfsd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Pass",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pass",
                table: "User");
        }
    }
}

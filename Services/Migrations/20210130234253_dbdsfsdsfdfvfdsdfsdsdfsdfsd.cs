using Microsoft.EntityFrameworkCore.Migrations;

namespace Services.Migrations
{
    public partial class dbdsfsdsfdfvfdsdfsdsdfsdfsd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "No",
                table: "Section");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "No",
                table: "Section",
                type: "int",
                nullable: true);
        }
    }
}

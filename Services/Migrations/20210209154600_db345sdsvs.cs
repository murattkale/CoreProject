using Microsoft.EntityFrameworkCore.Migrations;

namespace Services.Migrations
{
    public partial class db345sdsvs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ResponseType",
                table: "ResponseData");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ResponseType",
                table: "ResponseData",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

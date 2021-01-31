using Microsoft.EntityFrameworkCore.Migrations;

namespace Services.Migrations
{
    public partial class dbdsfsdsfdfvfd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LdapId",
                table: "User");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LdapId",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

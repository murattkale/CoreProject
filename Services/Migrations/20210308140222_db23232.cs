using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Services.Migrations
{
    public partial class db23232 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WorkshopSession",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SectionId = table.Column<int>(type: "int", nullable: false),
                    WorkshopId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreaDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreaUser = table.Column<int>(type: "int", nullable: false),
                    ModUser = table.Column<int>(type: "int", nullable: true),
                    ModDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OrderNo = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsStatus = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    IsState = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkshopSession", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkshopSession_Section_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Section",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkshopSession_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkshopSession_Workshop_WorkshopId",
                        column: x => x.WorkshopId,
                        principalTable: "Workshop",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkshopSession_SectionId",
                table: "WorkshopSession",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkshopSession_UserId",
                table: "WorkshopSession",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkshopSession_WorkshopId",
                table: "WorkshopSession",
                column: "WorkshopId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkshopSession");
        }
    }
}

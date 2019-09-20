using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ef_core_owned_types.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dashboard",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dashboard", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DashboardItem",
                columns: table => new
                {
                    AppViewId = table.Column<string>(nullable: false),
                    DashboardId = table.Column<Guid>(nullable: false),
                    SizeWidth = table.Column<int>(nullable: false),
                    SizeHeight = table.Column<int>(nullable: false),
                    Position_X = table.Column<int>(nullable: false),
                    Position_Y = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DashboardItem", x => new { x.DashboardId, x.AppViewId });
                    table.ForeignKey(
                        name: "FK_DashboardItem_Dashboard_DashboardId",
                        column: x => x.DashboardId,
                        principalTable: "Dashboard",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DashboardItem");

            migrationBuilder.DropTable(
                name: "Dashboard");
        }
    }
}

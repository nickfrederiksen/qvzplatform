using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QVZ.DAL.Migrations
{
    public partial class AddDashboardPanels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationUserReference_Organizations_OrganizationId",
                table: "OrganizationUserReference");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationUserReference_Users_UserId",
                table: "OrganizationUserReference");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrganizationUserReference",
                table: "OrganizationUserReference");

            migrationBuilder.RenameTable(
                name: "OrganizationUserReference",
                newName: "OrganizationUserReferences");

            migrationBuilder.RenameIndex(
                name: "IX_OrganizationUserReference_OrganizationId",
                table: "OrganizationUserReferences",
                newName: "IX_OrganizationUserReferences_OrganizationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrganizationUserReferences",
                table: "OrganizationUserReferences",
                columns: new[] { "UserId", "OrganizationId" });

            migrationBuilder.CreateTable(
                name: "DashboardPanelTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DashboardPanelTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DashboardPanels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    DashboardId = table.Column<int>(nullable: false),
                    TypeId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DashboardPanels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DashboardPanels_Dashboards_DashboardId",
                        column: x => x.DashboardId,
                        principalTable: "Dashboards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DashboardPanels_DashboardPanelTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "DashboardPanelTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DashboardPanelPosition",
                columns: table => new
                {
                    PanelId = table.Column<int>(nullable: false),
                    Top = table.Column<int>(nullable: false),
                    Left = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DashboardPanelPosition", x => x.PanelId);
                    table.ForeignKey(
                        name: "FK_DashboardPanelPosition_DashboardPanels_PanelId",
                        column: x => x.PanelId,
                        principalTable: "DashboardPanels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DashboardPanelTypes",
                columns: new[] { "Id", "CreatedDate","UpdatedDate", "Guid", "Name" },
                values: new object[] { 1, new DateTime(2020, 4, 8, 12, 12, 37, 805, DateTimeKind.Utc).AddTicks(7045), new DateTime(2020, 4, 8, 12, 12, 37, 805, DateTimeKind.Utc).AddTicks(7045), new Guid("89dbc8b3-3c47-4734-a45d-ae6348982fd5"), "Organizations" });

            migrationBuilder.InsertData(
                table: "DashboardPanelTypes",
                columns: new[] { "Id", "CreatedDate", "UpdatedDate", "Guid", "Name" },
                values: new object[] { 2, new DateTime(2020, 4, 8, 12, 12, 37, 805, DateTimeKind.Utc).AddTicks(7045), new DateTime(2020, 4, 8, 12, 12, 37, 805, DateTimeKind.Utc).AddTicks(7045), new Guid("daa76c7a-02a4-4d4e-8f31-491cf850b996"), "Users" });

            migrationBuilder.CreateIndex(
                name: "IX_DashboardPanels_DashboardId",
                table: "DashboardPanels",
                column: "DashboardId");

            migrationBuilder.CreateIndex(
                name: "IX_DashboardPanels_TypeId",
                table: "DashboardPanels",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationUserReferences_Organizations_OrganizationId",
                table: "OrganizationUserReferences",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationUserReferences_Users_UserId",
                table: "OrganizationUserReferences",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationUserReferences_Organizations_OrganizationId",
                table: "OrganizationUserReferences");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationUserReferences_Users_UserId",
                table: "OrganizationUserReferences");

            migrationBuilder.DropTable(
                name: "DashboardPanelPosition");

            migrationBuilder.DropTable(
                name: "DashboardPanels");

            migrationBuilder.DropTable(
                name: "DashboardPanelTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrganizationUserReferences",
                table: "OrganizationUserReferences");

            migrationBuilder.RenameTable(
                name: "OrganizationUserReferences",
                newName: "OrganizationUserReference");

            migrationBuilder.RenameIndex(
                name: "IX_OrganizationUserReferences_OrganizationId",
                table: "OrganizationUserReference",
                newName: "IX_OrganizationUserReference_OrganizationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrganizationUserReference",
                table: "OrganizationUserReference",
                columns: new[] { "UserId", "OrganizationId" });

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationUserReference_Organizations_OrganizationId",
                table: "OrganizationUserReference",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationUserReference_Users_UserId",
                table: "OrganizationUserReference",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

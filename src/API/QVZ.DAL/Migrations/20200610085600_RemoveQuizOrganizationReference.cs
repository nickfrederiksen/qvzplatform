using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QVZ.DAL.Migrations
{
    public partial class RemoveQuizOrganizationReference : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuizOrganizationReferences");

            migrationBuilder.UpdateData(
                table: "DashboardPanelTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Guid" },
                values: new object[] { new DateTime(2020, 6, 10, 8, 55, 59, 406, DateTimeKind.Utc).AddTicks(7304), new Guid("89dbc8b3-3c47-4734-a45d-ae6348982fd5") });

            migrationBuilder.UpdateData(
                table: "DashboardPanelTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Guid" },
                values: new object[] { new DateTime(2020, 6, 10, 8, 55, 59, 406, DateTimeKind.Utc).AddTicks(7304), new Guid("daa76c7a-02a4-4d4e-8f31-491cf850b996") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QuizOrganizationReferences",
                columns: table => new
                {
                    QuizId = table.Column<int>(type: "int", nullable: false),
                    OrganizationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizOrganizationReferences", x => new { x.QuizId, x.OrganizationId });
                    table.ForeignKey(
                        name: "FK_QuizOrganizationReferences_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuizOrganizationReferences_Quizes_QuizId",
                        column: x => x.QuizId,
                        principalTable: "Quizes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "DashboardPanelTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Guid" },
                values: new object[] { new DateTime(2020, 6, 10, 8, 14, 15, 937, DateTimeKind.Utc).AddTicks(9962), new Guid("89dbc8b3-3c47-4734-a45d-ae6348982fd5") });

            migrationBuilder.UpdateData(
                table: "DashboardPanelTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Guid" },
                values: new object[] { new DateTime(2020, 6, 10, 8, 14, 15, 937, DateTimeKind.Utc).AddTicks(9962), new Guid("daa76c7a-02a4-4d4e-8f31-491cf850b996") });

            migrationBuilder.CreateIndex(
                name: "IX_QuizOrganizationReferences_OrganizationId",
                table: "QuizOrganizationReferences",
                column: "OrganizationId");
        }
    }
}

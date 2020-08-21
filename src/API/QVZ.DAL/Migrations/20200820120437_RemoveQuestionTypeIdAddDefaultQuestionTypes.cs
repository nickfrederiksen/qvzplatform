using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QVZ.DAL.Migrations
{
    public partial class RemoveQuestionTypeIdAddDefaultQuestionTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "QuestionTypes");

            migrationBuilder.UpdateData(
                table: "DashboardPanelTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Guid" },
                values: new object[] { new DateTime(2020, 8, 20, 12, 4, 37, 163, DateTimeKind.Utc).AddTicks(595), new Guid("89dbc8b3-3c47-4734-a45d-ae6348982fd5") });

            migrationBuilder.UpdateData(
                table: "DashboardPanelTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Guid" },
                values: new object[] { new DateTime(2020, 8, 20, 12, 4, 37, 163, DateTimeKind.Utc).AddTicks(595), new Guid("daa76c7a-02a4-4d4e-8f31-491cf850b996") });

            migrationBuilder.InsertData(
                table: "QuestionTypes",
                columns: new[] { "Id", "Guid", "Name" },
                values: new object[,]
                {
                    { 1, new Guid("7396d76a-f778-44cf-97fa-8497db162823"), "Short answer" },
                    { 2, new Guid("0739d67c-5c14-4ece-aea1-193349679614"), "Long answer" },
                    { 3, new Guid("84901edb-e646-4323-9ac4-0e64b634fbde"), "Multiple short answer" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "QuestionTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "QuestionTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "QuestionTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AddColumn<Guid>(
                name: "TypeId",
                table: "QuestionTypes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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
    }
}

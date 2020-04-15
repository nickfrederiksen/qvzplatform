using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QVZ.DAL.Migrations
{
    public partial class AddDashboardPanelDefaults : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "DashboardPanelTypes",
                nullable: false,
                defaultValueSql: "GETUTCDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<Guid>(
                name: "Guid",
                table: "DashboardPanelTypes",
                nullable: false,
                defaultValueSql: "NEWSEQUENTIALID()",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "DashboardPanelTypes",
                nullable: false,
                defaultValueSql: "GETUTCDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "DashboardPanels",
                nullable: false,
                defaultValueSql: "GETUTCDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<Guid>(
                name: "Guid",
                table: "DashboardPanels",
                nullable: false,
                defaultValueSql: "NEWSEQUENTIALID()",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "DashboardPanels",
                nullable: false,
                defaultValueSql: "GETUTCDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "DashboardPanelTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Guid" },
                values: new object[] { new DateTime(2020, 4, 8, 12, 47, 45, 241, DateTimeKind.Utc).AddTicks(3467), new Guid("89dbc8b3-3c47-4734-a45d-ae6348982fd5") });

            migrationBuilder.UpdateData(
                table: "DashboardPanelTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Guid" },
                values: new object[] { new DateTime(2020, 4, 8, 12, 47, 45, 241, DateTimeKind.Utc).AddTicks(3467), new Guid("daa76c7a-02a4-4d4e-8f31-491cf850b996") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "DashboardPanelTypes",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "GETUTCDATE()");

            migrationBuilder.AlterColumn<Guid>(
                name: "Guid",
                table: "DashboardPanelTypes",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValueSql: "NEWSEQUENTIALID()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "DashboardPanelTypes",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "GETUTCDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "DashboardPanels",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "GETUTCDATE()");

            migrationBuilder.AlterColumn<Guid>(
                name: "Guid",
                table: "DashboardPanels",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValueSql: "NEWSEQUENTIALID()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "DashboardPanels",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "GETUTCDATE()");

            migrationBuilder.UpdateData(
                table: "DashboardPanelTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Guid" },
                values: new object[] { new DateTime(2020, 4, 8, 12, 42, 33, 421, DateTimeKind.Utc).AddTicks(4568), new Guid("89dbc8b3-3c47-4734-a45d-ae6348982fd5") });

            migrationBuilder.UpdateData(
                table: "DashboardPanelTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Guid" },
                values: new object[] { new DateTime(2020, 4, 8, 12, 42, 33, 421, DateTimeKind.Utc).AddTicks(4568), new Guid("daa76c7a-02a4-4d4e-8f31-491cf850b996") });
        }
    }
}

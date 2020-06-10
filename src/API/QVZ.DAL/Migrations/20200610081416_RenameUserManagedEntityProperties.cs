using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QVZ.DAL.Migrations
{
    public partial class RenameUserManagedEntityProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Users_UserCreatedById",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Users_UserUpdatedById",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_Dashboards_Users_UserCreatedById",
                table: "Dashboards");

            migrationBuilder.DropForeignKey(
                name: "FK_Dashboards_Users_UserUpdatedById",
                table: "Dashboards");

            migrationBuilder.DropForeignKey(
                name: "FK_Organizations_Users_UserCreatedById",
                table: "Organizations");

            migrationBuilder.DropForeignKey(
                name: "FK_Organizations_Users_UserUpdatedById",
                table: "Organizations");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Users_UserCreatedById",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Users_UserUpdatedById",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_Quizes_Users_UserCreatedById",
                table: "Quizes");

            migrationBuilder.DropForeignKey(
                name: "FK_Quizes_Users_UserUpdatedById",
                table: "Quizes");

            migrationBuilder.DropForeignKey(
                name: "FK_Rounds_Users_UserCreatedById",
                table: "Rounds");

            migrationBuilder.DropForeignKey(
                name: "FK_Rounds_Users_UserUpdatedById",
                table: "Rounds");

            migrationBuilder.DropIndex(
                name: "IX_Rounds_UserCreatedById",
                table: "Rounds");

            migrationBuilder.DropIndex(
                name: "IX_Rounds_UserUpdatedById",
                table: "Rounds");

            migrationBuilder.DropIndex(
                name: "IX_Quizes_UserCreatedById",
                table: "Quizes");

            migrationBuilder.DropIndex(
                name: "IX_Quizes_UserUpdatedById",
                table: "Quizes");

            migrationBuilder.DropIndex(
                name: "IX_Questions_UserCreatedById",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_UserUpdatedById",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Organizations_UserCreatedById",
                table: "Organizations");

            migrationBuilder.DropIndex(
                name: "IX_Organizations_UserUpdatedById",
                table: "Organizations");

            migrationBuilder.DropIndex(
                name: "IX_Dashboards_UserCreatedById",
                table: "Dashboards");

            migrationBuilder.DropIndex(
                name: "IX_Dashboards_UserUpdatedById",
                table: "Dashboards");

            migrationBuilder.DropIndex(
                name: "IX_Answers_UserCreatedById",
                table: "Answers");

            migrationBuilder.DropIndex(
                name: "IX_Answers_UserUpdatedById",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "UserCreatedById",
                table: "Rounds");

            migrationBuilder.DropColumn(
                name: "UserUpdatedById",
                table: "Rounds");

            migrationBuilder.DropColumn(
                name: "UserCreatedById",
                table: "Quizes");

            migrationBuilder.DropColumn(
                name: "UserUpdatedById",
                table: "Quizes");

            migrationBuilder.DropColumn(
                name: "UserCreatedById",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "UserUpdatedById",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "UserCreatedById",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "UserUpdatedById",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "UserCreatedById",
                table: "Dashboards");

            migrationBuilder.DropColumn(
                name: "UserUpdatedById",
                table: "Dashboards");

            migrationBuilder.DropColumn(
                name: "UserCreatedById",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "UserUpdatedById",
                table: "Answers");

            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "Rounds",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedById",
                table: "Rounds",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "Quizes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedById",
                table: "Quizes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "Questions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedById",
                table: "Questions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "Organizations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedById",
                table: "Organizations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "Dashboards",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedById",
                table: "Dashboards",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "Answers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedById",
                table: "Answers",
                nullable: false,
                defaultValue: 0);

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
                name: "IX_Rounds_CreatedById",
                table: "Rounds",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Rounds_UpdatedById",
                table: "Rounds",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Quizes_CreatedById",
                table: "Quizes",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Quizes_UpdatedById",
                table: "Quizes",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_CreatedById",
                table: "Questions",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_UpdatedById",
                table: "Questions",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_CreatedById",
                table: "Organizations",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_UpdatedById",
                table: "Organizations",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Dashboards_CreatedById",
                table: "Dashboards",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Dashboards_UpdatedById",
                table: "Dashboards",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Answers_CreatedById",
                table: "Answers",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Answers_UpdatedById",
                table: "Answers",
                column: "UpdatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Users_CreatedById",
                table: "Answers",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Users_UpdatedById",
                table: "Answers",
                column: "UpdatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Dashboards_Users_CreatedById",
                table: "Dashboards",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Dashboards_Users_UpdatedById",
                table: "Dashboards",
                column: "UpdatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Organizations_Users_CreatedById",
                table: "Organizations",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Organizations_Users_UpdatedById",
                table: "Organizations",
                column: "UpdatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Users_CreatedById",
                table: "Questions",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Users_UpdatedById",
                table: "Questions",
                column: "UpdatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Quizes_Users_CreatedById",
                table: "Quizes",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Quizes_Users_UpdatedById",
                table: "Quizes",
                column: "UpdatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rounds_Users_CreatedById",
                table: "Rounds",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rounds_Users_UpdatedById",
                table: "Rounds",
                column: "UpdatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Users_CreatedById",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Users_UpdatedById",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_Dashboards_Users_CreatedById",
                table: "Dashboards");

            migrationBuilder.DropForeignKey(
                name: "FK_Dashboards_Users_UpdatedById",
                table: "Dashboards");

            migrationBuilder.DropForeignKey(
                name: "FK_Organizations_Users_CreatedById",
                table: "Organizations");

            migrationBuilder.DropForeignKey(
                name: "FK_Organizations_Users_UpdatedById",
                table: "Organizations");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Users_CreatedById",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Users_UpdatedById",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_Quizes_Users_CreatedById",
                table: "Quizes");

            migrationBuilder.DropForeignKey(
                name: "FK_Quizes_Users_UpdatedById",
                table: "Quizes");

            migrationBuilder.DropForeignKey(
                name: "FK_Rounds_Users_CreatedById",
                table: "Rounds");

            migrationBuilder.DropForeignKey(
                name: "FK_Rounds_Users_UpdatedById",
                table: "Rounds");

            migrationBuilder.DropIndex(
                name: "IX_Rounds_CreatedById",
                table: "Rounds");

            migrationBuilder.DropIndex(
                name: "IX_Rounds_UpdatedById",
                table: "Rounds");

            migrationBuilder.DropIndex(
                name: "IX_Quizes_CreatedById",
                table: "Quizes");

            migrationBuilder.DropIndex(
                name: "IX_Quizes_UpdatedById",
                table: "Quizes");

            migrationBuilder.DropIndex(
                name: "IX_Questions_CreatedById",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_UpdatedById",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Organizations_CreatedById",
                table: "Organizations");

            migrationBuilder.DropIndex(
                name: "IX_Organizations_UpdatedById",
                table: "Organizations");

            migrationBuilder.DropIndex(
                name: "IX_Dashboards_CreatedById",
                table: "Dashboards");

            migrationBuilder.DropIndex(
                name: "IX_Dashboards_UpdatedById",
                table: "Dashboards");

            migrationBuilder.DropIndex(
                name: "IX_Answers_CreatedById",
                table: "Answers");

            migrationBuilder.DropIndex(
                name: "IX_Answers_UpdatedById",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Rounds");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "Rounds");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Quizes");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "Quizes");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Dashboards");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "Dashboards");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "Answers");

            migrationBuilder.AddColumn<int>(
                name: "UserCreatedById",
                table: "Rounds",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserUpdatedById",
                table: "Rounds",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserCreatedById",
                table: "Quizes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserUpdatedById",
                table: "Quizes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserCreatedById",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserUpdatedById",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserCreatedById",
                table: "Organizations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserUpdatedById",
                table: "Organizations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserCreatedById",
                table: "Dashboards",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserUpdatedById",
                table: "Dashboards",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserCreatedById",
                table: "Answers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserUpdatedById",
                table: "Answers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "DashboardPanelTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Guid" },
                values: new object[] { new DateTime(2020, 6, 8, 13, 59, 13, 517, DateTimeKind.Utc).AddTicks(708), new Guid("89dbc8b3-3c47-4734-a45d-ae6348982fd5") });

            migrationBuilder.UpdateData(
                table: "DashboardPanelTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Guid" },
                values: new object[] { new DateTime(2020, 6, 8, 13, 59, 13, 517, DateTimeKind.Utc).AddTicks(708), new Guid("daa76c7a-02a4-4d4e-8f31-491cf850b996") });

            migrationBuilder.CreateIndex(
                name: "IX_Rounds_UserCreatedById",
                table: "Rounds",
                column: "UserCreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Rounds_UserUpdatedById",
                table: "Rounds",
                column: "UserUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Quizes_UserCreatedById",
                table: "Quizes",
                column: "UserCreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Quizes_UserUpdatedById",
                table: "Quizes",
                column: "UserUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_UserCreatedById",
                table: "Questions",
                column: "UserCreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_UserUpdatedById",
                table: "Questions",
                column: "UserUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_UserCreatedById",
                table: "Organizations",
                column: "UserCreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_UserUpdatedById",
                table: "Organizations",
                column: "UserUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Dashboards_UserCreatedById",
                table: "Dashboards",
                column: "UserCreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Dashboards_UserUpdatedById",
                table: "Dashboards",
                column: "UserUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Answers_UserCreatedById",
                table: "Answers",
                column: "UserCreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Answers_UserUpdatedById",
                table: "Answers",
                column: "UserUpdatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Users_UserCreatedById",
                table: "Answers",
                column: "UserCreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Users_UserUpdatedById",
                table: "Answers",
                column: "UserUpdatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Dashboards_Users_UserCreatedById",
                table: "Dashboards",
                column: "UserCreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Dashboards_Users_UserUpdatedById",
                table: "Dashboards",
                column: "UserUpdatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Organizations_Users_UserCreatedById",
                table: "Organizations",
                column: "UserCreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Organizations_Users_UserUpdatedById",
                table: "Organizations",
                column: "UserUpdatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Users_UserCreatedById",
                table: "Questions",
                column: "UserCreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Users_UserUpdatedById",
                table: "Questions",
                column: "UserUpdatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Quizes_Users_UserCreatedById",
                table: "Quizes",
                column: "UserCreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Quizes_Users_UserUpdatedById",
                table: "Quizes",
                column: "UserUpdatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rounds_Users_UserCreatedById",
                table: "Rounds",
                column: "UserCreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rounds_Users_UserUpdatedById",
                table: "Rounds",
                column: "UserUpdatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

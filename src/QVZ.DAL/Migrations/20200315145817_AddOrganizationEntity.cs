using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QVZ.DAL.Migrations
{
    public partial class AddOrganizationEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<Guid>(nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UserCreatedById = table.Column<int>(nullable: false),
                    UserUpdatedById = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 120, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Organizations_Users_UserCreatedById",
                        column: x => x.UserCreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Organizations_Users_UserUpdatedById",
                        column: x => x.UserUpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrganizationUserReference",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    OrganizationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationUserReference", x => new { x.UserId, x.OrganizationId });
                    table.ForeignKey(
                        name: "FK_OrganizationUserReference_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrganizationUserReference_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_UserCreatedById",
                table: "Organizations",
                column: "UserCreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_UserUpdatedById",
                table: "Organizations",
                column: "UserUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationUserReference_OrganizationId",
                table: "OrganizationUserReference",
                column: "OrganizationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrganizationUserReference");

            migrationBuilder.DropTable(
                name: "Organizations");
        }
    }
}

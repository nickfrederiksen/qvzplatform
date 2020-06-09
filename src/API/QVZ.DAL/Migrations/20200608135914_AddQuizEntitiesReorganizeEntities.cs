using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QVZ.DAL.Migrations
{
    public partial class AddQuizEntitiesReorganizeEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QuestionTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<Guid>(nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    Name = table.Column<string>(maxLength: 60, nullable: false),
                    TypeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Quizes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<Guid>(nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UserCreatedById = table.Column<int>(nullable: false),
                    UserUpdatedById = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 60, nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quizes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Quizes_Users_UserCreatedById",
                        column: x => x.UserCreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Quizes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Quizes_Users_UserUpdatedById",
                        column: x => x.UserUpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QuizOrganizationReferences",
                columns: table => new
                {
                    QuizId = table.Column<int>(nullable: false),
                    OrganizationId = table.Column<int>(nullable: false)
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

            migrationBuilder.CreateTable(
                name: "Rounds",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<Guid>(nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UserCreatedById = table.Column<int>(nullable: false),
                    UserUpdatedById = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 60, nullable: false),
                    SortOrder = table.Column<int>(nullable: false),
                    QuizId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rounds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rounds_Quizes_QuizId",
                        column: x => x.QuizId,
                        principalTable: "Quizes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rounds_Users_UserCreatedById",
                        column: x => x.UserCreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rounds_Users_UserUpdatedById",
                        column: x => x.UserUpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<Guid>(nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UserCreatedById = table.Column<int>(nullable: false),
                    UserUpdatedById = table.Column<int>(nullable: false),
                    Text = table.Column<string>(maxLength: 256, nullable: false),
                    CorrectAnswer = table.Column<string>(maxLength: 512, nullable: false),
                    Points = table.Column<int>(nullable: false),
                    TypeId = table.Column<int>(nullable: false),
                    RoundId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_Rounds_RoundId",
                        column: x => x.RoundId,
                        principalTable: "Rounds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Questions_QuestionTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "QuestionTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Questions_Users_UserCreatedById",
                        column: x => x.UserCreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Questions_Users_UserUpdatedById",
                        column: x => x.UserUpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<Guid>(nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UserCreatedById = table.Column<int>(nullable: false),
                    UserUpdatedById = table.Column<int>(nullable: false),
                    Value = table.Column<string>(maxLength: 512, nullable: false),
                    OrganizationId = table.Column<int>(nullable: false),
                    QuestionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Answers_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Answers_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Answers_Users_UserCreatedById",
                        column: x => x.UserCreatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Answers_Users_UserUpdatedById",
                        column: x => x.UserUpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
                name: "IX_Answers_OrganizationId",
                table: "Answers",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Answers_QuestionId",
                table: "Answers",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Answers_UserCreatedById",
                table: "Answers",
                column: "UserCreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Answers_UserUpdatedById",
                table: "Answers",
                column: "UserUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_RoundId",
                table: "Questions",
                column: "RoundId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_TypeId",
                table: "Questions",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_UserCreatedById",
                table: "Questions",
                column: "UserCreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_UserUpdatedById",
                table: "Questions",
                column: "UserUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Quizes_UserCreatedById",
                table: "Quizes",
                column: "UserCreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Quizes_UserId",
                table: "Quizes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Quizes_UserUpdatedById",
                table: "Quizes",
                column: "UserUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_QuizOrganizationReferences_OrganizationId",
                table: "QuizOrganizationReferences",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Rounds_QuizId",
                table: "Rounds",
                column: "QuizId");

            migrationBuilder.CreateIndex(
                name: "IX_Rounds_UserCreatedById",
                table: "Rounds",
                column: "UserCreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Rounds_UserUpdatedById",
                table: "Rounds",
                column: "UserUpdatedById");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "QuizOrganizationReferences");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Rounds");

            migrationBuilder.DropTable(
                name: "QuestionTypes");

            migrationBuilder.DropTable(
                name: "Quizes");

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
    }
}

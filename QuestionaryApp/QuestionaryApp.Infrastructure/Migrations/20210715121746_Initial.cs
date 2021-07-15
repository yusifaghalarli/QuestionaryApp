using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QuestionaryApp.Infrastructure.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HasMultiSelect = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Answers_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Choices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Choices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Choices_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SelectedChoice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnswerId = table.Column<int>(type: "int", nullable: false),
                    ChoiceId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SelectedChoice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SelectedChoice_Answers_AnswerId",
                        column: x => x.AnswerId,
                        principalTable: "Answers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "CreatedDate", "HasMultiSelect", "Text" },
                values: new object[] { 1, new DateTime(2021, 7, 15, 12, 17, 46, 403, DateTimeKind.Utc).AddTicks(7937), true, "3+3?" });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "CreatedDate", "HasMultiSelect", "Text" },
                values: new object[] { 2, new DateTime(2021, 7, 15, 12, 17, 46, 404, DateTimeKind.Utc).AddTicks(6680), true, "7+4?" });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "CreatedDate", "HasMultiSelect", "Text" },
                values: new object[] { 3, new DateTime(2021, 7, 15, 12, 17, 46, 404, DateTimeKind.Utc).AddTicks(6751), true, "How old are you?" });

            migrationBuilder.InsertData(
                table: "Choices",
                columns: new[] { "Id", "CreatedDate", "QuestionId", "Text" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 7, 15, 12, 17, 46, 403, DateTimeKind.Utc).AddTicks(5833), 1, "6" },
                    { 2, new DateTime(2021, 7, 15, 12, 17, 46, 403, DateTimeKind.Utc).AddTicks(7360), 1, "9" },
                    { 3, new DateTime(2021, 7, 15, 12, 17, 46, 403, DateTimeKind.Utc).AddTicks(7364), 1, "12" },
                    { 4, new DateTime(2021, 7, 15, 12, 17, 46, 403, DateTimeKind.Utc).AddTicks(7365), 2, "11" },
                    { 5, new DateTime(2021, 7, 15, 12, 17, 46, 403, DateTimeKind.Utc).AddTicks(7366), 2, "15" },
                    { 6, new DateTime(2021, 7, 15, 12, 17, 46, 403, DateTimeKind.Utc).AddTicks(7369), 2, "17" },
                    { 7, new DateTime(2021, 7, 15, 12, 17, 46, 403, DateTimeKind.Utc).AddTicks(7370), 3, "8-20" },
                    { 8, new DateTime(2021, 7, 15, 12, 17, 46, 403, DateTimeKind.Utc).AddTicks(7371), 3, "21-45" },
                    { 9, new DateTime(2021, 7, 15, 12, 17, 46, 403, DateTimeKind.Utc).AddTicks(7372), 3, "45-70" },
                    { 10, new DateTime(2021, 7, 15, 12, 17, 46, 403, DateTimeKind.Utc).AddTicks(7373), 3, "70+" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_QuestionId",
                table: "Answers",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Choices_QuestionId",
                table: "Choices",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_SelectedChoice_AnswerId",
                table: "SelectedChoice",
                column: "AnswerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Choices");

            migrationBuilder.DropTable(
                name: "SelectedChoice");

            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "Questions");
        }
    }
}

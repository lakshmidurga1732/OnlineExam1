using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineExam1.Migrations
{
    public partial class create7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserResponses",
                columns: table => new
                {
                    ResponseID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TestID = table.Column<int>(type: "int", nullable: false),
                    QuestionID = table.Column<int>(type: "int", nullable: false),
                    UserAnswer = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserResponses", x => x.ResponseID);
                    table.ForeignKey(
                        name: "FK_UserResponses_QuestionBanks_QuestionID",
                        column: x => x.QuestionID,
                        principalTable: "QuestionBanks",
                        principalColumn: "QuestionID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_UserResponses_TestStructures_TestID",
                        column: x => x.TestID,
                        principalTable: "TestStructures",
                        principalColumn: "TestID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserResponses_QuestionID",
                table: "UserResponses",
                column: "QuestionID");

            migrationBuilder.CreateIndex(
                name: "IX_UserResponses_TestID",
                table: "UserResponses",
                column: "TestID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserResponses");
        }
    }
}

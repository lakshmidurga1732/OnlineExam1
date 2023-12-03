using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineExam1.Migrations
{
    public partial class create4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionBank_Subjects_SubjectID",
                table: "QuestionBank");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuestionBank",
                table: "QuestionBank");

            migrationBuilder.RenameTable(
                name: "QuestionBank",
                newName: "QuestionBanks");

            migrationBuilder.RenameIndex(
                name: "IX_QuestionBank_SubjectID",
                table: "QuestionBanks",
                newName: "IX_QuestionBanks_SubjectID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuestionBanks",
                table: "QuestionBanks",
                column: "QuestionID");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionBanks_Subjects_SubjectID",
                table: "QuestionBanks",
                column: "SubjectID",
                principalTable: "Subjects",
                principalColumn: "SubjectID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionBanks_Subjects_SubjectID",
                table: "QuestionBanks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuestionBanks",
                table: "QuestionBanks");

            migrationBuilder.RenameTable(
                name: "QuestionBanks",
                newName: "QuestionBank");

            migrationBuilder.RenameIndex(
                name: "IX_QuestionBanks_SubjectID",
                table: "QuestionBank",
                newName: "IX_QuestionBank_SubjectID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuestionBank",
                table: "QuestionBank",
                column: "QuestionID");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionBank_Subjects_SubjectID",
                table: "QuestionBank",
                column: "SubjectID",
                principalTable: "Subjects",
                principalColumn: "SubjectID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

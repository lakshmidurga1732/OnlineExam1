using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineExam1.Migrations
{
    public partial class create5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TestStructures",
                columns: table => new
                {
                    TestID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SiteID = table.Column<int>(type: "int", nullable: false),
                    TestName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    NoOfQuestions = table.Column<int>(type: "int", nullable: false),
                    TotalMarks = table.Column<int>(type: "int", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestStructures", x => x.TestID);
                    table.ForeignKey(
                        name: "FK_TestStructures_Sites_SiteID",
                        column: x => x.SiteID,
                        principalTable: "Sites",
                        principalColumn: "SiteID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TestStructures_SiteID",
                table: "TestStructures",
                column: "SiteID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestStructures");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineExam1.Migrations
{
    public partial class create6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssignedTests",
                columns: table => new
                {
                    AssignmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TestID = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "char(5)", nullable: false),
                    ScheduledDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignedTests", x => x.AssignmentID);
                    table.ForeignKey(
                        name: "FK_AssignedTests_TestStructures_TestID",
                        column: x => x.TestID,
                        principalTable: "TestStructures",
                        principalColumn: "TestID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_AssignedTests_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssignedTests_TestID",
                table: "AssignedTests",
                column: "TestID");

            migrationBuilder.CreateIndex(
                name: "IX_AssignedTests_UserId",
                table: "AssignedTests",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssignedTests");
        }
    }
}

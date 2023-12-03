using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineExam1.Migrations
{
    public partial class create2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "char(5)", maxLength: 5, nullable: false),
                    Username = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    Role = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    SiteID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Sites_SiteID",
                        column: x => x.SiteID,
                        principalTable: "Sites",
                        principalColumn: "SiteID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_SiteID",
                table: "Users",
                column: "SiteID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

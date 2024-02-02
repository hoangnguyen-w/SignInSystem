using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SignInSystem.Migrations
{
    public partial class FixLogic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClassID",
                table: "Teachers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_ClassID",
                table: "Teachers",
                column: "ClassID");

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Classes_ClassID",
                table: "Teachers",
                column: "ClassID",
                principalTable: "Classes",
                principalColumn: "ClassID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Classes_ClassID",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_ClassID",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "ClassID",
                table: "Teachers");
        }
    }
}

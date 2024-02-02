using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SignInSystem.Migrations
{
    public partial class FixLogic1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Teachers_TeacherID1",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_TeacherID1",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "TeacherID1",
                table: "Teachers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TeacherID1",
                table: "Teachers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_TeacherID1",
                table: "Teachers",
                column: "TeacherID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Teachers_TeacherID1",
                table: "Teachers",
                column: "TeacherID1",
                principalTable: "Teachers",
                principalColumn: "TeacherID");
        }
    }
}

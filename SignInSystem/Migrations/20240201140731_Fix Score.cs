using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SignInSystem.Migrations
{
    public partial class FixScore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubjectID",
                table: "Scores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Scores_SubjectID",
                table: "Scores",
                column: "SubjectID");

            migrationBuilder.AddForeignKey(
                name: "FK_Scores_Subjects_SubjectID",
                table: "Scores",
                column: "SubjectID",
                principalTable: "Subjects",
                principalColumn: "SubjectID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Scores_Subjects_SubjectID",
                table: "Scores");

            migrationBuilder.DropIndex(
                name: "IX_Scores_SubjectID",
                table: "Scores");

            migrationBuilder.DropColumn(
                name: "SubjectID",
                table: "Scores");
        }
    }
}

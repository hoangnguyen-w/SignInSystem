using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SignInSystem.Migrations
{
    public partial class AddEntityHolidayVsSalary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TeacherID1",
                table: "Teachers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Holidays",
                columns: table => new
                {
                    HolidayID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HolidayName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HolidayReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HolidayDateStart = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HolidayDateEnd = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Holidays", x => x.HolidayID);
                });

            migrationBuilder.CreateTable(
                name: "Salaries",
                columns: table => new
                {
                    SalaryID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LecturerSalaryPercentStudent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SalaryAllowance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalSalary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeacherID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salaries", x => x.SalaryID);
                    table.ForeignKey(
                        name: "FK_Salaries_Teachers_TeacherID",
                        column: x => x.TeacherID,
                        principalTable: "Teachers",
                        principalColumn: "TeacherID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_TeacherID1",
                table: "Teachers",
                column: "TeacherID1");

            migrationBuilder.CreateIndex(
                name: "IX_Salaries_TeacherID",
                table: "Salaries",
                column: "TeacherID");

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Teachers_TeacherID1",
                table: "Teachers",
                column: "TeacherID1",
                principalTable: "Teachers",
                principalColumn: "TeacherID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Teachers_TeacherID1",
                table: "Teachers");

            migrationBuilder.DropTable(
                name: "Holidays");

            migrationBuilder.DropTable(
                name: "Salaries");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_TeacherID1",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "TeacherID1",
                table: "Teachers");
        }
    }
}

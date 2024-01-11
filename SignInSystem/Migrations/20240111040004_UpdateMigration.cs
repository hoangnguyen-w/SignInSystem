using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SignInSystem.Migrations
{
    public partial class UpdateMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "SubjectID", "SubjectName", "Time" },
                values: new object[] { 1, "Cờ Tướng - Cờ Vua", new TimeSpan(0, 1, 30, 0, 0) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "SubjectID",
                keyValue: 1);
        }
    }
}

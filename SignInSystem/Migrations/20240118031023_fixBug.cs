using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SignInSystem.Migrations
{
    public partial class fixBug : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tuitions_TuitionTypes_TuitionTypeID",
                table: "Tuitions");

            migrationBuilder.AlterColumn<int>(
                name: "TuitionTypeID",
                table: "Tuitions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<float>(
                name: "TotalPrice",
                table: "Tuitions",
                type: "real",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<int>(
                name: "StatusTuition",
                table: "Tuitions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: "STU-01",
                column: "RoleID",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "TeacherID",
                keyValue: "TEA-01",
                column: "RoleID",
                value: 3);

            migrationBuilder.AddForeignKey(
                name: "FK_Tuitions_TuitionTypes_TuitionTypeID",
                table: "Tuitions",
                column: "TuitionTypeID",
                principalTable: "TuitionTypes",
                principalColumn: "TuitionTypeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tuitions_TuitionTypes_TuitionTypeID",
                table: "Tuitions");

            migrationBuilder.AlterColumn<int>(
                name: "TuitionTypeID",
                table: "Tuitions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "TotalPrice",
                table: "Tuitions",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StatusTuition",
                table: "Tuitions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: "STU-01",
                column: "RoleID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "TeacherID",
                keyValue: "TEA-01",
                column: "RoleID",
                value: 1);

            migrationBuilder.AddForeignKey(
                name: "FK_Tuitions_TuitionTypes_TuitionTypeID",
                table: "Tuitions",
                column: "TuitionTypeID",
                principalTable: "TuitionTypes",
                principalColumn: "TuitionTypeID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

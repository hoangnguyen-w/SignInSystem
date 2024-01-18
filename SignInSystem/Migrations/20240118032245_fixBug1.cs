using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SignInSystem.Migrations
{
    public partial class fixBug1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AccountName",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountName",
                table: "Accounts");
        }
    }
}

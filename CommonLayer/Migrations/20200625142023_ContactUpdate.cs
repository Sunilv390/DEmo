using Microsoft.EntityFrameworkCore.Migrations;

namespace CommonLayer.Migrations
{
    public partial class ContactUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "Contact",
                table: "EmployeeDatas",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Contact",
                table: "EmployeeDatas",
                nullable: false,
                oldClrType: typeof(long));
        }
    }
}

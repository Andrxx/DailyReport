using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DailyReport.Migrations
{
    /// <inheritdoc />
    public partial class DepartmentChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Allias",
                table: "Departments",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Departments",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ShowOrder",
                table: "Departments",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Allias",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "ShowOrder",
                table: "Departments");
        }
    }
}

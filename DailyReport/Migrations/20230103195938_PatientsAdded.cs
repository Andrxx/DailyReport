using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DailyReport.Migrations
{
    public partial class PatientsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OutcomingPatients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: true),
                    Shipped = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Diagnos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubmitedFrom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubmitedTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutcomingPatients", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OutcomingPatients");
        }
    }
}

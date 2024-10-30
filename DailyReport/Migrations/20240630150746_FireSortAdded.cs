using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DailyReport.Migrations
{
    /// <inheritdoc />
    public partial class FireSortAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ShowOrder",
                table: "FireReports",
                type: "INTEGER",
                nullable: true);
            migrationBuilder.DropTable(
                name: "Lines");

            migrationBuilder.DropTable(
                name: "LineTypes");

            migrationBuilder.DropTable(
                name: "ReportLines");

            //migrationBuilder.DropColumn(
            //    name: "IFSO",
            //    table: "FinalReports");

            //migrationBuilder.DropColumn(
            //    name: "IFSOChildren",
            //    table: "FinalReports");

            //migrationBuilder.DropColumn(
            //    name: "IFSO",
            //    table: "DepReports");

            //migrationBuilder.DropColumn(
            //    name: "IFSOChildren",
            //    table: "DepReports");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShowOrder",
                table: "FireReports");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DailyReport.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DepReports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    depNumber = table.Column<int>(type: "int", nullable: false),
                    existed = table.Column<int>(type: "int", nullable: false),
                    existedChildrens = table.Column<int>(type: "int", nullable: false),
                    income = table.Column<int>(type: "int", nullable: false),
                    incomeChildrens = table.Column<int>(type: "int", nullable: false),
                    outcome = table.Column<int>(type: "int", nullable: false),
                    outcomeChildrens = table.Column<int>(type: "int", nullable: false),
                    movedOutDep = table.Column<int>(type: "int", nullable: false),
                    movedOutDepChildrens = table.Column<int>(type: "int", nullable: false),
                    movedInDep = table.Column<int>(type: "int", nullable: false),
                    movedInDepChildrens = table.Column<int>(type: "int", nullable: false),
                    died = table.Column<int>(type: "int", nullable: false),
                    diedChildrens = table.Column<int>(type: "int", nullable: false),
                    present = table.Column<int>(type: "int", nullable: false),
                    presentChildrens = table.Column<int>(type: "int", nullable: false),
                    attachedToORIT = table.Column<int>(type: "int", nullable: false),
                    attachedToORITCildrens = table.Column<int>(type: "int", nullable: false),
                    oIVL = table.Column<int>(type: "int", nullable: false),
                    oIVLChildrens = table.Column<int>(type: "int", nullable: false),
                    oNIVL = table.Column<int>(type: "int", nullable: false),
                    oNIVLChildrens = table.Column<int>(type: "int", nullable: false),
                    oNIVLVPO = table.Column<int>(type: "int", nullable: false),
                    oNIVLVPOChildrens = table.Column<int>(type: "int", nullable: false),
                    oNIVLMask = table.Column<int>(type: "int", nullable: false),
                    oNIVLMaskChildrens = table.Column<int>(type: "int", nullable: false),
                    oMask = table.Column<int>(type: "int", nullable: false),
                    oMaskChildren = table.Column<int>(type: "int", nullable: false),
                    oBrease = table.Column<int>(type: "int", nullable: false),
                    oBreaseChildrens = table.Column<int>(type: "int", nullable: false),
                    pregnant = table.Column<int>(type: "int", nullable: false),
                    pregnantChildrens = table.Column<int>(type: "int", nullable: false),
                    restZone = table.Column<int>(type: "int", nullable: false),
                    restZoneChildrens = table.Column<int>(type: "int", nullable: false),
                    outRegions = table.Column<int>(type: "int", nullable: false),
                    outRegionsChildrens = table.Column<int>(type: "int", nullable: false),
                    forein = table.Column<int>(type: "int", nullable: false),
                    foreinChildrens = table.Column<int>(type: "int", nullable: false),
                    LNR_DNR = table.Column<int>(type: "int", nullable: false),
                    LNR_DNRChildrens = table.Column<int>(type: "int", nullable: false),
                    incomeHospital = table.Column<int>(type: "int", nullable: false),
                    incomeHospitalChildrens = table.Column<int>(type: "int", nullable: false),
                    outcomeHospital = table.Column<int>(type: "int", nullable: false),
                    outcomeHospitalChildrens = table.Column<int>(type: "int", nullable: false),
                    U071 = table.Column<int>(type: "int", nullable: false),
                    U071Childrens = table.Column<int>(type: "int", nullable: false),
                    U072 = table.Column<int>(type: "int", nullable: false),
                    U072Childrens = table.Column<int>(type: "int", nullable: false),
                    ORVI = table.Column<int>(type: "int", nullable: false),
                    ORVIChildrens = table.Column<int>(type: "int", nullable: false),
                    pneumonia = table.Column<int>(type: "int", nullable: false),
                    pneumoniaChildrens = table.Column<int>(type: "int", nullable: false),
                    OKI = table.Column<int>(type: "int", nullable: false),
                    OKIChildrens = table.Column<int>(type: "int", nullable: false),
                    meningit = table.Column<int>(type: "int", nullable: false),
                    meningitChildrens = table.Column<int>(type: "int", nullable: false),
                    hepatit = table.Column<int>(type: "int", nullable: false),
                    hepatitChildrens = table.Column<int>(type: "int", nullable: false),
                    HIV = table.Column<int>(type: "int", nullable: false),
                    HIVCildrens = table.Column<int>(type: "int", nullable: false),
                    other = table.Column<int>(type: "int", nullable: false),
                    otherChildrens = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepReports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DutyDocs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dutyDoc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    departments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dutyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DutyDocs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FinalReports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    existed = table.Column<int>(type: "int", nullable: false),
                    existedChildren = table.Column<int>(type: "int", nullable: false),
                    income = table.Column<int>(type: "int", nullable: false),
                    incomeChildren = table.Column<int>(type: "int", nullable: false),
                    outcome = table.Column<int>(type: "int", nullable: false),
                    outcomeChildren = table.Column<int>(type: "int", nullable: false),
                    attachedToORIT = table.Column<int>(type: "int", nullable: false),
                    attachedToORITChildren = table.Column<int>(type: "int", nullable: false),
                    movedOutDep = table.Column<int>(type: "int", nullable: false),
                    movedOutDepChildren = table.Column<int>(type: "int", nullable: false),
                    movedInDep = table.Column<int>(type: "int", nullable: false),
                    movedInDepChildren = table.Column<int>(type: "int", nullable: false),
                    died = table.Column<int>(type: "int", nullable: false),
                    diedChildren = table.Column<int>(type: "int", nullable: false),
                    present = table.Column<int>(type: "int", nullable: false),
                    presentChildren = table.Column<int>(type: "int", nullable: false),
                    oIVL = table.Column<int>(type: "int", nullable: false),
                    oIVLChildren = table.Column<int>(type: "int", nullable: false),
                    oNIVL = table.Column<int>(type: "int", nullable: false),
                    oNIVLChildren = table.Column<int>(type: "int", nullable: false),
                    oNIVLVPO = table.Column<int>(type: "int", nullable: false),
                    oNIVLVPOChildren = table.Column<int>(type: "int", nullable: false),
                    oNIVLMask = table.Column<int>(type: "int", nullable: false),
                    oNIVLMaskChildren = table.Column<int>(type: "int", nullable: false),
                    oMask = table.Column<int>(type: "int", nullable: false),
                    oMaskChildren = table.Column<int>(type: "int", nullable: false),
                    oBrease = table.Column<int>(type: "int", nullable: false),
                    oBreaseChildren = table.Column<int>(type: "int", nullable: false),
                    pregnant = table.Column<int>(type: "int", nullable: false),
                    pregnantChildren = table.Column<int>(type: "int", nullable: false),
                    restZone = table.Column<int>(type: "int", nullable: false),
                    restZoneChildren = table.Column<int>(type: "int", nullable: false),
                    outRegions = table.Column<int>(type: "int", nullable: false),
                    outRegionsChildren = table.Column<int>(type: "int", nullable: false),
                    forein = table.Column<int>(type: "int", nullable: false),
                    foreinChildren = table.Column<int>(type: "int", nullable: false),
                    LNR_DNR = table.Column<int>(type: "int", nullable: false),
                    LNR_DNRChildren = table.Column<int>(type: "int", nullable: false),
                    incomeHospital = table.Column<int>(type: "int", nullable: false),
                    incomeHospitalChildren = table.Column<int>(type: "int", nullable: false),
                    outcomeHospital = table.Column<int>(type: "int", nullable: false),
                    outcomeHospitalChildren = table.Column<int>(type: "int", nullable: false),
                    U071 = table.Column<int>(type: "int", nullable: false),
                    U071Children = table.Column<int>(type: "int", nullable: false),
                    U072 = table.Column<int>(type: "int", nullable: false),
                    U072Children = table.Column<int>(type: "int", nullable: false),
                    ORVI = table.Column<int>(type: "int", nullable: false),
                    ORVIChildren = table.Column<int>(type: "int", nullable: false),
                    pneumonia = table.Column<int>(type: "int", nullable: false),
                    pneumoniaChildren = table.Column<int>(type: "int", nullable: false),
                    OKI = table.Column<int>(type: "int", nullable: false),
                    OKIChildren = table.Column<int>(type: "int", nullable: false),
                    meningit = table.Column<int>(type: "int", nullable: false),
                    meningitChildren = table.Column<int>(type: "int", nullable: false),
                    hepatit = table.Column<int>(type: "int", nullable: false),
                    hepatitChildren = table.Column<int>(type: "int", nullable: false),
                    HIV = table.Column<int>(type: "int", nullable: false),
                    HIVCildren = table.Column<int>(type: "int", nullable: false),
                    other = table.Column<int>(type: "int", nullable: false),
                    otherChildren = table.Column<int>(type: "int", nullable: false),
                    oSummary = table.Column<int>(type: "int", nullable: false),
                    oSummaryChildren = table.Column<int>(type: "int", nullable: false),
                    nozSummary = table.Column<int>(type: "int", nullable: false),
                    nozSummaryChildren = table.Column<int>(type: "int", nullable: false),
                    presentNonDaycare = table.Column<int>(type: "int", nullable: false),
                    presentNonDaycareChildren = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinalReports", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DepReports");

            migrationBuilder.DropTable(
                name: "DutyDocs");

            migrationBuilder.DropTable(
                name: "FinalReports");
        }
    }
}

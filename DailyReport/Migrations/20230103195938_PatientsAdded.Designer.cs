﻿// <auto-generated />
using System;
using DailyReport.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DailyReport.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20230103195938_PatientsAdded")]
    partial class PatientsAdded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DailyReport.Models.DepReport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("HIV")
                        .HasColumnType("int");

                    b.Property<int>("HIVCildrens")
                        .HasColumnType("int");

                    b.Property<int>("LNR_DNR")
                        .HasColumnType("int");

                    b.Property<int>("LNR_DNRChildrens")
                        .HasColumnType("int");

                    b.Property<int>("OKI")
                        .HasColumnType("int");

                    b.Property<int>("OKIChildrens")
                        .HasColumnType("int");

                    b.Property<int>("ORVI")
                        .HasColumnType("int");

                    b.Property<int>("ORVIChildrens")
                        .HasColumnType("int");

                    b.Property<int>("U071")
                        .HasColumnType("int");

                    b.Property<int>("U071Childrens")
                        .HasColumnType("int");

                    b.Property<int>("U072")
                        .HasColumnType("int");

                    b.Property<int>("U072Childrens")
                        .HasColumnType("int");

                    b.Property<int>("attachedToORIT")
                        .HasColumnType("int");

                    b.Property<int>("attachedToORITCildrens")
                        .HasColumnType("int");

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime2");

                    b.Property<int>("depNumber")
                        .HasColumnType("int");

                    b.Property<int>("died")
                        .HasColumnType("int");

                    b.Property<int>("diedChildrens")
                        .HasColumnType("int");

                    b.Property<int>("existed")
                        .HasColumnType("int");

                    b.Property<int>("existedChildrens")
                        .HasColumnType("int");

                    b.Property<int>("forein")
                        .HasColumnType("int");

                    b.Property<int>("foreinChildrens")
                        .HasColumnType("int");

                    b.Property<int>("grippe")
                        .HasColumnType("int");

                    b.Property<int>("grippeChildrens")
                        .HasColumnType("int");

                    b.Property<int>("hepatit")
                        .HasColumnType("int");

                    b.Property<int>("hepatitChildrens")
                        .HasColumnType("int");

                    b.Property<int>("income")
                        .HasColumnType("int");

                    b.Property<int>("incomeChildrens")
                        .HasColumnType("int");

                    b.Property<int>("incomeHospital")
                        .HasColumnType("int");

                    b.Property<int>("incomeHospitalChildrens")
                        .HasColumnType("int");

                    b.Property<int>("meningit")
                        .HasColumnType("int");

                    b.Property<int>("meningitChildrens")
                        .HasColumnType("int");

                    b.Property<int>("movedInDep")
                        .HasColumnType("int");

                    b.Property<int>("movedInDepChildrens")
                        .HasColumnType("int");

                    b.Property<int>("movedOutDep")
                        .HasColumnType("int");

                    b.Property<int>("movedOutDepChildrens")
                        .HasColumnType("int");

                    b.Property<int>("oBrease")
                        .HasColumnType("int");

                    b.Property<int>("oBreaseChildrens")
                        .HasColumnType("int");

                    b.Property<int>("oIVL")
                        .HasColumnType("int");

                    b.Property<int>("oIVLChildrens")
                        .HasColumnType("int");

                    b.Property<int>("oMask")
                        .HasColumnType("int");

                    b.Property<int>("oMaskChildren")
                        .HasColumnType("int");

                    b.Property<int>("oNIVL")
                        .HasColumnType("int");

                    b.Property<int>("oNIVLChildrens")
                        .HasColumnType("int");

                    b.Property<int>("oNIVLMask")
                        .HasColumnType("int");

                    b.Property<int>("oNIVLMaskChildrens")
                        .HasColumnType("int");

                    b.Property<int>("oNIVLVPO")
                        .HasColumnType("int");

                    b.Property<int>("oNIVLVPOChildrens")
                        .HasColumnType("int");

                    b.Property<int>("other")
                        .HasColumnType("int");

                    b.Property<int>("otherChildrens")
                        .HasColumnType("int");

                    b.Property<int>("outRegions")
                        .HasColumnType("int");

                    b.Property<int>("outRegionsChildrens")
                        .HasColumnType("int");

                    b.Property<int>("outcome")
                        .HasColumnType("int");

                    b.Property<int>("outcomeChildrens")
                        .HasColumnType("int");

                    b.Property<int>("outcomeHospital")
                        .HasColumnType("int");

                    b.Property<int>("outcomeHospitalChildrens")
                        .HasColumnType("int");

                    b.Property<int>("pneumonia")
                        .HasColumnType("int");

                    b.Property<int>("pneumoniaChildrens")
                        .HasColumnType("int");

                    b.Property<int>("pregnant")
                        .HasColumnType("int");

                    b.Property<int>("pregnantChildrens")
                        .HasColumnType("int");

                    b.Property<int>("present")
                        .HasColumnType("int");

                    b.Property<int>("presentChildrens")
                        .HasColumnType("int");

                    b.Property<int>("restZone")
                        .HasColumnType("int");

                    b.Property<int>("restZoneChildrens")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("DepReports");
                });

            modelBuilder.Entity("DailyReport.Models.DutyDoc", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("departments")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("dutyDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("dutyDoc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("DutyDocs");
                });

            modelBuilder.Entity("DailyReport.Models.FinalReport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("HIV")
                        .HasColumnType("int");

                    b.Property<int>("HIVCildren")
                        .HasColumnType("int");

                    b.Property<int>("LNR_DNR")
                        .HasColumnType("int");

                    b.Property<int>("LNR_DNRChildren")
                        .HasColumnType("int");

                    b.Property<int>("OKI")
                        .HasColumnType("int");

                    b.Property<int>("OKIChildren")
                        .HasColumnType("int");

                    b.Property<int>("ORVI")
                        .HasColumnType("int");

                    b.Property<int>("ORVIChildren")
                        .HasColumnType("int");

                    b.Property<int>("U071")
                        .HasColumnType("int");

                    b.Property<int>("U071Children")
                        .HasColumnType("int");

                    b.Property<int>("U072")
                        .HasColumnType("int");

                    b.Property<int>("U072Children")
                        .HasColumnType("int");

                    b.Property<int>("attachedToORIT")
                        .HasColumnType("int");

                    b.Property<int>("attachedToORITChildren")
                        .HasColumnType("int");

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime2");

                    b.Property<int>("died")
                        .HasColumnType("int");

                    b.Property<int>("diedChildren")
                        .HasColumnType("int");

                    b.Property<int>("existed")
                        .HasColumnType("int");

                    b.Property<int>("existedChildren")
                        .HasColumnType("int");

                    b.Property<int>("forein")
                        .HasColumnType("int");

                    b.Property<int>("foreinChildren")
                        .HasColumnType("int");

                    b.Property<int>("hepatit")
                        .HasColumnType("int");

                    b.Property<int>("hepatitChildren")
                        .HasColumnType("int");

                    b.Property<int>("income")
                        .HasColumnType("int");

                    b.Property<int>("incomeChildren")
                        .HasColumnType("int");

                    b.Property<int>("incomeHospital")
                        .HasColumnType("int");

                    b.Property<int>("incomeHospitalChildren")
                        .HasColumnType("int");

                    b.Property<int>("meningit")
                        .HasColumnType("int");

                    b.Property<int>("meningitChildren")
                        .HasColumnType("int");

                    b.Property<int>("movedInDep")
                        .HasColumnType("int");

                    b.Property<int>("movedInDepChildren")
                        .HasColumnType("int");

                    b.Property<int>("movedOutDep")
                        .HasColumnType("int");

                    b.Property<int>("movedOutDepChildren")
                        .HasColumnType("int");

                    b.Property<int>("nozSummary")
                        .HasColumnType("int");

                    b.Property<int>("nozSummaryChildren")
                        .HasColumnType("int");

                    b.Property<int>("oBrease")
                        .HasColumnType("int");

                    b.Property<int>("oBreaseChildren")
                        .HasColumnType("int");

                    b.Property<int>("oIVL")
                        .HasColumnType("int");

                    b.Property<int>("oIVLChildren")
                        .HasColumnType("int");

                    b.Property<int>("oMask")
                        .HasColumnType("int");

                    b.Property<int>("oMaskChildren")
                        .HasColumnType("int");

                    b.Property<int>("oNIVL")
                        .HasColumnType("int");

                    b.Property<int>("oNIVLChildren")
                        .HasColumnType("int");

                    b.Property<int>("oNIVLMask")
                        .HasColumnType("int");

                    b.Property<int>("oNIVLMaskChildren")
                        .HasColumnType("int");

                    b.Property<int>("oNIVLVPO")
                        .HasColumnType("int");

                    b.Property<int>("oNIVLVPOChildren")
                        .HasColumnType("int");

                    b.Property<int>("oSummary")
                        .HasColumnType("int");

                    b.Property<int>("oSummaryChildren")
                        .HasColumnType("int");

                    b.Property<int>("other")
                        .HasColumnType("int");

                    b.Property<int>("otherChildren")
                        .HasColumnType("int");

                    b.Property<int>("outRegions")
                        .HasColumnType("int");

                    b.Property<int>("outRegionsChildren")
                        .HasColumnType("int");

                    b.Property<int>("outcome")
                        .HasColumnType("int");

                    b.Property<int>("outcomeChildren")
                        .HasColumnType("int");

                    b.Property<int>("outcomeHospital")
                        .HasColumnType("int");

                    b.Property<int>("outcomeHospitalChildren")
                        .HasColumnType("int");

                    b.Property<int>("pneumonia")
                        .HasColumnType("int");

                    b.Property<int>("pneumoniaChildren")
                        .HasColumnType("int");

                    b.Property<int>("pregnant")
                        .HasColumnType("int");

                    b.Property<int>("pregnantChildren")
                        .HasColumnType("int");

                    b.Property<int>("present")
                        .HasColumnType("int");

                    b.Property<int>("presentChildren")
                        .HasColumnType("int");

                    b.Property<int>("presentNonDaycare")
                        .HasColumnType("int");

                    b.Property<int>("presentNonDaycareChildren")
                        .HasColumnType("int");

                    b.Property<int>("restZone")
                        .HasColumnType("int");

                    b.Property<int>("restZoneChildren")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("FinalReports");
                });

            modelBuilder.Entity("DailyReport.Models.OutcomingPatient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Diagnos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Shipped")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubmitedFrom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubmitedTo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("OutcomingPatietnts");
                });
#pragma warning restore 612, 618
        }
    }
}

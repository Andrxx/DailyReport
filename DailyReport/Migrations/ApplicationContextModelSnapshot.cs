﻿// <auto-generated />
using System;
using DailyReport.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DailyReport.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.2");

            modelBuilder.Entity("DailyReport.Models.DepReport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("HIV")
                        .HasColumnType("INTEGER");

                    b.Property<int>("HIVCildrens")
                        .HasColumnType("INTEGER");

                    b.Property<int>("LNR_DNR")
                        .HasColumnType("INTEGER");

                    b.Property<int>("LNR_DNRChildrens")
                        .HasColumnType("INTEGER");

                    b.Property<int>("OKI")
                        .HasColumnType("INTEGER");

                    b.Property<int>("OKIChildrens")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ORVI")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ORVIChildrens")
                        .HasColumnType("INTEGER");

                    b.Property<int>("U071")
                        .HasColumnType("INTEGER");

                    b.Property<int>("U071Childrens")
                        .HasColumnType("INTEGER");

                    b.Property<int>("U072")
                        .HasColumnType("INTEGER");

                    b.Property<int>("U072Childrens")
                        .HasColumnType("INTEGER");

                    b.Property<int>("attachedToORIT")
                        .HasColumnType("INTEGER");

                    b.Property<int>("attachedToORITCildrens")
                        .HasColumnType("INTEGER");

                    b.Property<int>("care")
                        .HasColumnType("INTEGER");

                    b.Property<int>("careDisodered")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("date")
                        .HasColumnType("TEXT");

                    b.Property<int>("depNumber")
                        .HasColumnType("INTEGER");

                    b.Property<int>("died")
                        .HasColumnType("INTEGER");

                    b.Property<int>("diedChildrens")
                        .HasColumnType("INTEGER");

                    b.Property<string>("dutyNurse")
                        .HasColumnType("TEXT");

                    b.Property<int>("existed")
                        .HasColumnType("INTEGER");

                    b.Property<int>("existedChildren")
                        .HasColumnType("INTEGER");

                    b.Property<int>("forein")
                        .HasColumnType("INTEGER");

                    b.Property<int>("foreinChildrens")
                        .HasColumnType("INTEGER");

                    b.Property<int>("grippe")
                        .HasColumnType("INTEGER");

                    b.Property<int>("grippeChildrens")
                        .HasColumnType("INTEGER");

                    b.Property<int>("hepatit")
                        .HasColumnType("INTEGER");

                    b.Property<int>("hepatitChildrens")
                        .HasColumnType("INTEGER");

                    b.Property<int>("income")
                        .HasColumnType("INTEGER");

                    b.Property<int>("incomeChildrens")
                        .HasColumnType("INTEGER");

                    b.Property<int>("incomeHospital")
                        .HasColumnType("INTEGER");

                    b.Property<int>("incomeHospitalChildrens")
                        .HasColumnType("INTEGER");

                    b.Property<int>("measles")
                        .HasColumnType("INTEGER");

                    b.Property<int>("measlesChildren")
                        .HasColumnType("INTEGER");

                    b.Property<int>("meningit")
                        .HasColumnType("INTEGER");

                    b.Property<int>("meningitChildrens")
                        .HasColumnType("INTEGER");

                    b.Property<int>("movedInDep")
                        .HasColumnType("INTEGER");

                    b.Property<int>("movedInDepChildrens")
                        .HasColumnType("INTEGER");

                    b.Property<int>("movedOutDep")
                        .HasColumnType("INTEGER");

                    b.Property<int>("movedOutDepChildrens")
                        .HasColumnType("INTEGER");

                    b.Property<int>("oBrease")
                        .HasColumnType("INTEGER");

                    b.Property<int>("oBreaseChildrens")
                        .HasColumnType("INTEGER");

                    b.Property<int>("oIVL")
                        .HasColumnType("INTEGER");

                    b.Property<int>("oIVLChildrens")
                        .HasColumnType("INTEGER");

                    b.Property<int>("oMask")
                        .HasColumnType("INTEGER");

                    b.Property<int>("oMaskChildren")
                        .HasColumnType("INTEGER");

                    b.Property<int>("oNIVL")
                        .HasColumnType("INTEGER");

                    b.Property<int>("oNIVLChildrens")
                        .HasColumnType("INTEGER");

                    b.Property<int>("oNIVLMask")
                        .HasColumnType("INTEGER");

                    b.Property<int>("oNIVLMaskChildrens")
                        .HasColumnType("INTEGER");

                    b.Property<int>("oNIVLVPO")
                        .HasColumnType("INTEGER");

                    b.Property<int>("oNIVLVPOChildrens")
                        .HasColumnType("INTEGER");

                    b.Property<int>("other")
                        .HasColumnType("INTEGER");

                    b.Property<int>("otherChildrens")
                        .HasColumnType("INTEGER");

                    b.Property<int>("otherUkrane")
                        .HasColumnType("INTEGER");

                    b.Property<int>("otherUkraneChildren")
                        .HasColumnType("INTEGER");

                    b.Property<int>("outRegions")
                        .HasColumnType("INTEGER");

                    b.Property<int>("outRegionsChildrens")
                        .HasColumnType("INTEGER");

                    b.Property<int>("outcome")
                        .HasColumnType("INTEGER");

                    b.Property<int>("outcomeChildrens")
                        .HasColumnType("INTEGER");

                    b.Property<int>("outcomeHospital")
                        .HasColumnType("INTEGER");

                    b.Property<int>("outcomeHospitalChildrens")
                        .HasColumnType("INTEGER");

                    b.Property<int>("pneumonia")
                        .HasColumnType("INTEGER");

                    b.Property<int>("pneumoniaChildrens")
                        .HasColumnType("INTEGER");

                    b.Property<int>("pregnant")
                        .HasColumnType("INTEGER");

                    b.Property<int>("pregnantChildrens")
                        .HasColumnType("INTEGER");

                    b.Property<int>("present")
                        .HasColumnType("INTEGER");

                    b.Property<int>("presentChildrens")
                        .HasColumnType("INTEGER");

                    b.Property<int>("presentWithCare")
                        .HasColumnType("INTEGER");

                    b.Property<int>("presentWithCareChildren")
                        .HasColumnType("INTEGER");

                    b.Property<int>("restZone")
                        .HasColumnType("INTEGER");

                    b.Property<int>("restZoneChildrens")
                        .HasColumnType("INTEGER");

                    b.Property<int>("sepsis")
                        .HasColumnType("INTEGER");

                    b.Property<int>("sepsisChildren")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("DepReports");
                });

            modelBuilder.Entity("DailyReport.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AdultSpotsQuantity")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ChildrenSpotsQuantity")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Number")
                        .HasColumnType("INTEGER");

                    b.Property<int>("WardQuantity")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("DailyReport.Models.DutyDoc", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("departments")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("dutyDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("dutyDoc")
                        .HasColumnType("TEXT");

                    b.Property<int>("type")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("DutyDocs");
                });

            modelBuilder.Entity("DailyReport.Models.DutyNurse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Phone")
                        .HasColumnType("TEXT");

                    b.Property<int?>("department")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("dutyDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("DutyNurses");
                });

            modelBuilder.Entity("DailyReport.Models.FinalReport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("HIV")
                        .HasColumnType("INTEGER");

                    b.Property<int>("HIVCildren")
                        .HasColumnType("INTEGER");

                    b.Property<int>("LNR_DNR")
                        .HasColumnType("INTEGER");

                    b.Property<int>("LNR_DNRChildren")
                        .HasColumnType("INTEGER");

                    b.Property<int>("OKI")
                        .HasColumnType("INTEGER");

                    b.Property<int>("OKIChildren")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ORVI")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ORVIChildren")
                        .HasColumnType("INTEGER");

                    b.Property<int>("U071")
                        .HasColumnType("INTEGER");

                    b.Property<int>("U071Children")
                        .HasColumnType("INTEGER");

                    b.Property<int>("U072")
                        .HasColumnType("INTEGER");

                    b.Property<int>("U072Children")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ambulance")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ambulanceChildren")
                        .HasColumnType("INTEGER");

                    b.Property<int>("attachedToORIT")
                        .HasColumnType("INTEGER");

                    b.Property<int>("attachedToORITChildren")
                        .HasColumnType("INTEGER");

                    b.Property<int>("care")
                        .HasColumnType("INTEGER");

                    b.Property<int>("careDisodered")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("date")
                        .HasColumnType("TEXT");

                    b.Property<int>("died")
                        .HasColumnType("INTEGER");

                    b.Property<int>("diedChildren")
                        .HasColumnType("INTEGER");

                    b.Property<int>("existed")
                        .HasColumnType("INTEGER");

                    b.Property<int>("existedChildren")
                        .HasColumnType("INTEGER");

                    b.Property<int>("forein")
                        .HasColumnType("INTEGER");

                    b.Property<int>("foreinChildren")
                        .HasColumnType("INTEGER");

                    b.Property<int>("grippe")
                        .HasColumnType("INTEGER");

                    b.Property<int>("grippeChildren")
                        .HasColumnType("INTEGER");

                    b.Property<int>("hepatit")
                        .HasColumnType("INTEGER");

                    b.Property<int>("hepatitChildren")
                        .HasColumnType("INTEGER");

                    b.Property<int>("income")
                        .HasColumnType("INTEGER");

                    b.Property<int>("incomeChildren")
                        .HasColumnType("INTEGER");

                    b.Property<int>("incomeHospital")
                        .HasColumnType("INTEGER");

                    b.Property<int>("incomeHospitalChildren")
                        .HasColumnType("INTEGER");

                    b.Property<int>("measles")
                        .HasColumnType("INTEGER");

                    b.Property<int>("measlesChildren")
                        .HasColumnType("INTEGER");

                    b.Property<int>("meningit")
                        .HasColumnType("INTEGER");

                    b.Property<int>("meningitChildren")
                        .HasColumnType("INTEGER");

                    b.Property<int>("movedInDep")
                        .HasColumnType("INTEGER");

                    b.Property<int>("movedInDepChildren")
                        .HasColumnType("INTEGER");

                    b.Property<int>("movedOutDep")
                        .HasColumnType("INTEGER");

                    b.Property<int>("movedOutDepChildren")
                        .HasColumnType("INTEGER");

                    b.Property<int>("nozSummary")
                        .HasColumnType("INTEGER");

                    b.Property<int>("nozSummaryChildren")
                        .HasColumnType("INTEGER");

                    b.Property<int>("oBrease")
                        .HasColumnType("INTEGER");

                    b.Property<int>("oBreaseChildren")
                        .HasColumnType("INTEGER");

                    b.Property<int>("oIVL")
                        .HasColumnType("INTEGER");

                    b.Property<int>("oIVLChildren")
                        .HasColumnType("INTEGER");

                    b.Property<int>("oMask")
                        .HasColumnType("INTEGER");

                    b.Property<int>("oMaskChildren")
                        .HasColumnType("INTEGER");

                    b.Property<int>("oNIVL")
                        .HasColumnType("INTEGER");

                    b.Property<int>("oNIVLChildren")
                        .HasColumnType("INTEGER");

                    b.Property<int>("oNIVLMask")
                        .HasColumnType("INTEGER");

                    b.Property<int>("oNIVLMaskChildren")
                        .HasColumnType("INTEGER");

                    b.Property<int>("oNIVLVPO")
                        .HasColumnType("INTEGER");

                    b.Property<int>("oNIVLVPOChildren")
                        .HasColumnType("INTEGER");

                    b.Property<int>("oSummary")
                        .HasColumnType("INTEGER");

                    b.Property<int>("oSummaryChildren")
                        .HasColumnType("INTEGER");

                    b.Property<int>("other")
                        .HasColumnType("INTEGER");

                    b.Property<int>("otherChildren")
                        .HasColumnType("INTEGER");

                    b.Property<int>("otherUkrane")
                        .HasColumnType("INTEGER");

                    b.Property<int>("otherUkraneChildren")
                        .HasColumnType("INTEGER");

                    b.Property<int>("outRegions")
                        .HasColumnType("INTEGER");

                    b.Property<int>("outRegionsChildren")
                        .HasColumnType("INTEGER");

                    b.Property<int>("outcome")
                        .HasColumnType("INTEGER");

                    b.Property<int>("outcomeChildren")
                        .HasColumnType("INTEGER");

                    b.Property<int>("outcomeHospital")
                        .HasColumnType("INTEGER");

                    b.Property<int>("outcomeHospitalChildren")
                        .HasColumnType("INTEGER");

                    b.Property<int>("pneumonia")
                        .HasColumnType("INTEGER");

                    b.Property<int>("pneumoniaChildren")
                        .HasColumnType("INTEGER");

                    b.Property<int>("pregnant")
                        .HasColumnType("INTEGER");

                    b.Property<int>("pregnantChildren")
                        .HasColumnType("INTEGER");

                    b.Property<int>("present")
                        .HasColumnType("INTEGER");

                    b.Property<int>("presentChildren")
                        .HasColumnType("INTEGER");

                    b.Property<int>("presentNonDaycare")
                        .HasColumnType("INTEGER");

                    b.Property<int>("presentNonDaycareChildren")
                        .HasColumnType("INTEGER");

                    b.Property<int>("presentWithCare")
                        .HasColumnType("INTEGER");

                    b.Property<int>("presentWithCareChildren")
                        .HasColumnType("INTEGER");

                    b.Property<int>("reject")
                        .HasColumnType("INTEGER");

                    b.Property<int>("rejectChildren")
                        .HasColumnType("INTEGER");

                    b.Property<int>("restZone")
                        .HasColumnType("INTEGER");

                    b.Property<int>("restZoneChildren")
                        .HasColumnType("INTEGER");

                    b.Property<int>("sendToMO")
                        .HasColumnType("INTEGER");

                    b.Property<int>("sendToMOChildren")
                        .HasColumnType("INTEGER");

                    b.Property<int>("sepsis")
                        .HasColumnType("INTEGER");

                    b.Property<int>("sepsisChildren")
                        .HasColumnType("INTEGER");

                    b.Property<int>("sumAdults")
                        .HasColumnType("INTEGER");

                    b.Property<int>("sumAll")
                        .HasColumnType("INTEGER");

                    b.Property<int>("sumChild")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("FinalReports");
                });

            modelBuilder.Entity("DailyReport.Models.FireReport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Adult")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Care")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Children")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<int>("DepNumber")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Personel")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("FireReports");
                });

            modelBuilder.Entity("DailyReport.Models.OutcomingPatient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AgeMonth")
                        .HasColumnType("TEXT");

                    b.Property<string>("AgeYears")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("Diagnos")
                        .HasColumnType("TEXT");

                    b.Property<string>("Gender")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Shipped")
                        .HasColumnType("TEXT");

                    b.Property<string>("SubmitedFrom")
                        .HasColumnType("TEXT");

                    b.Property<string>("SubmitedTo")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("OutcomingPatients");
                });

            modelBuilder.Entity("DailyReport.Models.Personel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Department")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PersType")
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Personels");
                });

            modelBuilder.Entity("DailyReport.Models.WardsModels.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Age")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("AgeMonts")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Department")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Diagnos")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("HasCareRisk")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("HasRash")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("HospitalisationDate")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDisodered")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsUntochable")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Male")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("WardNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("sAge")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("DailyReport.Models.WardsModels.Ward", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("CanPut")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Capacity")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Department")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsDirtyZone")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Wards");
                });
#pragma warning restore 612, 618
        }
    }
}

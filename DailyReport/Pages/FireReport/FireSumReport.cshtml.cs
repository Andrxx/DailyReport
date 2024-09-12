using DailyReport.Models;
using DailyReport.Models.DTO;
using DailyReport.Models.PersonelFolder;
using DailyReport.Services;
using DailyReport.Services.Reports;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using NuGet.Protocol;
using System.Configuration;
using System.Text.Json.Nodes;

namespace DailyReport.Pages.FireReport
{
    public class FireSumReportModel : PageModel
    {
        ApplicationContext context;
        private readonly IConfiguration appConfig;
        public List<Models.Reports.FireReport> reports = new List<Models.Reports.FireReport>();
        public Models.Reports.FireReport labReport;
        public List<DutyNurse> dutyNurses = new List<DutyNurse>();
        public List<Department> activeDepartments { get; set; } = new();
        public List<FullFireReport> fullFireReports { get; set; } = new List<FullFireReport>();



        public FireSumReportModel(ApplicationContext db, IConfiguration configuration)
        {
            context = db;
            appConfig = configuration;
        }

        public List<int> excludedDeps = new();
        public int? RHAllias;

        public void OnGet()
        {
            var ed = appConfig["ExcludedDepartments:FireSumExclusion"];
            try
            {
                if (ed != null) excludedDeps = ed.Split(' ').Select(x => int.Parse(x)).ToList();
                else excludedDeps = new();
            }
            catch { excludedDeps = new(); }

            try
            {
                RHAllias = int.Parse(appConfig["RHAllias"]);
            }
            catch { }


            List<int> actualDeps = new();
            activeDepartments = DepartmentServices.GetSortedDepartments(context, excludedDeps);
            foreach (Department d in activeDepartments)
            {
                actualDeps.Add(d.Allias);
            }
            //дежурная смена
            dutyNurses = DutyServices.GetDutyNurses(context);

            //пожарные сводки
            reports = FireReportServices.GetFilteredReports(context, actualDeps);

            foreach (var department in activeDepartments)
            {
                FullFireReport fullFireReport = new FullFireReport();
                fullFireReport.Department = department;
                List<DutyNurse> _dutyNurses = dutyNurses.FindAll(n => n.department == department.Allias);
                fullFireReport.Nurses = _dutyNurses;
                Models.Reports.FireReport _report = reports.Find(r => r.DepNumber == department.Allias);
                fullFireReport.FireReport = _report;
                fullFireReports.Add(fullFireReport);
            }
            AddDataToList(fullFireReports);
            AddFireReportToList(fullFireReports);
            //добавляем лабораторию
            //тех.персонал и охрана - не редактируется, добавляем 14 сотрудников
            //labReport = new() { DepNumber = 102, Personel = 12, Date = DateTime.Now };
        }

        private bool AddDataToList(List<FullFireReport> fullFireReports)
        {

            
            try
            {
                //метод получения конфига через секцию
                var services = appConfig.GetSection("AddedNurses").Get<List<DutyNurse>>();
                foreach (DutyNurse nurse in services)
                {
                    fullFireReports.Find(ffr => ffr.Department.Allias == nurse.department).Nurses.Add(nurse);
                }
            }
            catch { return false; }

            return true;
        }

        private bool AddFireReportToList(List<FullFireReport> fullFireReports)
        {
            try
            {         
                var additionalReports = appConfig.GetSection("AddedFirereports").Get<List<Models.Reports.FireReport>>();
                foreach (Models.Reports.FireReport ar in additionalReports)
                {
                    ar.Date = DateTime.Now;
                    fullFireReports.Find(ffr => ffr.Department.Allias == ar.DepNumber).FireReport = ar;
                }
            }
            catch { return false; }

            return true;
        }
    }
}
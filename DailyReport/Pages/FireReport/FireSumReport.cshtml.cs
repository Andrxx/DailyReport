using DailyReport.Models;
using DailyReport.Models.DTO;
using DailyReport.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DailyReport.Pages.FireReport
{
    public class FireSumReportModel : PageModel
    {
        ApplicationContext context;
        public List<Models.FireReport> reports = new List<Models.FireReport>();
        public List<DutyNurse> dutyNurses, dutyNurses1, dutyNurses2, dutyNurses3, dutyNurses4, dutyNurses5, dutyNurses6, dutyNurses7,dutyNurses8, dutyNurses90 = new List<DutyNurse>();
        public List<Department> activeDepartments { get; set; } = new();
        public List<FullFireReport> fullFireReports { get; set; } = new List<FullFireReport>();

        public FireSumReportModel(ApplicationContext db){
            context = db;
        }

        public List<int> excludedDeps = new() { 11, 91 };


        public void OnGet()
        {
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
                Models.FireReport _report = reports.Find(r => r.DepNumber == department.Allias);
                fullFireReport.FireReport = _report;
                fullFireReports.Add(fullFireReport);
            }
            //добавляем лабораторию

            //дежурная смена
            //dutyNurses = DutyServices.GetDutyNurses(context);
            //dutyNurses1 = dutyNurses.FindAll(n => n.department == 1);
            //dutyNurses2 = dutyNurses.FindAll(n => n.department == 2);
            //dutyNurses3 = dutyNurses.FindAll(n => n.department == 3);
            //dutyNurses4 = dutyNurses.FindAll(n => n.department == 4);
            //dutyNurses5 = dutyNurses.FindAll(n => n.department == 5);
            //dutyNurses6 = dutyNurses.FindAll(n => n.department == 6);
            //dutyNurses7 = dutyNurses.FindAll(n => n.department == 7);
            //dutyNurses8 = dutyNurses.FindAll(n => n.department == 8);
            //dutyNurses90 = dutyNurses.FindAll(n => n.department == 90);

        }
    }
}

using DailyReport.Models;
using DailyReport.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DailyReport.Pages.FireReport
{
    public class FireSumReportModel : PageModel
    {
        ApplicationContext context;
        public List<Models.FireReport> reports = new List<Models.FireReport>();
        public List<DutyNurse> dutyNurses, dutyNurses1, dutyNurses3, dutyNurses4, dutyNurses5, dutyNurses6, dutyNurses7, dutyNurses90 = new List<DutyNurse>();
        public FireSumReportModel(ApplicationContext db)
            {
                context = db;
            }

        public void OnGet()
        {
            //дежурная смена
            dutyNurses = DutyServices.GetDutyNurses(context);
            dutyNurses1 = dutyNurses.FindAll(n => n.department == 1);
            dutyNurses3 = dutyNurses.FindAll(n => n.department == 3);
            dutyNurses4 = dutyNurses.FindAll(n => n.department == 4);
            dutyNurses5 = dutyNurses.FindAll(n => n.department == 5);
            dutyNurses6 = dutyNurses.FindAll(n => n.department == 6);
            dutyNurses7 = dutyNurses.FindAll(n => n.department == 7);
            dutyNurses90 = dutyNurses.FindAll(n => n.department == 90);


            //пожарные сводки
            reports = FireReportServices.GetFilteredReports(context);
        }
    }
}

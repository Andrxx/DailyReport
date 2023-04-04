using DailyReport.Models;
using DailyReport.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DailyReport.Pages.Admin
{
    public class FireReportsModel : PageModel
    {
        ApplicationContext context;
        public List<Models.FireReport> reports { get; set; }

        public FireReportsModel(ApplicationContext db)
        {
            context = db;
        }
        public void OnGet()
        {
            reports = (from f in context.FireReports
                       select f).ToList();
        }

        public IActionResult OnPostDeleteReport(int id)
        {
            FireReportServices.DeleteFireReport(id, context);
            return RedirectToAction("Get");
        }
    }
}

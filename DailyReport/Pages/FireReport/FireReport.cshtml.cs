using DailyReport.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DailyReport.Pages.FireReport
{
    public class FireReportModel : PageModel
    {
        ApplicationContext context;

        public FireReportModel(ApplicationContext db)
        {
            context = db;
        }
        public void OnGet()
        {
        }
    }
}

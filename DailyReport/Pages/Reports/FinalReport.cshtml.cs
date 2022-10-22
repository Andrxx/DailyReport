using DailyReport.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DailyReport.Pages.Reports
{
    public class FinalReportModel : PageModel
    {
        public void OnGet()
        {
            ApplicationContext context;

            public FinalReportModel(ApplicationContext db)
            {
                context = db;
            }
        }
    }
}

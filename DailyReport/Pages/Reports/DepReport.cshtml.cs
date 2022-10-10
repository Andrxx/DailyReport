using DailyReport.Services;
using DailyReport.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DailyReport.Pages.Reports
{
    public class DepReportModel : PageModel
    {
        public DepReport reportModel = new DepReport();
        public DepReportServise reportServise = new DepReportServise();
        public void OnGet()
        {
            reportModel = reportServise.Get();
        }
    }
}

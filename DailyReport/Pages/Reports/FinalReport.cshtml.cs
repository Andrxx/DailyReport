using DailyReport.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DailyReport.Pages.Reports
{
    public class FinalReportModel : PageModel
    {
        FinalReport _finalReport;
        ApplicationContext context;
        public FinalReportModel(ApplicationContext db)
        {
            context = db;
        }
        public List<DepReport> Reports { get; private set; } = new();
        DateTime actualDate = DateTime.Today.AddDays(-1);
        
        public void OnGet()
        {
            Reports = context.DepReports.AsNoTracking().ToList();

        }
    }
}

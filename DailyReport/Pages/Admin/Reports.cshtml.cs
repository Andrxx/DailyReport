using DailyReport.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DailyReport.Pages.Admin
{
    public class ReportsModel : PageModel
    {
        ApplicationContext context;
        public List<DepReport> _report { get; set; }
        public List<DepReport> Reports { get; private set; } = new();
        DateTime actualDate = DateTime.Today.AddDays(-1);

        public ReportsModel(ApplicationContext db)
        {
            context = db;
        }
        public void OnGet()
        {
            _report = (from report in context.DepReports
                       select report).ToList();
        }
    }
}

using DailyReport.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DailyReport.Pages.Reports
{
    [IgnoreAntiforgeryToken]
    public class ReportModel : PageModel
    {
        ApplicationContext context;
        [BindProperty(SupportsGet = true)]
        public DepReport dReport { get; set; }
        public List<DepReport> Reports { get; private set; } = new();
        public DateTime actualDate = DateTime.Now, reportDate;//.AddDays(-1);
        public List<string> nurses = new();
        public ReportModel(ApplicationContext db)
        {
            context = db;
        }
        public void OnGet()
        {
        }
    }
}

using DailyReport.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace DailyReport.Pages.Reports
{
    public class FinalReportModel : PageModel
    {
        public FinalReport _finalReport;
        public DepReport depReport1, depReport2, depReport3, depReport4, depReport5,
            depReport6, depReport7, depReport8, depReport90, depReport91;
        ApplicationContext context;
        public FinalReportModel(ApplicationContext db)
        {
            context = db;
        }
        public List<DepReport> reports { get; private set; } = new();
        public List<DepReport> _rep = new List<DepReport>();
        DateTime actualDate = DateTime.Today.AddDays(-1);
        
        public void OnGet()
        {
            //_rep = context.DepReports.AsNoTracking().ToList();

            reports = (from report in context.DepReports
                    where (report.date.Date == actualDate)
                    select report).ToList();
#pragma warning disable CS8601 // Возможно, назначение-ссылка, допускающее значение NULL.
            depReport1 = reports.Find(p => p.depNumber == 1);
            depReport2 = reports.Find(p => p.depNumber == 2);
            depReport3 = reports.Find(p => p.depNumber == 3);
            depReport4 = reports.Find(p => p.depNumber == 4);
            depReport5 = reports.Find(p => p.depNumber == 5);
            depReport6 = reports.Find(p => p.depNumber == 6);
            depReport7 = reports.Find(p => p.depNumber == 7);
            depReport8 = reports.Find(p => p.depNumber == 8);
            depReport90 = reports.Find(p => p.depNumber == 90);
            depReport91 = reports.Find(p => p.depNumber == 91);

#pragma warning restore CS8601 // Возможно, назначение-ссылка, допускающее значение NULL.
            if (depReport1 == null) depReport1 = new();
            if (depReport2 == null) depReport2 = new();
            if (depReport3 == null) depReport3 = new();
            if (depReport4 == null) depReport4 = new();
            if (depReport5 == null) depReport5 = new();
            if (depReport6 == null) depReport6 = new();
            if (depReport7 == null) depReport7 = new();
            if (depReport8 == null) depReport8 = new();
            if (depReport90 == null) depReport90 = new();
            if (depReport91 == null) depReport91 = new();

            _finalReport = new();
            foreach(DepReport _rep in reports)
            {
                _finalReport.existed += _rep.existed;
            }
        }
    }
}

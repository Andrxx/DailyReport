using DailyReport.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace DailyReport.Pages.Reports
{
    public class FinalReportModel : PageModel
    {
        FinalReport _finalReport;
        public DepReport depReport1, depReport2, depReport3, depReport4, depReport5,
            depReport6, depReport7, depReport8, depReport90, depReport91;
        ApplicationContext context;
        public FinalReportModel(ApplicationContext db)
        {
            context = db;
        }
        public List<DepReport> Reports { get; private set; } = new();
        public List<DepReport> _rep = new List<DepReport>();
        DateTime actualDate = DateTime.Today.AddDays(-5);
        
        public void OnGet()
        {
            //_rep = context.DepReports.AsNoTracking().ToList();

            Reports = (from report in context.DepReports
                    where (report.date.Date == actualDate)
                    select report).ToList();
#pragma warning disable CS8601 // Возможно, назначение-ссылка, допускающее значение NULL.
            depReport1 = (from report in context.DepReports
                          where (report.date.Date == actualDate)&&(report.depNumber == 1)
                          select report).FirstOrDefault();
            depReport2 = (from report in context.DepReports
                          where (report.date.Date == actualDate) && (report.depNumber == 2)
                          select report).FirstOrDefault();

            depReport3 = (from report in context.DepReports
                          where ((report.date.Date == actualDate) && (report.depNumber == 3))
                          select report).FirstOrDefault();

            depReport4 = (from report in context.DepReports
                          where ((report.date.Date == actualDate) && (report.depNumber == 4))
                          select report).FirstOrDefault();
            depReport5 = (from report in context.DepReports
                          where ((report.date.Date == actualDate) && (report.depNumber == 5))
                          select report).FirstOrDefault();
            depReport6 = (from report in context.DepReports
                          where ((report.date.Date == actualDate) && (report.depNumber == 6))
                          select report).FirstOrDefault();
            depReport7 = (from report in context.DepReports
                          where ((report.date.Date == actualDate) && (report.depNumber == 7))
                          select report).FirstOrDefault();
            depReport8 = (from report in context.DepReports
                          where ((report.date.Date == actualDate) && (report.depNumber == 8))
                          select report).FirstOrDefault();
            depReport90 = (from report in context.DepReports
                          where ((report.date.Date == actualDate) && (report.depNumber == 90))
                          select report).FirstOrDefault();
            depReport91 = (from report in context.DepReports
                          where ((report.date.Date == actualDate) && (report.depNumber == 91))
                          select report).FirstOrDefault();

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
        }
    }
}

using DailyReport.Services;
using DailyReport.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace DailyReport.Pages.Reports
{
    [IgnoreAntiforgeryToken]
    public class DepReportModel : PageModel
    {
        ApplicationContext context;
        [BindProperty]
        public DepReport _report { get; set; }
        public List<DepReport> Reports { get; private set; } = new();
        DateTime actualDate = DateTime.Today.AddDays(-1);
        public DepReportModel(ApplicationContext db)
        {
            context = db;
        }
        public DepReportServise reportServise = new DepReportServise();

        public void OnGet(int? depNumber)
        {
            //Reports = context.DepReports.AsNoTracking().ToList();
            //_report = reportServise.CreateTest();
            
            //падает при очистке БД - обработать для очистки и миграций
            _report = (from report in context.DepReports
                       where (report.depNumber == depNumber) && (report.date.Date == actualDate)
                       select report).FirstOrDefault();
            
            if (_report == null)
            {
                //тест для БД, изменить на создание нового для релиза
                _report = reportServise.CreateTest();
                if (depNumber.HasValue)
                {
                    _report.depNumber = depNumber.Value;
                }
            }
            else
            {
            }
            //OnPostDelete();
        }

        public void OnPostPrevReport(int depNumber)
        {
            //Reports = context.DepReports.AsNoTracking().ToList();
            DateTime lastDate = DateTime.Today.AddDays(-2);
            _report = (from report in context.DepReports
                       where (report.depNumber == depNumber) && (report.date.Date == lastDate)
                       select report).FirstOrDefault();
            if(_report == null )
            {
                _report = new();
                _report.depNumber = depNumber;
                _report.date = DateTime.Today.AddDays(-1);
            };
        }

        public RedirectToPageResult OnPostReport(DepReport _report)
        {
            
            context.DepReports.Update(_report);
         

            context.SaveChanges();
            return RedirectToPage("DepReport", new { depNumber = _report.depNumber });
        }

        public void OnPostDelete()
        {
            var report = context.DepReports.AsNoTracking().ToList();
            foreach (DepReport r in report)
            {
                context.DepReports.Remove(r);
            }
            context.SaveChanges();
        }
    }
}

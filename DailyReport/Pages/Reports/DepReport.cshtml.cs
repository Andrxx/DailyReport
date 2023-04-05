using DailyReport.Services;
using DailyReport.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Linq;

namespace DailyReport.Pages.Reports
{
    [IgnoreAntiforgeryToken]
    public class DepReportModel : PageModel
    {
        ApplicationContext context;
        [BindProperty(SupportsGet = true)]
        public DepReport report { get; set; }
        public List<DepReport> Reports { get; private set; } = new();
        public DateTime actualDate = DateTime.Now, reportDate;//.AddDays(-1);
        public List<string> nurses = new();
        public DepReportModel(ApplicationContext db)
        {
            context = db;
        }
        //public DepReportServise reportServise = new();

        public void OnGet(int depNumber, double dateOffset = 0)
        {
            actualDate = actualDate.AddDays(dateOffset);
            DateTime startTime = new DateTime(actualDate.Year, actualDate.Month, actualDate.Day, 8, 0, 0);
            DateTime endTime = new DateTime(actualDate.Year, actualDate.Month, actualDate.Day, 7, 59, 59).AddDays(1);
            //коррекция даты для ночного времени
            if(actualDate.Hour < 8)
            {
                startTime = startTime.AddDays(-1);
                endTime = endTime.AddDays(-1);
                reportDate = actualDate.AddDays(-1);
            }
            //задаем дату отображения на сводке, устнавливть только после коррекции стартовой даты 
            else { reportDate = actualDate; }


            //Reports = context.DepReports.AsNoTracking().ToList();
            //_report = reportServise.CreateTest();

            //падает при очистке БД - обработать для очистки и миграций
            //try
            //{
            report = (from report in context.DepReports
                       where (report.depNumber == depNumber)
                       where ((report.date > startTime) && (report.date < endTime))
                       select report).FirstOrDefault();

            //тест 
            //var reps = (from repo in context.DepReports
            //            where (repo.depNumber == depNumber)
            //            where (repo.date.Date > startTime) && (repo.date.Date < endTime)
            //            select repo).ToList();
            //_report = reportServise.CreateRandomReport((int)depNumber);
            //}
            //catch { throw new  }

            if (report == null)
            {
                //тест для БД, изменить на создание нового для релиза
                //_report = reportServise.CreateTest();

                report = new();
                report.depNumber = depNumber;
            }

            try
            {
                report.dutyNurse = DutyServices.GetDutyNurses( depNumber, context).FirstOrDefault().name;
            }
            catch { }
            //получаем список медсестер больницы
            //nurses = (from str in context.Personels
            //          where str.PersType == "Медсестра"
            //          orderby str.Name, str.Name.Substring(0, 1)
            //          select str.Name).ToList();


        }

        /// <summary>
        /// Метод находит в БД вчерашнюю сводку и перезаписывает ее в БД с сегодняшним числом и новым ИД
        /// </summary>
        /// <param name="depNumber"></param>
        /// <returns></returns>
        public RedirectToPageResult OnPostPrevReport(int depNumber)
        {
            //Reports = context.DepReports.AsNoTracking().ToList();

            DateTime lastlDate = actualDate.AddDays(-1);
            DateTime startTime = new DateTime(lastlDate.Year, lastlDate.Month, lastlDate.Day, 8, 0, 0);
            DateTime endTime = new DateTime(lastlDate.Year, lastlDate.Month, lastlDate.Day, 7, 59, 59).AddDays(1);
            //коррекция даты для ночного времени
            if (lastlDate.Hour < 8)
            {
                startTime = startTime.AddDays(-1);
                endTime = endTime.AddDays(-1);
                reportDate = actualDate.AddDays(-1);
            }
            //задаем дату отображения на сводке, устнавливть только после коррекции стартовой даты 
            else { reportDate = actualDate; }
            report = (from report in context.DepReports
                       where (report.depNumber == depNumber) && (report.date > startTime && report.date < endTime)
                       select report).AsNoTracking().FirstOrDefault();
            if (report == null)
            {
                return RedirectToPage("DepReport", new { depNumber = depNumber });
            }
            else 
            {
                //ищем запись сегодняшней даты 
                var curentReport = (from report in context.DepReports
                          where (report.depNumber == depNumber) && (report.date > startTime.AddDays(1) && report.date < endTime.AddDays(1))
                          select report).AsNoTracking().FirstOrDefault();
                if (curentReport == null)
                {
                    //новая сущность для БД
                    DepReport newRep = new();
                    newRep = (DepReport)report.Clone();
                    //меняем дату на текущую и обнуляем ИД для сохранения новой записи в БД
                    newRep.date = actualDate;
                    newRep.Id = 0;
                    context.DepReports.Update(newRep);
                    context.SaveChanges();
                    return RedirectToPage("DepReport", new { depNumber = depNumber });
                }
                //если имеется запись с текущей датой, перезаписывем ее предыдущей записью, оставляя текущее ИД и дату
                else
                {
                    int id = curentReport.Id;
                    curentReport = report;
                    curentReport.Id = id;
                    curentReport.date = actualDate;
                    context.DepReports.Update(curentReport);
                    context.SaveChanges();
                    return RedirectToPage("DepReport", new { depNumber = depNumber });
                }
            }  
        }

        public IActionResult OnPostReport(DepReport _report)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToPage("DepReport", new { depNumber = _report.depNumber });
            }
            //_report.dutyNurse = Request.Form["report.dutyNurse"];
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

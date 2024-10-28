using DailyReport.Services;
using DailyReport.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Linq;
using DailyReport.Models.Reports;
using DailyReport.Models.PersonelFolder;
using DailyReport.Services.Reports;

namespace DailyReport.Pages.Reports
{
    [IgnoreAntiforgeryToken]
    public class DepReportModel : PageModel
    {
        ApplicationContext context;
        private readonly IConfiguration appConfig;
        [BindProperty(SupportsGet = true)]
        public DepReport? report { get; set; }
        public DateTime actualDate = DateTime.Now, reportDate;
        public List<string> nurses = new();
        public List<LineEntity> Lines = new();
        public ReportLine reportLine;
        public int? KDOallias, PayServAllias, DCallias, ORITAllias, ORITDirtyAllias;
        public DepReportModel(ApplicationContext db, IConfiguration Configuration)
        {
            context = db;
            appConfig = Configuration;
        }

        public string existedStatus, presentStatus;
        public bool existed, present;
        string ReportTimeChange;

        public void OnGet(int depAllias, double dateOffset = 0)
        {
            try
            {
                KDOallias = int.Parse(appConfig["KDOallias"]);
            }
            catch { }
            try
            {
                PayServAllias = int.Parse(appConfig["PayServiceAllias"]);
            }
            catch { }

            //проверка статуса показа строки состояло
            try
            {
                existed = bool.Parse(appConfig["ExistedStatus"]);
            }
            catch { existed = true; }
            if (!existed) { existedStatus = "readonly"; }

            //проверка статуса показа строки состоит
            try
            {
                present = bool.Parse(appConfig["PresentStatus"]);
            }
            catch { present = true; }
            if (!present) { presentStatus = "readonly"; }

            try
            {
                ReportTimeChange = (appConfig["ReportTimeChange"]);
            }
            catch { ReportTimeChange = "08:00:00"; }

            actualDate = actualDate.AddDays(dateOffset);
            //DateTime startTime = new DateTime(actualDate.Year, actualDate.Month, actualDate.Day, 8, 0, 0);
            //DateTime endTime = new DateTime(actualDate.Year, actualDate.Month, actualDate.Day, 7, 59, 59).AddDays(1);

            DateTime startTime = DateOnly.FromDateTime(actualDate).ToDateTime(TimeOnly.Parse(ReportTimeChange));
            DateTime endTime = DateOnly.FromDateTime(actualDate).ToDateTime(TimeOnly.Parse(ReportTimeChange)).AddDays(1).AddSeconds(-1);

            //коррекция даты для ночного времени
            if (actualDate.Hour < startTime.Hour)
            {
                startTime = startTime.AddDays(-1);
                endTime = endTime.AddDays(-1);
                if(dateOffset == 0) reportDate = actualDate.AddDays(-1);    //корректруем значение даты сводки только для текущей даты
                else reportDate = actualDate;
            }
            //задаем дату отображения на сводке, устанавливть только после коррекции стартовой даты 
            else { reportDate = actualDate; }


            //Reports = context.DepReports.AsNoTracking().ToList();
            //_report = reportServise.CreateTest();

            report = DepReportServise.GetRepByNumber(context, depAllias, startTime, endTime);

            //_report = reportServise.CreateRandomReport((int)depNumber);

            if (report is null)
            {
                //тест для БД, изменить на создание нового для релиза
                //report = DepReportServise.CreateTest();
                report = new();
                //report.Lines = new();
                report.depNumber = depAllias;
                //при работе с прошлыми сводкам корректируем дату сводки
                if(dateOffset != 0) report.date = reportDate;

                //Lines = LinesServices.GetOrderedLines(context);
                //foreach(LineEntity line in Lines)
                //{
                //    report.Lines.Add(new ReportLine() { name = line.Name, lineType = line.EntityType, Adults = 0,  Children = 0});
                //}
            }

            try
            {
                DutyNurse? dn = DutyServices.GetDutyNurses(depAllias, context).FirstOrDefault();
                if(dn != null) report.dutyNurse = dn.name;
            }
            catch { }
        }

        /// <summary>
        /// Метод находит в БД вчерашнюю сводку и перезаписывает ее в БД с сегодняшним числом и новым ИД
        /// </summary>
        /// <param name="depAllias"></param>
        /// <returns></returns>
        public RedirectToPageResult OnPostPrevReport(int depAllias)
        {
            //Reports = context.DepReports.AsNoTracking().ToList();
            try
            {
                ReportTimeChange = (appConfig["ReportTimeChange"]);
            }
            catch { ReportTimeChange = "08:00:00"; }
            DateTime lastlDate = actualDate.AddDays(-1);
            //DateTime startTime = new DateTime(lastlDate.Year, lastlDate.Month, lastlDate.Day, 8, 0, 0);
            //DateTime endTime = new DateTime(lastlDate.Year, lastlDate.Month, lastlDate.Day, 7, 59, 59).AddDays(1);
            DateTime startTime = DateOnly.FromDateTime(lastlDate).ToDateTime(TimeOnly.Parse(ReportTimeChange));
            DateTime endTime = DateOnly.FromDateTime(lastlDate).ToDateTime(TimeOnly.Parse(ReportTimeChange)).AddDays(1).AddSeconds(-1);

            //коррекция даты для ночного времени
            if (lastlDate.Hour < startTime.Hour)
            {
                startTime = startTime.AddDays(-1);
                endTime = endTime.AddDays(-1);
                reportDate = actualDate.AddDays(-1);
            }
            //задаем дату отображения на сводке, устнавливть только после коррекции стартовой даты 
            else { reportDate = actualDate; }
            report = DepReportServise.GetRepByNumber(context, depAllias, startTime, endTime);
            if (report is null)
            {
                return RedirectToPage("DepReport", new { depAllias = depAllias });
            }
            else 
            {
                //ищем запись сегодняшней даты, используем метод без отслеживания сущности сводки из БД.
                var curentReport = DepReportServise.GetRepByNumberNoTracking(context, depAllias, startTime.AddDays(1), endTime.AddDays(1));
                if (curentReport is null)
                {
                    //новая сущность для БД
                    DepReport newRep = DepReportServise.RewriteReportForLastDay(report);
                    newRep.date = actualDate;
                    newRep.Id = 0;
                    context.DepReports.Update(newRep);
                    context.SaveChanges();
                    return RedirectToPage("DepReport", new { depAllias = depAllias });
                }
                //если имеется запись с текущей датой, перезаписывем ее предыдущей записью, оставляя текущее ИД и дату
                else
                {
                    int id = curentReport.Id;
                    curentReport = DepReportServise.RewriteReportForLastDay(report);
                    curentReport.Id = id;
                    curentReport.date = actualDate;
                    context.DepReports.Update(curentReport);
                    context.SaveChanges();
                    return RedirectToPage("DepReport", new { depAllias = depAllias });
                }
            }  
        }

        public IActionResult OnPostReport(DepReport _report)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToPage("DepReport", new { depAllias = _report.depNumber });
            }
            DepReportServise.AddReport(context, _report);
            return RedirectToPage("DepReport", new { depAllias = _report.depNumber });
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

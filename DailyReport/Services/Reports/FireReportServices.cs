using DailyReport.Models;
using DailyReport.Models.Reports;
using System.Security.Cryptography;

namespace DailyReport.Services.Reports
{
    public static class FireReportServices
    {
        /// <summary>
        /// сохраняет сводку в БД
        /// </summary>
        /// <param name="fireReport"></param>
        /// <param name="context"></param>
        public static void AddFireReport(FireReport fireReport, ApplicationContext context)
        {
            context.FireReports.Update(fireReport);
            context.SaveChanges();
        }
        /// <summary>
        /// Получает сводку заданного отделения с сегодняшним числом, возможен возврат null
        /// </summary>
        /// <param name="depNumber"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public static FireReport GetFireReportByDep(int depNumber, ApplicationContext context)
        {
            DateTime actualDate = DateTime.Now;
            DateTime startTime = new DateTime(actualDate.Year, actualDate.Month, actualDate.Day, 8, 0, 0);
            DateTime endTime = new DateTime(actualDate.Year, actualDate.Month, actualDate.Day, 7, 59, 59).AddDays(1);
            if (actualDate.Hour < 8)
            {
                startTime = startTime.AddDays(-1);
                endTime = endTime.AddDays(-1);
            }
            FireReport fireReport = (from f in context.FireReports
                                     where f.DepNumber == depNumber && f.Date > startTime && f.Date < endTime
                                     select f).FirstOrDefault();
            return fireReport;
        }

        /// <summary>
        ///  получаем из БД сохраненные сводки с текущей датой, за исключением долго хранимых сводок
        /// </summary>
        /// <param name="context"></param>
        /// <param name="LongStoredDeps"></param>
        /// <returns></returns>
        public static List<FireReport> GetFireReports(ApplicationContext context, List<int> LongStoredDeps)
        {
            DateTime actualDate = DateTime.Now;
            DateTime startTime = new DateTime(actualDate.Year, actualDate.Month, actualDate.Day, 8, 0, 0);
            DateTime endTime = new DateTime(actualDate.Year, actualDate.Month, actualDate.Day, 7, 59, 59).AddDays(1);
            if (actualDate.Hour < 8)
            {
                startTime = startTime.AddDays(-1);
                endTime = endTime.AddDays(-1);
            }
            List<FireReport> fireReports = (from f in context.FireReports
                                           where (f.Date > startTime && f.Date < endTime) || (LongStoredDeps.Contains(f.DepNumber))
                                           orderby f.Date descending
                                     
                                           select f).ToList();
            //foreach (int alias in LongStoredDeps)
            //{
            //   var fireReport = (from f in context.FireReports
            //                    where f.DepNumber == alias
            //                    select f).FirstOrDefault();
            //    if(fireReport is not null) fireReports.Add(fireReport); 
            //}

            return fireReports;
        }

        public static void DeleteFireReport(int id, ApplicationContext context)
        {
            FireReport fireReport = (from f in context.FireReports
                                     where f.Id == id
                                     select f).FirstOrDefault();
            if (fireReport != null) context.FireReports.Remove(fireReport);
            context.SaveChanges();
        }

        public static void UpdateFireReport(FireReport fireRport, ApplicationContext context)
        {
            FireReport _fireRport = (from f in context.FireReports
                                     where f.Id == fireRport.Id
                                     select f).FirstOrDefault();
            if (_fireRport != null)
            {
                _fireRport.DepNumber = fireRport.DepNumber;
                _fireRport.Adult = fireRport.Adult;
                _fireRport.Children = fireRport.Children;
                _fireRport.Care = fireRport.Care;
                _fireRport.Personel = fireRport.Personel;
                context.SaveChanges();
            }
        }


        //работа с суммарной пожарной сводкой 
        /// <summary>
        /// Получаем список сводок, если в БД не сохранено, добавляем пустую, но не сохраняем в БД
        /// Фильтрованый список заполняется по порядку отделений в выдаче всей сводки из actualDepsAllias
        /// </summary>
        /// <returns></returns>
        public static List<FireReport> GetFilteredReports(ApplicationContext context, List<int> actualDepsAllias, List<int> longStoredDeps)
        {
            List<FireReport> reports = GetFireReports(context, longStoredDeps);
            List<FireReport> filteredReports = new();
            FireReport? _report = new();

            foreach (int i in actualDepsAllias)
            {
                _report = reports.Find(p => p.DepNumber == i);
                if (_report is null) _report = new FireReport { DepNumber = i, Date = DateTime.Now };
                filteredReports.Add(_report);
            }

            return filteredReports;
        }


    }
}

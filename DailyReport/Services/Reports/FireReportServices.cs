using DailyReport.Models;
using DailyReport.Models.Reports;

namespace DailyReport.Services.Reports
{
    public static class FireReportServices
    {
        /// <summary>
        /// сохраняет сводку в БД
        /// </summary>
        /// <param name="fireRport"></param>
        /// <param name="context"></param>
        public static void AddFireReport(FireReport fireRport, ApplicationContext context)
        {
            context.FireReports.Update(fireRport);
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
        /// получаем из БД сохраненные сводки с текущей датой
        /// </summary>
        /// <param name="depNumber"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public static List<FireReport> GetFireReports(ApplicationContext context)
        {
            DateTime actualDate = DateTime.Now;
            DateTime startTime = new DateTime(actualDate.Year, actualDate.Month, actualDate.Day, 8, 0, 0);
            DateTime endTime = new DateTime(actualDate.Year, actualDate.Month, actualDate.Day, 7, 59, 59).AddDays(1);
            if (actualDate.Hour < 8)
            {
                startTime = startTime.AddDays(-1);
                endTime = endTime.AddDays(-1);
            }
            List<FireReport> fireReport = (from f in context.FireReports
                                           where f.Date > startTime && f.Date < endTime
                                           //orderby f.ShowOrder
                                           select f).ToList();
            return fireReport;
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
        /// Фильтрованый список заполняется по порядку отделений в выдаче всей сводки
        /// </summary>
        /// <returns></returns>
        public static List<FireReport> GetFilteredReports(ApplicationContext context, List<int> actualDepsAllias)
        {
            List<FireReport> reports = GetFireReports(context);
            List<FireReport> filteredReports = new();
            FireReport? _report = new();

            foreach (int i in actualDepsAllias)
            {
                _report = reports.Find(p => p.DepNumber == i);
                if (_report is null) _report = new FireReport { DepNumber = i, Date = DateTime.Now };
                filteredReports.Add(_report);
            }

            //_report = reports.Find(p => p.DepNumber == 1);
            //if (_report != null) filteredReports.Add(_report);
            //else filteredReports.Add(new FireReport { DepNumber = 1, Date = DateTime.Now });

            //_report = reports.Find(p => p.DepNumber == 2);
            //if (_report != null) filteredReports.Add(_report);
            //else filteredReports.Add(new FireReport { DepNumber = 2, Date = DateTime.Now });

            //_report = reports.Find(p => p.DepNumber == 3);
            //if (_report != null) filteredReports.Add(_report);
            //else filteredReports.Add(new FireReport { DepNumber = 3, Date = DateTime.Now });

            //_report = reports.Find(p => p.DepNumber == 4);
            //if (_report != null) filteredReports.Add(_report);
            //else filteredReports.Add(new FireReport { DepNumber = 4, Date = DateTime.Now });

            //_report = reports.Find(p => p.DepNumber == 5);
            //if (_report != null) filteredReports.Add(_report);
            //else filteredReports.Add(new FireReport { DepNumber = 5, Date = DateTime.Now });

            //_report = reports.Find(p => p.DepNumber == 6);
            //if (_report != null) filteredReports.Add(_report);
            //else filteredReports.Add(new FireReport { DepNumber = 6, Date = DateTime.Now });

            //_report = reports.Find(p => p.DepNumber == 7);
            //if (_report != null) filteredReports.Add(_report);
            //else filteredReports.Add(new FireReport { DepNumber = 7, Date = DateTime.Now });

            //_report = reports.Find(p => p.DepNumber == 8);
            //if (_report != null) filteredReports.Add(_report);
            //else filteredReports.Add(new FireReport { DepNumber = 8, Date = DateTime.Now });

            //_report = reports.Find(p => p.DepNumber == 90);
            //if (_report != null) filteredReports.Add(_report);
            //else filteredReports.Add(new FireReport { DepNumber = 90, Date = DateTime.Now });

            //лаборатория - по умолчанию 2 сотрудника
            _report = reports.Find(p => p.DepNumber == 25);
            if (_report != null) filteredReports.Add(_report);
            else filteredReports.Add(new FireReport { DepNumber = 25, Personel = 2, Date = DateTime.Now });

            //тех.персонал и охрана - не редактируется, добавляем 14 сотрудников
            filteredReports.Add(new FireReport { DepNumber = 102, Personel = 10, Date = DateTime.Now });

            return filteredReports;
        }


    }
}

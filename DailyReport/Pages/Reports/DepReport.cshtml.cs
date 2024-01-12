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
        [BindProperty]
        public DepReport _report { get; set; }
        public List<DepReport> Reports { get; private set; } = new();
        public DateTime actualDate = DateTime.Now, reportDate;//.AddDays(-1);
        public List<string> nurses = new();
        public DepReportModel(ApplicationContext db)
        {
            context = db;
        }
        public DepReportServise reportServise = new();

        public void OnGet(int depNumber, double dateOffset = 0)
        {
            actualDate = actualDate.AddDays(dateOffset);
            DateTime startTime = new DateTime(actualDate.Year, actualDate.Month, actualDate.Day, 8, 0, 0);
            DateTime endTime = new DateTime(actualDate.Year, actualDate.Month, actualDate.Day, 7, 59, 59).AddDays(1);
            //��������� ���� ��� ������� �������
            if(actualDate.Hour < 8)
            {
                startTime = startTime.AddDays(-1);
                endTime = endTime.AddDays(-1);
                reportDate = actualDate.AddDays(-1);
            }
            //������ ���� ����������� �� ������, ����������� ������ ����� ��������� ��������� ���� 
            else { reportDate = actualDate; }


            //Reports = context.DepReports.AsNoTracking().ToList();
            //_report = reportServise.CreateTest();

            //������ ��� ������� �� - ���������� ��� ������� � ��������
            //try
            //{
            _report = (from report in context.DepReports
                       where (report.depNumber == depNumber)
                       where ((report.date > startTime) && (report.date < endTime))
                       select report).FirstOrDefault();

            //���� 
            //var reps = (from repo in context.DepReports
            //            where (repo.depNumber == depNumber)
            //            where (repo.date.Date > startTime) && (repo.date.Date < endTime)
            //            select repo).ToList();
            //_report = reportServise.CreateRandomReport((int)depNumber);
            //}
            //catch { throw new  }

            if (_report == null)
            {
                //���� ��� ��, �������� �� �������� ������ ��� ������
                //_report = reportServise.CreateTest();

                _report = new();
                _report.depNumber = depNumber;
            }

            //�������� ������ ��������� ��������
            //nurses = (from str in context.Personels
            //          where str.PersType == "���������"
            //          orderby str.Name, str.Name.Substring(0, 1)
            //          select str.Name).ToList();
                      
        }

        /// <summary>
        /// ����� ������� � �� ��������� ������ � �������������� �� � �� � ����������� ������ � ����� ��
        /// </summary>
        /// <param name="depNumber"></param>
        /// <returns></returns>
        public RedirectToPageResult OnPostPrevReport(int depNumber)
        {
            //Reports = context.DepReports.AsNoTracking().ToList();

            DateTime lastlDate = actualDate.AddDays(-1);
            DateTime startTime = new DateTime(lastlDate.Year, lastlDate.Month, lastlDate.Day, 8, 0, 0);
            DateTime endTime = new DateTime(lastlDate.Year, lastlDate.Month, lastlDate.Day, 7, 59, 59).AddDays(1);
            //��������� ���� ��� ������� �������
            if (lastlDate.Hour < 8)
            {
                startTime = startTime.AddDays(-1);
                endTime = endTime.AddDays(-1);
                reportDate = actualDate.AddDays(-1);
            }
            //������ ���� ����������� �� ������, ����������� ������ ����� ��������� ��������� ���� 
            else { reportDate = actualDate; }
            _report = (from report in context.DepReports
                       where (report.depNumber == depNumber) && (report.date > startTime && report.date < endTime)
                       select report).AsNoTracking().FirstOrDefault();
            if (_report == null)
            {
                return RedirectToPage("DepReport", new { depNumber = depNumber });
            }
            else 
            {
                //����� �������� ��� ��
                DepReport newRep = new();
                newRep = (DepReport)_report.Clone();
                //������ ���� �� ������� � �������� �� ��� ���������� ����� ������ � ��
                newRep.date = actualDate;
                newRep.Id = 0;
                context.DepReports.Update(newRep);
                context.SaveChanges();
                return RedirectToPage("DepReport", new { depNumber = depNumber });
            }  
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

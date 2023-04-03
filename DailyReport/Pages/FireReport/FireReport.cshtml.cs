using DailyReport.Models;
using DailyReport.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Cryptography;


namespace DailyReport.Pages.FireReport
{
    public class FireReportModel : PageModel
    {
        public DateTime ActualDate = new();
        ApplicationContext context;
        public int departmentNumber;
        public List<DutyNurse> dutyNurses;
        [BindProperty]
        public List<Personel> nursesList { get; set; }
        [BindProperty]
        public List<Tuple<string, string>> nurseInfo { get; set; }
        [BindProperty]
        public DutyNurse DutyNurse { get; set; } = new();
        [BindProperty]
        public Models.FireReport fireReport { get; set; } = new();

        public FireReportModel(ApplicationContext db)
        {
            context = db;
        }
        public void OnGet(int depNumber)
        {
            departmentNumber = depNumber;

            //работа с медсестрами
            dutyNurses = DutyServices.GetDutyNurses(depNumber, context);
            nursesList = DutyServices.GetNursesList(context);

            //работа со сводкой
            fireReport = FireReportServices.GetFireReportByDep(departmentNumber, context);
            if (fireReport == null)
            {
                fireReport = new Models.FireReport();
                fireReport.Date = DateTime.Now;
                fireReport.DepNumber = departmentNumber;
            }
        }

        public IActionResult OnPostSaveNurse()
        {
            Personel personel = PersonelServices.GetPersonelByName(DutyNurse.name, context);
            if (personel != null)
            {
                DutyNurse.dutyDate = DateTime.Now;
                DutyNurse.Phone = personel.Phone;
            }
            DutyServices.AddDutyNurse(DutyNurse, context);
            return RedirectToPage("FireReport", new { depNumber = DutyNurse.department });
        }

        /// <summary>
        /// удаляем медсестру из БД, вторым параметром передаем номер отделения для правильного возврата 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="depNumber"></param>
        /// <returns></returns>
        public IActionResult OnPostDeleteNurse(int id, int depNumber)
        {
            DutyServices.DeleteDutyNurse(id, context);
            return RedirectToPage("FireReport", new { depNumber });
        }

        //методы для работы со сводкой

        public IActionResult OnPostSaveFireReport()
        {
            if (!ModelState.IsValid)
            {
                return RedirectToPage("FireReport", new { depNumber = fireReport.DepNumber });
            }
            fireReport.Date = DateTime.Now;
            FireReportServices.AddFireReport(fireReport, context);
            return RedirectToPage("FireReport", new { depNumber = fireReport.DepNumber });
        }
    }
}

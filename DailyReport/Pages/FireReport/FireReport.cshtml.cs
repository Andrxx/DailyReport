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
        public Department department;
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
        public void OnGet(int depAllias)
        {
            department = DepartmentServices.GetSortedDepartments(context).FirstOrDefault(d => d.Allias == depAllias);
            
            //костыль - сделать обработку ошибки поиска отделени€
            if (department is null) { department = new() { Number = depAllias, Name = depAllias.ToString() }; }
            
            //работа с медсестрами
            dutyNurses = DutyServices.GetDutyNurses(depAllias, context);
            nursesList = DutyServices.GetNursesList(context);

            //работа со сводкой
            fireReport = FireReportServices.GetFireReportByDep(department.Allias, context);
            if (fireReport == null)
            {
                fireReport = new Models.FireReport();
                fireReport.Date = DateTime.Now;
                fireReport.DepNumber = department.Allias;
            }
        }

        public IActionResult OnPostSaveNurse()
        {
            Personel? personel = PersonelServices.GetPersonelByName(DutyNurse?.name, context);
            if (personel != null)
            {
                DutyNurse.dutyDate = DateTime.Now;
                DutyNurse.Phone = personel.Phone;
            }
            DutyServices.AddDutyNurse(DutyNurse, context);
            return RedirectToPage("FireReport", new { depAllias = DutyNurse.department });
        }

        /// <summary>
        /// удал€ем медсестру из Ѕƒ, вторым параметром передаем номер отделени€ дл€ правильного возврата 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="depNumber"></param>
        /// <returns></returns>
        public IActionResult OnPostDeleteNurse(int id, int depNumber)
        {
            DutyServices.DeleteDutyNurse(id, context);
            return RedirectToPage("FireReport", new { depAllias = depNumber });
        }

        //методы дл€ работы со сводкой

        public IActionResult OnPostSaveFireReport()
        {
            if (!ModelState.IsValid)
            {
                return RedirectToPage("FireReport", new { depAllias = fireReport.DepNumber });
            }
            fireReport.Date = DateTime.Now;
            FireReportServices.AddFireReport(fireReport, context);
            return RedirectToPage("FireReport", new { depAllias = fireReport.DepNumber });
        }
    }
}

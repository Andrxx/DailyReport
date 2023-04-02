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

        public FireReportModel(ApplicationContext db)
        {
            context = db;
        }
        public void OnGet(int depNumber)
        {
            departmentNumber = depNumber;
            dutyNurses = DutyServices.GetDutyNurses(depNumber, context);
            nursesList = DutyServices.GetNursesList(context);
        }

        public IActionResult OnPostSaveNurse()
        {
            Personel personel = PersonelServices.GetPersonelByName(DutyNurse.name, context);
            if (personel != null)
            {
                DutyNurse.dutyDate = ActualDate;
                DutyNurse.Phone = personel.Phone;
            }
            DutyServices.AddDutyNurse(DutyNurse, context);
            return RedirectToPage("FireReport", new { depNumber = DutyNurse.department });
        }

        public IActionResult OnPostDeleteNurse(int id)
        {
            DutyServices.DeleteDutyNurse(id, context);
            return RedirectToPage("FireReport", new { depNumber = DutyNurse.department });
        }
    }
}

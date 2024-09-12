using DailyReport.Models;
using DailyReport.Models.PersonelFolder;
using DailyReport.Services;
using DailyReport.Services.Reports;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DailyReport.Pages.Admin
{
    public class PersonelManegementModel : PageModel
    {
        ApplicationContext context;
        public PersonelManegementModel(ApplicationContext db)
        {
            context = db;
        }
        public List<Department> activeDepartments { get; set; } = new();
        public Personel personel, newPersonel = new Personel();
        public List<Personel> personels = new List<Personel>();
        public List<string> PType = PersonelServices.GetPType();
        public List<string> DepsList = new();// = PersonelServices.GetDepartments(context);
        public int departmentCounter;

        public void OnGet()
        {
            activeDepartments = DepartmentServices.GetSortedDepartments(context);
            departmentCounter = activeDepartments.Count;
            DepsList = PersonelServices.GetDepartments(context);
            personels = (from pers in context.Personels
                         orderby pers.Name, pers.Name.Substring(0, 1)
                         select pers).ToList();
        }

        public IActionResult OnPostSavePersonel(Personel newPersonel)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Get");
            }
            PersonelServices.AddPersonel(newPersonel, context);
            return RedirectToAction("Get");
        }

        public IActionResult OnPostDeletePersonel(int id)
        {
            PersonelServices.DeletePersonel(id, context);
            return RedirectToAction("Get");
        }

        public IActionResult OnPostUpdatePersonel(Personel newPersonel)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Get");
            }
            PersonelServices.UpdatePersonel(newPersonel, context);
            return RedirectToAction("Get");
        }
    }
}

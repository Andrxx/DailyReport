using DailyReport.Models.WardsModels;
using DailyReport.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DailyReport.Services.WardServices;
using System.Security.Cryptography;

namespace DailyReport.Pages.Admin
{
    public class PatientsListModel : PageModel
    {
        ApplicationContext context;
        [BindProperty]
        public Patient newPatient { get; set; } = new();
        [BindProperty]
        public List<Patient> patients { get; set; } = new();
        public PatientsListModel(ApplicationContext db)
        {
            context = db;
        }
        public void OnGet()
        {
            patients = PatientServices.GetPatients(context);
        }
        public IActionResult OnPostDeletePatient(int id)
        {
            //if (!ModelState.IsValid)
            //{
            //    return RedirectToPage("DepartmentWards", new { depNumber = newPatient.Department });
            //}
            PatientServices.DeletePatient(context, id);

            return RedirectToPage("PatientsList");
        }
    }
}

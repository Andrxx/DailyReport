using DailyReport.Models;
using DailyReport.Models.WardsModels;
using DailyReport.Services;
using DailyReport.Services.WardServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Cryptography;

namespace DailyReport.Pages.Wards
{
    public class WardsManagementModel : PageModel
    {
        ApplicationContext context;
        public WardsManagementModel(ApplicationContext db)
        {
            context = db;
        }

        public Ward Ward, newWard = new();
        public List<Ward> Wards { get; set; }
        public int departmentNumber;
        public void OnGet(int depNumber)
        {
            departmentNumber = depNumber;
            Wards = WardServices.GetWardsByDepartment(context, depNumber);
        }

        public IActionResult OnPostAddWard(Ward ward)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToPage("WardsManagement", new { depNumber = ward.Department });
            }
            WardServices.AddWard(context, ward);

            return RedirectToPage("WardsManagement", new { depNumber = ward.Department });
        }

        public IActionResult OnPostDeleteWard(Ward ward, int depNumber)
        {
            //todo - если в палате есть пациент, палата не удаляется. Сделать оповещение пользователя 
            if (PatientServices.GetPatientsByDepartmentAndWard(context, ward.Department, ward.Number).Count == 0)
            {
                WardServices.DeleteWard(context, ward.Id); 
            }
            return RedirectToPage("WardsManagement", new { depNumber });
        }

        public IActionResult OnPostUpdateWard(Ward ward)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToPage("WardsManagement", new { depNumber = ward.Department });
            }
            WardServices.UpdateWard(context, ward);

            return RedirectToPage("WardsManagement", new { depNumber = ward.Department });
        }
    }
}

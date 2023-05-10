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
            Wards = (from ward in context.Wards
                     where ward.Department == depNumber
                     select ward).ToList();
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

        public IActionResult OnPostDeleteWard(int id, int depNumber)
        {
            WardServices.DeleteWard(context, id);
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

using DailyReport.Models.WardsModels;
using DailyReport.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DailyReport.Pages.Wards
{
    public class WardsSummaryModel : PageModel
    {
        ApplicationContext context;
        public Ward ward { get; set; }
        public List<Ward> wards { get; set; } = new();
        public Patient newPatient { get; set; } = new();
        public List<Patient> patients { get; set; } = new();
        public int departmentNumber;
        public WardsSummaryModel(ApplicationContext db)
        {
            context = db;
        }


        public void OnGet()
        {
        }
    }
}

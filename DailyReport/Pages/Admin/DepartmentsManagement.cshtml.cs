using DailyReport.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DailyReport.Pages.Admin
{
    public class DepartmentsManagementModel : PageModel
    {
        ApplicationContext context;
        public DepartmentsManagementModel(ApplicationContext db)
        {
            context = db;
        }

        public List<Department> Departments { get; set; }
        public Department department = new();
        public void OnGet()
        {
        }
    }
}

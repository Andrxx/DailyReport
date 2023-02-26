using DailyReport.Models;
using DailyReport.Services;
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

        public List<Department> Departments = new();
        public Department department = new();
        public void OnGet()
        {
            Departments = (from d in context.Departments
                           select d).ToList();
        }

        public IActionResult OnPostSaveDepartment(Department department)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Get");
            }
            DepartmentServices.AddDepartment(department, context);
            return RedirectToAction("Get");
        }

        public IActionResult OnPostDeleteDepartment(int id)
        {
            DepartmentServices.DeleteDepartment(id, context);
            return RedirectToAction("Get");
        }

        public IActionResult OnPostUpdateDepartment(Department department)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Get");
            }
            DepartmentServices.UpdateDepartment(department, context);
            return RedirectToAction("Get");
        }
    }
}

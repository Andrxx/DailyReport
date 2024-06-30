using DailyReport.Models;
using DailyReport.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DailyReport.Pages.FireReport
{
    public class FireRepIndexModel : PageModel
    {
        ApplicationContext context;
        public FireRepIndexModel( ApplicationContext db)
        {
            context = db;
        }
        public List<Department> Departments = new();
        public List<int> excludedDeps = new() { 11, 91 };   //список отделений не выводимых в сводке
        public void OnGet()
        {
            Departments = DepartmentServices.GetSortedDepartments(context);
            //int i = Departments.Count;
            for (int i = Departments.Count - 1; i>=0; i--)
                {
                if (excludedDeps.Contains(Departments[i].Allias))
                {
                    Departments.Remove(Departments[i]);
                }
            }
        }
    }
}

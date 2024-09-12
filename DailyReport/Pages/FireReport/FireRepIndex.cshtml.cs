using DailyReport.Models;
using DailyReport.Services.Reports;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DailyReport.Pages.FireReport
{
    public class FireRepIndexModel : PageModel
    {
        ApplicationContext context;
        private readonly IConfiguration appConfig;
        public FireRepIndexModel(ApplicationContext db, IConfiguration Configuration)
        {
            context = db;
            appConfig = Configuration;
        }
        public List<Department> Departments = new();
        public List<int> excludedDeps;               //список отделений не выводимых в сводке
        public void OnGet()
        {

            var ed = appConfig["ExcludedDepartments:FireIndexExclusion"];
            try
            {
                if (ed != null) excludedDeps = ed.Split(' ').Select(x => int.Parse(x)).ToList();
                else excludedDeps = new();
            }
            catch { excludedDeps = new(); }

            Departments = DepartmentServices.GetSortedDepartments(context, excludedDeps);
        }
    }
}

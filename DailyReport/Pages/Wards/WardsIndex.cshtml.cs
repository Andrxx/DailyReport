using DailyReport.Models;
using DailyReport.Services.Reports;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DailyReport.Pages.Wards
{
    public class WardsIndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        ApplicationContext context;
        private readonly IConfiguration appConfig;
        public WardsIndexModel(ILogger<IndexModel> logger, ApplicationContext db, IConfiguration configuration)
        {
            _logger = logger;
            context = db;
            appConfig = configuration;
        }
        public List<Department> Departments = new();
        public List<int> excludedDeps = new();
        public void OnGet()
        {
            var depExc = appConfig["ExcludedDepartments:WardsExclusion"];
            try
            {
                if (depExc != null) excludedDeps = depExc.Split(' ').Select(x => int.Parse(x)).ToList();
                else excludedDeps = new();
            }
            catch { excludedDeps = new(); }

            Departments = DepartmentServices.GetSortedDepartments(context, excludedDeps);

        }
    }
}

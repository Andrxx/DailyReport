using DailyReport.Models;
using DailyReport.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DailyReport.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        ApplicationContext context;
        public IndexModel(ILogger<IndexModel> logger, ApplicationContext db)
        {
            _logger = logger;
            context = db;
        }
        public List<Department> Departments = new();
        public void OnGet()
        {
            Departments = DepartmentServices.GetSortedDepartments(context);
        }
    }
}
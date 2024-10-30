using DailyReport.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DailyReport.Pages.Admin
{
    public class MigrationModel : PageModel
    {
        ApplicationContext context;
        private readonly ILogger<MigrationModel> _logger;
        public MigrationModel(ApplicationContext db, ILogger<MigrationModel> logger)
        {
            context = db;
            _logger = logger;
        }

        public void OnGet()
        {
           
        }

        public void OnPostMigrate()
        {
            UpdateMigration();
        }

        void UpdateMigration()
        {
            context.Database.Migrate();
        }
    }
}

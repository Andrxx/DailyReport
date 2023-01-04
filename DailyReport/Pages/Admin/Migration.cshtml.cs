using DailyReport.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DailyReport.Pages.Admin
{
    public class MigrationModel : PageModel
    {
        ApplicationContext context;
        public MigrationModel(ApplicationContext db)
        {
            context = db;
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

using DailyReport.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DailyReport.Pages.Admin
{
    public class DBAdministrationModel : PageModel
    {
        ApplicationContext context;
        public DBAdministrationModel(ApplicationContext db)
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

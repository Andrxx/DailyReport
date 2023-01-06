using DailyReport.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DailyReport.Pages.Admin
{
    public class PersonelManegementModel : PageModel
    {
        ApplicationContext context;
        public PersonelManegementModel(ApplicationContext db)
        {
            context = db;
        }
        public Personel personel, newPersonel = new Personel();
        public List<Personel> personels = new List<Personel>();


        public void OnGet()
        {

        }
    }
}

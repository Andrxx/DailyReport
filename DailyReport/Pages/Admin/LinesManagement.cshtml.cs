using DailyReport.Models;
using DailyReport.Models.Reports;
using DailyReport.Services.Reports;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DailyReport.Pages.Admin
{
    public class LinesManagementModel : PageModel
    {

        ApplicationContext context;
        public LinesManagementModel(ApplicationContext db)
        {
            context = db;
        }
        public LineType Type = new();
        public List<LineEntity> Lines = new();
        public List<LineType> types = new List<LineType>();
        public LineEntity Line = new();

        public void OnGet()
        {
            types = LineTypesServices.GetOrderedTypes(context); //GetHardcodedTypes(); 
            Lines = LinesServices.GetOrderedLines(context);
        }

        public IActionResult OnPostSaveType(LineType Type)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Get");
            }
            LineTypesServices.AddType(Type, context);
            return RedirectToAction("Get");
        }
        public IActionResult OnPostUpdateType(LineType Type)
        {
            LineTypesServices.UpdateType(Type, context);
            return RedirectToAction("Get");
        }

        public IActionResult OnPostDeleteType(int id)
        {
            LineTypesServices.DeleteType(id, context);
            return RedirectToAction("Get");
        }


        public IActionResult OnPostSaveLine(LineEntity Line)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Get");
            }
            LinesServices.AddLine(Line, context);
            return RedirectToAction("Get");
        }

        public IActionResult OnPostUpdateLine(LineEntity Line)
        {
            LinesServices.UpdateLine(Line, context);
            return RedirectToAction("Get");
        }

        public IActionResult OnPostDeleteLine(int id)
        {
            LinesServices.DeleteLine(id, context);
            return RedirectToAction("Get");
        }
    }
}
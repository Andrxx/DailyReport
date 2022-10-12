using DailyReport.Services;
using DailyReport.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DailyReport.Pages.Reports
{
    public class DepReportModel : PageModel
    {
        public DepReport _report = new DepReport();
        public DepReportServise reportServise = new DepReportServise();
        public void OnGet()
        {
            _report = reportServise.Get();
        }
        public void OnPost()
        {
            _report.depNumber = 1;
            _report.existed = int.Parse(Request.Form[" "]);
            _report.existedChildrens = int.Parse(Request.Form[" "]);
            _report.income = int.Parse(Request.Form[" "]);
            _report.incomeChildrens = int.Parse(Request.Form[" "]);
            _report.outcome = int.Parse(Request.Form[" "]);
            _report.outcomeChildrens = int.Parse(Request.Form[" "]);
            _report.movedOutDep = int.Parse(Request.Form[" "]);
            _report.movedOutDepChildrens = int.Parse(Request.Form[" "]);
            _report.movedInDep = int.Parse(Request.Form[" "]);
            _report.movedInDepChildrens = int.Parse(Request.Form[" "]);
            _report.died = int.Parse(Request.Form[" "]);
            _report.diedChildrens = int.Parse(Request.Form[" "]);
            _report.present = int.Parse(Request.Form[" "]);
            _report.presentChildrens = int.Parse(Request.Form[" "]);
            _report.oIVL = int.Parse(Request.Form[" "]);
            _report.oIVLChildrens = int.Parse(Request.Form[" "]);
            _report.oNIVL = int.Parse(Request.Form[" "]);
            _report.oNIVLChildrens = int.Parse(Request.Form[" "]);
            _report.oNIVLVPO = int.Parse(Request.Form[" "]);
            _report.oNIVLVPOChildrens = int.Parse(Request.Form[" "]);
            _report.oNIVLMask = int.Parse(Request.Form[" "]);
            _report.oNIVLMaskChildrens = int.Parse(Request.Form[" "]);
            _report.oMask = int.Parse(Request.Form[" "]);
            _report.oMaskChildren = int.Parse(Request.Form[" "]);
            _report.oBrease = int.Parse(Request.Form[" "]);
            _report.oBreaseChildrens = int.Parse(Request.Form[" "]);
            _report.pregnant = int.Parse(Request.Form[" "]);
            _report.pregnantChildrens = int.Parse(Request.Form[" "]);
            _report.restZone = int.Parse(Request.Form[" "]);
            _report.restZoneChildrens = int.Parse(Request.Form[" "]);
            _report.outRegions = int.Parse(Request.Form[" "]);
            _report.outRegionsChildrens = int.Parse(Request.Form[" "]);
            _report.forein = int.Parse(Request.Form[" "]);
            _report.foreinChildrens = int.Parse(Request.Form[" "]);
            _report.LNR_DNR = int.Parse(Request.Form[" "]);
            _report.LNR_DNRChildrens = int.Parse(Request.Form[" "]);
            _report.incomeHospital = int.Parse(Request.Form[" "]);
            _report.incomeHospitalChildrens = int.Parse(Request.Form[" "]);
            _report.outcomeHospital = int.Parse(Request.Form[" "]);
            _report.outcomeHospitalChildrens = int.Parse(Request.Form[" "]);
            _report.U071 = int.Parse(Request.Form[" "]);
            _report.U071Childrens = int.Parse(Request.Form[" "]);
            _report.U072 = int.Parse(Request.Form[" "]);
            _report.U072Childrens = int.Parse(Request.Form[" "]);
            _report.ORVI = int.Parse(Request.Form[" "]);
            _report.ORVIChildrens = int.Parse(Request.Form[" "]);
            _report.pneumonia = int.Parse(Request.Form[" "]);
            _report.pneumoniaChildrens = int.Parse(Request.Form[" "]);
            _report.OKI = int.Parse(Request.Form[" "]);
            _report.OKIChildrens = int.Parse(Request.Form[" "]);
            _report.meningit = int.Parse(Request.Form[" "]);
            _report.meningitChildrens = int.Parse(Request.Form[" "]);
            _report.hepatit = int.Parse(Request.Form[" "]);
            _report.hepatitChildrens = int.Parse(Request.Form[" "]);
            _report.HIV = int.Parse(Request.Form[" "]);
            _report.HIVCildrens = int.Parse(Request.Form[" "]);
            _report.other = int.Parse(Request.Form[" "]);
            _report.otherChildrens = int.Parse(Request.Form[" "]);
        }

    }
}

using DailyReport.Services;
using DailyReport.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;


namespace DailyReport.Pages.Reports
{
    [IgnoreAntiforgeryToken]
    public class DepReportModel : PageModel
    {
        ApplicationContext context;
        //[BindProperty]
        public DepReport _report = new DepReport();
        //public List<DepReport> Reports { get; private set; } = new();
        public DepReportModel(ApplicationContext db)
        {
            context = db;
        }

        public DepReportServise reportServise = new DepReportServise();
        public void OnGet()
        {
            _report = reportServise.CreateTest();
        }

        public void OnPost()
        {
            _report.depNumber = 1;
            _report.existed = int.Parse(Request.Form["existed"]);
            _report.existedChildrens = int.Parse(Request.Form["existedChildrens"]);
            _report.income = int.Parse(Request.Form["income"]);
            _report.incomeChildrens = int.Parse(Request.Form["incomeChildrens"]);
            _report.outcome = int.Parse(Request.Form["outcome"]);
            _report.outcomeChildrens = int.Parse(Request.Form["outcomeChildrens"]);
            _report.movedOutDep = int.Parse(Request.Form["movedOutDep"]);
            _report.movedOutDepChildrens = int.Parse(Request.Form["movedOutDepChildrens"]);
            _report.movedInDep = int.Parse(Request.Form["movedInDep"]);
            _report.movedInDepChildrens = int.Parse(Request.Form["movedInDepChildrens"]);
            _report.died = int.Parse(Request.Form["died"]);
            _report.diedChildrens = int.Parse(Request.Form["diedChildrens"]);
            _report.present = int.Parse(Request.Form["present"]);
            _report.presentChildrens = int.Parse(Request.Form["presentChildrens"]);
            _report.oIVL = int.Parse(Request.Form["oIVL"]);
            _report.oIVLChildrens = int.Parse(Request.Form["oIVLChildrens"]);
            _report.oNIVL = int.Parse(Request.Form["oNIVL"]);
            _report.oNIVLChildrens = int.Parse(Request.Form["oNIVLChildrens"]);
            _report.oNIVLVPO = int.Parse(Request.Form["oNIVLVPO"]);
            _report.oNIVLVPOChildrens = int.Parse(Request.Form["oNIVLVPOChildrens"]);
            _report.oNIVLMask = int.Parse(Request.Form["oNIVLMask"]);
            _report.oNIVLMaskChildrens = int.Parse(Request.Form["oNIVLMaskChildrens"]);
            _report.oMask = int.Parse(Request.Form["oMask"]);
            _report.oMaskChildren = int.Parse(Request.Form["oMaskChildren"]);
            _report.oBrease = int.Parse(Request.Form["oBrease"]);
            _report.oBreaseChildrens = int.Parse(Request.Form["oBreaseChildrens"]);
            _report.pregnant = int.Parse(Request.Form["pregnant"]);
            _report.pregnantChildrens = int.Parse(Request.Form["pregnantChildrens"]);
            _report.restZone = int.Parse(Request.Form["restZone"]);
            _report.restZoneChildrens = int.Parse(Request.Form["restZoneChildrens"]);
            _report.outRegions = int.Parse(Request.Form["outRegions"]);
            _report.outRegionsChildrens = int.Parse(Request.Form["outRegionsChildrens"]);
            _report.forein = int.Parse(Request.Form["forein"]);
            _report.foreinChildrens = int.Parse(Request.Form["foreinChildrens"]);
            _report.LNR_DNR = int.Parse(Request.Form["LNR_DNR"]);
            _report.LNR_DNRChildrens = int.Parse(Request.Form["LNR_DNRChildrens"]);
            _report.incomeHospital = int.Parse(Request.Form["incomeHospital"]);
            _report.incomeHospitalChildrens = int.Parse(Request.Form["incomeHospitalChildrens"]);
            _report.outcomeHospital = int.Parse(Request.Form["outcomeHospital"]);
            _report.outcomeHospitalChildrens = int.Parse(Request.Form["outcomeHospitalChildrens"]);
            _report.U071 = int.Parse(Request.Form["U071"]);
            _report.U071Childrens = int.Parse(Request.Form["U071Childrens"]);
            _report.U072 = int.Parse(Request.Form["U072"]);
            _report.U072Childrens = int.Parse(Request.Form["U072Childrens"]);
            _report.ORVI = int.Parse(Request.Form["ORVI"]);
            _report.ORVIChildrens = int.Parse(Request.Form["ORVIChildrens"]);
            _report.pneumonia = int.Parse(Request.Form["pneumonia"]);
            _report.pneumoniaChildrens = int.Parse(Request.Form["pneumoniaChildrens"]);
            _report.OKI = int.Parse(Request.Form["OKI"]);
            _report.OKIChildrens = int.Parse(Request.Form["OKIChildrens"]);
            _report.meningit = int.Parse(Request.Form["meningit"]);
            _report.meningitChildrens = int.Parse(Request.Form["meningitChildrens"]);
            _report.hepatit = int.Parse(Request.Form["hepatit"]);
            _report.hepatitChildrens = int.Parse(Request.Form["hepatitChildrens"]);
            _report.HIV = int.Parse(Request.Form["HIV"]);
            _report.HIVCildrens = int.Parse(Request.Form["HIVCildrens"]);
            _report.other = int.Parse(Request.Form["other"]);
            _report.otherChildrens = int.Parse(Request.Form["otherChildrens"]);

            context.DepReports.Add(_report);
            context.SaveChanges();
        }

    }
}

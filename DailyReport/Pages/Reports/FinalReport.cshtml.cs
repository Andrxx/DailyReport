using DailyReport.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace DailyReport.Pages.Reports
{
    public class FinalReportModel : PageModel
    {
        public FinalReport _finalReport;
        public List<FinalReport> _finalReports;
        public DepReport depReport1, depReport2, depReport3, depReport4, depReport5,
            depReport6, depReport7, depReport8, depReport90, depReport91;
        ApplicationContext context;
        public FinalReportModel(ApplicationContext db)
        {
            context = db;
        }
        public List<DepReport> reports { get; private set; } = new();
        public List<DepReport> _filteredReports = new List<DepReport>();
        DateTime actualDate = DateTime.Today.AddDays(-1);
        public int oxygenSum1, oxygenSum91, deseaseSum1, deseaseSum2, deseaseSum3, deseaseSum4, deseaseSum5, deseaseSum6, deseaseSum7,
            deseaseSum8, deseaseSum90, deseaseSum91, deseaseSum1Children, deseaseSum2Children, deseaseSum3Children, deseaseSum4Children,
            deseaseSum5Children, deseaseSum6Children, deseaseSum7Children, deseaseSum8Children, deseaseSum90Children, deseaseSum91Children,
            deseaseSumFinal, deseaseSumFinalChildren;

        public void OnGet()
        {
            //_rep = context.DepReports.AsNoTracking().ToList();
            _finalReports = context.FinalReports.AsNoTracking().ToList();

            reports = (from report in context.DepReports
                    where (report.date.Date == actualDate)
                    select report).ToList();

           
#pragma warning disable CS8601 // ¬озможно, назначение-ссылка, допускающее значение NULL.
            depReport1 = reports.Find(p => p.depNumber == 1);
            //depReport2 = reports.Find(p => p.depNumber == 2); //отделение пока не работает
            depReport3 = reports.Find(p => p.depNumber == 3);
            depReport4 = reports.Find(p => p.depNumber == 4);
            depReport5 = reports.Find(p => p.depNumber == 5);
            depReport6 = reports.Find(p => p.depNumber == 6);
            depReport7 = reports.Find(p => p.depNumber == 7);
            depReport8 = reports.Find(p => p.depNumber == 8);
            depReport90 = reports.Find(p => p.depNumber == 90);
            depReport91 = reports.Find(p => p.depNumber == 91);

             //_finalReport = (from report in context.FinalReports
             //                where report.date.Date == actualDate
             //               select report).FirstOrDefault();
#pragma warning restore CS8601 // ¬озможно, назначение-ссылка, допускающее значение NULL.
            if (depReport1 == null) depReport1 = new();
            if (depReport2 == null) depReport2 = new();
            if (depReport3 == null) depReport3 = new();
            if (depReport4 == null) depReport4 = new();
            if (depReport5 == null) depReport5 = new();
            if (depReport6 == null) depReport6 = new();
            if (depReport7 == null) depReport7 = new();
            if (depReport8 == null) depReport8 = new();
            if (depReport90 == null) depReport90 = new();
            if (depReport91 == null) depReport91 = new();

            if (_finalReport == null) _finalReport = new();

            _filteredReports.Add(depReport1);
            //_filteredReports.Add(depReport2); отделение не работает
            _filteredReports.Add(depReport3);
            _filteredReports.Add(depReport4);
            _filteredReports.Add(depReport5);
            _filteredReports.Add(depReport6);
            _filteredReports.Add(depReport7);
            _filteredReports.Add(depReport90);
            _filteredReports.Add(depReport91);

            //_filteredReports.Add(depReport8); дневной стационар не входит в обий список

            foreach (DepReport _rep in _filteredReports)
            {
                _finalReport.existed += _rep.existed;
                _finalReport.existedChildren += _rep.existedChildrens;
                _finalReport.income += _rep.income;
                _finalReport.incomeChildren += _rep.incomeChildrens;
                _finalReport.outcome += _rep.outcome;
                _finalReport.outcomeChildren += _rep.outcomeChildrens;
                _finalReport.attachedToORIT += _rep.attachedToORIT;
                _finalReport.attachedToORITChildren += _rep.attachedToORITCildrens;
                _finalReport.movedOutDep += _rep.movedOutDep;
                _finalReport.movedOutDepChildren += _rep.movedOutDepChildrens;
                _finalReport.movedInDep += _rep.movedInDep;
                _finalReport.movedInDepChildren += _rep.movedInDepChildrens;
                _finalReport.died += _rep.died;
                _finalReport.diedChildren += _rep.diedChildrens;
                _finalReport.present += _rep.present;
                _finalReport.presentChildren += _rep.presentChildrens;          
                _finalReport.oIVL += _rep.oIVL;
                _finalReport.oIVLChildren += _rep.oIVLChildrens;
                _finalReport.oNIVL += _rep.oNIVL;
                _finalReport.oNIVLChildren += _rep.oNIVLChildrens;
                _finalReport.oNIVLVPO += _rep.oNIVLVPO;
                _finalReport.oNIVLVPOChildren += _rep.oNIVLVPOChildrens;
                _finalReport.oNIVLMask += _rep.oNIVLMask;
                _finalReport.oNIVLMaskChildren += _rep.oNIVLMaskChildrens;
                _finalReport.oMask += _rep.oMask;
                _finalReport.oMaskChildren += _rep.oMaskChildren;
                _finalReport.pregnant += _rep.pregnant;
                _finalReport.pregnantChildren += _rep.pregnantChildrens;
                _finalReport.restZone += _rep.restZone;
                _finalReport.restZoneChildren += _rep.restZoneChildrens;
                _finalReport.outRegions += _rep.outRegions;
                _finalReport.outRegionsChildren += _rep.outRegionsChildrens;
                _finalReport.forein += _rep.foreinChildrens;
                _finalReport.LNR_DNR += _rep.LNR_DNR;
                _finalReport.LNR_DNRChildren += _rep.LNR_DNRChildrens;
                _finalReport.incomeHospital += _rep.incomeHospital;
                _finalReport.incomeHospitalChildren += _rep.incomeHospitalChildrens;
                _finalReport.outcomeHospital += _rep.outcomeHospital;
                _finalReport.outcomeHospitalChildren += _rep.outcomeHospitalChildrens;
                _finalReport.U071 += _rep.U071;
                _finalReport.U071Children += _rep.U071Childrens;
                _finalReport.U072 += _rep.U072;
                _finalReport.U072Children += _rep.U072Childrens;
                _finalReport.ORVI += _rep.ORVI;
                _finalReport.ORVIChildren += _rep.ORVIChildrens;
                _finalReport.pneumonia += _rep.pneumonia;
                _finalReport.pneumoniaChildren += _rep.pneumoniaChildrens;
                _finalReport.OKI += _rep.OKI;
                _finalReport.OKIChildren += _rep.OKIChildrens;
                _finalReport.meningit += _rep.meningit;
                _finalReport.meningitChildren += _rep.meningitChildrens;
                _finalReport.hepatit += _rep.hepatit;
                _finalReport.hepatitChildren += _rep.hepatitChildrens;
                _finalReport.HIV += _rep.HIV;
                _finalReport.HIVCildren += _rep.HIVCildrens;
                _finalReport.other += _rep.other;
                _finalReport.otherChildren += _rep.otherChildrens;
            }

           
            oxygenSum1 = depReport1.CountO2();
            oxygenSum91 = depReport91.CountO2();
            deseaseSum1 = depReport1.CountDiseases();
            deseaseSum2 = depReport1.CountDiseases();
            deseaseSum3 = depReport1.CountDiseases();
            deseaseSum4 = depReport1.CountDiseases();
            deseaseSum5 = depReport1.CountDiseases();
            deseaseSum6 = depReport1.CountDiseases();
            deseaseSum7 = depReport1.CountDiseases();
            deseaseSum8 = depReport1.CountDiseases();
            deseaseSum90 = depReport1.CountDiseases();
            deseaseSum91 = depReport1.CountDiseases();
            deseaseSum1Children = depReport1.CountDiseasesChildren();
            deseaseSum2Children = depReport1.CountDiseasesChildren();
            deseaseSum3Children = depReport1.CountDiseasesChildren();
            deseaseSum4Children = depReport1.CountDiseasesChildren();
            deseaseSum5Children = depReport1.CountDiseasesChildren();
            deseaseSum6Children = depReport1.CountDiseasesChildren();
            deseaseSum7Children = depReport1.CountDiseasesChildren();
            deseaseSum8Children = depReport1.CountDiseasesChildren();
            deseaseSum90Children = depReport1.CountDiseasesChildren();
            deseaseSum91Children = depReport1.CountDiseasesChildren();
            deseaseSumFinal = _finalReport.CountDiseases();
            deseaseSumFinalChildren = _finalReport.CountDiseasesChildren(); 
        }
    }
}

using DailyReport.Models;
using DailyReport.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace DailyReport.Pages.Reports
{
    [IgnoreAntiforgeryToken]
    public class FinalReportModel : PageModel
    {
        public FinalReport finalReport;
        public List<FinalReport> finalReports;
        public DepReport depReport1, depReport11, depReport2, depReport3, depReport4, depReport5,
            depReport6, depReport7, depReport8, depReport90, depReport91;
        ApplicationContext context;
        public FinalReportModel(ApplicationContext db)
        {
            context = db;
        }
        public List<DepReport> reports { get; private set; } = new();
        public List<DepReport> filteredReports = new List<DepReport>();
        DateTime actualDate = DateTime.Today.AddDays(-1);
        public int oxygenSum11, oxygenSum91, deseaseSum1, deseaseSum11, deseaseSum2, deseaseSum3, deseaseSum4, deseaseSum5, deseaseSum6, deseaseSum7,
            deseaseSum8, deseaseSum90, deseaseSum91, deseaseSum1Children, deseaseSum11Children, deseaseSum2Children, deseaseSum3Children, deseaseSum4Children,
            deseaseSum5Children, deseaseSum6Children, deseaseSum7Children, deseaseSum8Children, deseaseSum90Children, deseaseSum91Children,
            deseaseSumFinal, deseaseSumFinalChildren;
        //����������� ����� � ����������
        public DepartmentSpots departmentSpots; 
        //��������� �����
        public FreeSpots freeSpots;
        //������ ��������� �������� ����������
        public List<string> doctors = DutyServices.GetDoctorsList();
        [BindProperty]
        public DutyDoc newDoc { get; set; } = new();
        public List<DutyDoc> depDocs { get; set; } = new();
        public List<DutyDoc> oritDocs { get; set; } = new();
        public List<DutyDoc> ktDocs { get; set; } = new();
        [BindProperty]
        public OutcomingPatient newPatient { get; set; } = new();
        public List<OutcomingPatient> patients { get; set; } = new();
        public List<string> shipping = OutPatientService.GetShipping();
        public List<string> submitedFrom = OutPatientService.GetSubmitedFrom();
        public List<string> submitedTo = OutPatientService.GetSubmitedTo();

        public void OnGet()
        {
            departmentSpots = DepSpotsService.GetSpots();
            departmentSpots.sum = DepSpotsService.CountSum();
            departmentSpots.sumChildren = DepSpotsService.CountSumChildren();
            departmentSpots.sumOC = DepSpotsService.CountSumOC();
            departmentSpots.sumOCChildren = DepSpotsService.CountSumOCChildren();
            
            //todo - ������ ��� ������� ��
            //_rep = context.DepReports.AsNoTracking().ToList();
            //finalReports = context.FinalReports.AsNoTracking().ToList();

            try
            {
                reports = (from report in context.DepReports
                           where (report.date.Date == actualDate)
                           select report).ToList();
            }
            catch
            {
                reports = new();
            }
           
#pragma warning disable CS8601 // ��������, ����������-������, ����������� �������� NULL.
            depReport1 = reports.Find(p => p.depNumber == 1);
            depReport11 = reports.Find(p => p.depNumber == 11);
            //depReport2 = reports.Find(p => p.depNumber == 2); //��������� ���� �� ��������
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
#pragma warning restore CS8601 // ��������, ����������-������, ����������� �������� NULL.
            if (depReport1 == null) depReport1 = new();
            if (depReport11 == null) depReport11 = new();
            if (depReport2 == null) depReport2 = new();
            if (depReport3 == null) depReport3 = new();
            if (depReport4 == null) depReport4 = new();
            if (depReport5 == null) depReport5 = new();
            if (depReport6 == null) depReport6 = new();
            if (depReport7 == null) depReport7 = new();
            if (depReport8 == null) depReport8 = new();
            if (depReport91 == null) depReport91 = new();
            if (depReport90 == null) depReport90 = new();
            

            if (finalReport == null) finalReport = new();

            //������� ������� ��������� ������ ������ ��������������� ������� ��������� � ������
            filteredReports.Add(depReport11);
            filteredReports.Add(depReport1);
            //_filteredReports.Add(depReport2); ��������� �� ��������
            filteredReports.Add(depReport3);
            filteredReports.Add(depReport4);
            filteredReports.Add(depReport5);
            filteredReports.Add(depReport6);
            filteredReports.Add(depReport7);
            filteredReports.Add(depReport90);
            filteredReports.Add(depReport91);
            

            //� ����� �������� ������ �� ��������������� ������, ����� �������� �� (dep8)
            freeSpots = FreeSpotsServices.CountSpots(reports, departmentSpots);

            foreach (DepReport _rep in filteredReports)
            {
                finalReport.existed += _rep.existed;
                finalReport.existedChildren += _rep.existedChildrens;
                finalReport.income += _rep.income;
                finalReport.incomeChildren += _rep.incomeChildrens;
                finalReport.outcome += _rep.outcome;
                finalReport.outcomeChildren += _rep.outcomeChildrens;
                finalReport.attachedToORIT += _rep.attachedToORIT;
                finalReport.attachedToORITChildren += _rep.attachedToORITCildrens;
                finalReport.movedOutDep += _rep.movedOutDep;
                finalReport.movedOutDepChildren += _rep.movedOutDepChildrens;
                finalReport.movedInDep += _rep.movedInDep;
                finalReport.movedInDepChildren += _rep.movedInDepChildrens;
                finalReport.died += _rep.died;
                finalReport.diedChildren += _rep.diedChildrens;
                finalReport.present += _rep.present;
                finalReport.presentChildren += _rep.presentChildrens;          
                finalReport.oIVL += _rep.oIVL;
                finalReport.oIVLChildren += _rep.oIVLChildrens;
                finalReport.oNIVL += _rep.oNIVL;
                finalReport.oNIVLChildren += _rep.oNIVLChildrens;
                finalReport.oNIVLVPO += _rep.oNIVLVPO;
                finalReport.oNIVLVPOChildren += _rep.oNIVLVPOChildrens;
                finalReport.oNIVLMask += _rep.oNIVLMask;
                finalReport.oNIVLMaskChildren += _rep.oNIVLMaskChildrens;
                finalReport.oMask += _rep.oMask;
                finalReport.oMaskChildren += _rep.oMaskChildren;
                finalReport.pregnant += _rep.pregnant;
                finalReport.pregnantChildren += _rep.pregnantChildrens;
                finalReport.restZone += _rep.restZone;
                finalReport.restZoneChildren += _rep.restZoneChildrens;
                finalReport.outRegions += _rep.outRegions;
                finalReport.outRegionsChildren += _rep.outRegionsChildrens;
                finalReport.forein += _rep.foreinChildrens;
                finalReport.LNR_DNR += _rep.LNR_DNR;
                finalReport.LNR_DNRChildren += _rep.LNR_DNRChildrens;
                finalReport.incomeHospital += _rep.incomeHospital;
                finalReport.incomeHospitalChildren += _rep.incomeHospitalChildrens;
                finalReport.outcomeHospital += _rep.outcomeHospital;
                finalReport.outcomeHospitalChildren += _rep.outcomeHospitalChildrens;
                finalReport.U071 += _rep.U071;
                finalReport.U071Children += _rep.U071Childrens;
                finalReport.U072 += _rep.U072;
                finalReport.U072Children += _rep.U072Childrens;
                finalReport.ORVI += _rep.ORVI;
                finalReport.ORVIChildren += _rep.ORVIChildrens;
                finalReport.pneumonia += _rep.pneumonia;
                finalReport.pneumoniaChildren += _rep.pneumoniaChildrens;
                finalReport.OKI += _rep.OKI;
                finalReport.OKIChildren += _rep.OKIChildrens;
                finalReport.meningit += _rep.meningit;
                finalReport.meningitChildren += _rep.meningitChildrens;
                finalReport.hepatit += _rep.hepatit;
                finalReport.hepatitChildren += _rep.hepatitChildrens;
                finalReport.HIV += _rep.HIV;
                finalReport.HIVCildren += _rep.HIVCildrens;
                finalReport.other += _rep.other;
                finalReport.otherChildren += _rep.otherChildrens;
            }
            filteredReports.Add(depReport8); //������� ��������� �� ������ � ����� ������, ��������� ��� � ���� ����� ���������� ������ ����������

            oxygenSum11 = depReport11.CountO2();
            oxygenSum91 = depReport91.CountO2();
            deseaseSum1 = depReport1.CountDiseases();
            deseaseSum11 = depReport11.CountDiseases();
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
            deseaseSum11Children = depReport11.CountDiseasesChildren();
            deseaseSum2Children = depReport1.CountDiseasesChildren();
            deseaseSum3Children = depReport1.CountDiseasesChildren();
            deseaseSum4Children = depReport1.CountDiseasesChildren();
            deseaseSum5Children = depReport1.CountDiseasesChildren();
            deseaseSum6Children = depReport1.CountDiseasesChildren();
            deseaseSum7Children = depReport1.CountDiseasesChildren();
            deseaseSum8Children = depReport1.CountDiseasesChildren();
            deseaseSum90Children = depReport1.CountDiseasesChildren();
            deseaseSum91Children = depReport1.CountDiseasesChildren();
            deseaseSumFinal = finalReport.CountDiseases();
            deseaseSumFinalChildren = finalReport.CountDiseasesChildren();

            try 
            { 
                depDocs = (from doc in context.DutyDocs
                        where (doc.dutyDate == actualDate) & (doc.type == DutyType.Department)
                        select doc).ToList();
            }
            catch
            {
            }

            try
            {
                oritDocs = (from doc in context.DutyDocs
                           where (doc.dutyDate == actualDate) & (doc.type == DutyType.Reanimanion)
                           select doc).ToList();
            }
            catch
            {
            }
            try
            {
                ktDocs = (from doc in context.DutyDocs
                            where (doc.dutyDate == actualDate) & (doc.type == DutyType.Rentgenology)
                            select doc).ToList();
            }
            catch
            {
            }
            try
            {
                patients = (from patient in context.OutcomingPatients
                            where (patient.Date == actualDate)
                            select patient).ToList();
            }
            catch
            {
            }
        }




        /// <summary>
        /// todo ���������� ��������� ������
        /// </summary>
        public void SaveReport()
        {
            
        }

        /// <summary>
        /// ���������� ������ ����� ����� ���������� ��������
        /// </summary>
        /// <returns></returns>
        public IActionResult OnPostSaveDoc()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            DutyServices.AddDutyDoc(newDoc, context);
            return RedirectToAction("Get");
        }

        public IActionResult OnPostDeleteDoc(int id)
        {
            DutyServices.DeleteDutyDoc(id, context);
            return RedirectToAction("Get");
        }

        public IActionResult OnPostUpdateDoc()
        {
            DutyServices.UpdateDutyDoc(newDoc, context);
            return RedirectToAction("Get");
        }


        public IActionResult OnPostSavePatients()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            OutPatientService.AddPatient(newPatient, context);
            return RedirectToAction("Get");
        }

        public IActionResult OnPostDeletePaient(int id)
        {
            OutPatientService.DeleteOutPatient(id, context);
            return RedirectToAction("Get");
        }

        public IActionResult OnPostUpdatePatient()
        {
            OutPatientService.UpdateOutPatient(newPatient, context);
            return RedirectToAction("Get");
        }
    }
}

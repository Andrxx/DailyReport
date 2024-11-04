using DailyReport.Models;
using DailyReport.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Composition;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic;
using DailyReport.Models.DTO;
using System;
using DailyReport.Models.Reports;
using DailyReport.Models.PersonelFolder;
using DailyReport.Services.Reports;

namespace DailyReport.Pages.Reports
{
    [IgnoreAntiforgeryToken]
    public class FinalReportModel : PageModel
    {
        private readonly IConfiguration appConfig;
        public FinalReport finalReport;
        public List<FinalReport> finalReports;
        public DepReport?  KDOreport, PayServiceReport, DayCareReport;
        ApplicationContext context;
        public FinalReportModel(ApplicationContext db, IConfiguration Configuration )
        {
            appConfig = Configuration; 
            context = db;
        }
        public List<FullReportData> FullReports { get; set; } = new();
        public List<Department> activeDepartments { get; set; } = new();
        public List<Department> allDepartments { get; set; } = new();
        public List<DepReport> reports { get; private set; } = new();
        public List<DepReport>  sortedReports = new ();
        //public HospitalSpots hospitalSpots { get; set; }

        public List<DepReport> filteredReports = new List<DepReport>();
        public DateTime actualDate = DateTime.Now, reportDate;
        public bool _onlyView;
        public int  deseaseSumFinal, deseaseSumFinalChildren;
        public int reject, rejectChildren, ambulance, ambulanceChildren, submitOtherHosp, submitOtherHospChildren, sumReject,
            sumAmbulance, sumOther, sumAdults, sumChildren, sumTotal;
            
        public int? KDOallias, PayServAllias, DCallias, ORITAllias, ORITDirtyAllias;
        //фактические места в отделениях
        //public DepartmentSpots departmentSpots; 
        //свободные места
        public FreeSpots freeSpots;
        public List<string> doctors;
        public OutcomingPatient savedPatient = new(); //поле для работы частичного представления формы, не использовать кроме вызова форм
        public int departmentCounter, AdultSpotsSum, ChildrenSpotsSum, AdultAdditionalSpots, ChildrenAdditionalSpots, AdultFullSpotsSum, ChildrenFullSpotsSum
            , ORITAdults, ORITChildren;
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

        public List<int> excludedDeps = new();
        public List<int> excludedSpots = new();
        public List<int> ORITcorrection = new();
        public List<int> diseaseSums = new();
        public List<int> oxygenSum = new();
        string ReportTimeChange;
        public string OptionNozologyName, OptionOxygenName, OptionCareName, OptionSocialName;
        public string NozologyVisibility, SocialVisibility, OxygenVisibility, CareVisibility;
        public void OnGet(double dateOffset = 0, bool onlyView = false)
        {
            var ed = appConfig["ExcludedDepartments:FinalReportSpotsExclusion"];
            try { 
                if (ed != null) excludedSpots = ed.Split(' ').Select(x => int.Parse(x)).ToList();
                else excludedSpots = new(); 
            }
            catch { excludedSpots = new(); }

            var corr = appConfig["ExcludedDepartments:FinalReportORITSpotsCorrection"];
            try
            {
                if (corr != null) ORITcorrection = corr.Split(' ').Select(x => int.Parse(x)).ToList();
                else ORITcorrection = new();
            }
            catch { ORITcorrection = new(); }

            var depExc = appConfig["ExcludedDepartments:FinalReportDepartmentsExclusion"];
            try
            {
                if (depExc != null) excludedDeps = depExc.Split(' ').Select(x => int.Parse(x)).ToList();
                else excludedDeps = new();
            }
            catch { excludedDeps = new(); }

            try
            {
                DCallias = int.Parse(appConfig["DayCareAllias"]);
            }
            catch { DCallias = 21; }
            try
            {
                KDOallias = int.Parse(appConfig["KDOallias"]);
            }
            catch { }
            try
            {
                PayServAllias = int.Parse(appConfig["PayServiceAllias"]);
            }
            catch { }
            try
            {
                ORITDirtyAllias = int.Parse(appConfig["ORITDirtyAllias"]);
            }
            catch {  }
            try
            {
                ORITAllias = int.Parse(appConfig["ORITAllias"]);
            }
            catch { }
            //проверка статуса настраиваемых полей сводки
            try
            {
                OptionOxygenName = appConfig["Oxygen:Name"];
                if (!bool.Parse(appConfig["Oxygen:Visible"])) OxygenVisibility = "hidden";
            }
            catch
            {
                OptionOxygenName = "";
                OxygenVisibility = "hidden";
            }

            try
            {
                OptionNozologyName = appConfig["Nozology:Name"];
                if (!bool.Parse(appConfig["Nozology:Visible"])) NozologyVisibility = "hidden";
            }
            catch
            {
                OptionNozologyName = "";
                NozologyVisibility = "hidden";
            }

            try
            {
                OptionSocialName = appConfig["Social:Name"];
                if (!bool.Parse(appConfig["Social:Visible"])) SocialVisibility = "hidden";
            }
            catch
            {
                OptionSocialName = "";
                SocialVisibility = "hidden";
            }

            try
            {
                OptionCareName = appConfig["Care:Name"];
                if (!bool.Parse(appConfig["Care:Visible"])) CareVisibility = "hidden";
            }
            catch
            {
                OptionCareName = "";
                CareVisibility = "hidden";
            }

            try
            {
                ReportTimeChange = (appConfig["ReportTimeChange"]);
            }
            catch { ReportTimeChange = "08:00:00"; }
            _onlyView = onlyView;
            actualDate = actualDate.AddDays(dateOffset);

            //DateTime startTime = new DateTime(actualDate.Year, actualDate.Month, actualDate.Day, 8, 00, 00);
            DateTime startTime = DateOnly.FromDateTime(actualDate).ToDateTime(TimeOnly.Parse(ReportTimeChange));

            //DateTime endTime = new DateTime(actualDate.Year, actualDate.Month, actualDate.Day, 7, 59, 59).AddDays(1);
            DateTime endTime = DateOnly.FromDateTime(actualDate).ToDateTime(TimeOnly.Parse(ReportTimeChange)).AddDays(1).AddSeconds(-1);
            if (actualDate.Hour < startTime.Hour)
            {
                startTime = startTime.AddDays(-1);
                endTime = endTime.AddDays(-1);
                reportDate = actualDate.AddDays(-1);
            }
            //задаем дату отображения на сводке, устнавливть только после коррекции стартовой даты 
            else { reportDate = actualDate; }

            //получаем список актуальных отделений
            activeDepartments = DepartmentServices.GetSortedDepartments(context, excludedDeps);
            departmentCounter = activeDepartments.Count;

            allDepartments = DepartmentServices.GetSortedDepartments(context);

            //Формируем список полных отчетов для всех отделений, 
            //foreach (var dep in allDepartments) 
            //{
            //    FullReportData _frd = new FullReportData();
            //    _frd.Department = dep;
            //    _frd.CountSpots = !excludedSpots.Contains(dep.Allias);
            //    _frd.ShowInFinalReport = !excludedDeps.Contains(dep.Allias);

            //    FullReports.Add(_frd);
            //}

            //подсчет свободных мест
            //hospitalSpots = DepSpotsService.GetHospitalSpots(FullReports);
            ////добавляем отдельно места для ОРИТ, чистой и грязной зоны, дневного стационара
            //var fullrep = FullReports.Find(frd => frd.Department.Allias == ORITAllias);
            //if (fullrep != null)
            //{
            //    hospitalSpots.ORITAdult += fullrep.Department.AdultSpotsQuantity;
            //    hospitalSpots.ORITChildren += fullrep.Department.ChildrenSpotsQuantity;
            //}
            //fullrep = FullReports.Find(frd => frd.Department.Allias == ORITDirtyAllias);
            //{
            //    hospitalSpots.ORITAdult += fullrep.Department.AdultSpotsQuantity;
            //    hospitalSpots.ORITChildren += fullrep.Department.ChildrenSpotsQuantity;
            //}
            //fullrep = FullReports.Find(frd => frd.Department.Allias == DCallias);
            //{
            //    hospitalSpots.DayCareAdult += fullrep.Department.AdultSpotsQuantity;
            //    hospitalSpots.DayCareChildren += fullrep.Department.ChildrenSpotsQuantity;
            //}

             
            AdultSpotsSum = DepSpotsService.GetAdultSpots(activeDepartments, excludedSpots);
            ChildrenSpotsSum = DepSpotsService.GetChildrenSpots(activeDepartments, excludedSpots);
            AdultFullSpotsSum = DepSpotsService.GetFullAdultSpots(activeDepartments, ORITcorrection);
            ChildrenFullSpotsSum = DepSpotsService.GetFullChildrenSpots(activeDepartments, ORITcorrection);
            try
            {
                ORITAdults = activeDepartments.FirstOrDefault(d => d.Allias == ORITAllias).AdultSpotsQuantity
                    + activeDepartments.FirstOrDefault(d => d.Allias == ORITDirtyAllias).AdultSpotsQuantity;
            }
            catch { ORITAdults = 0; }
            try
            {
                ORITChildren = activeDepartments.FirstOrDefault(d => d.Allias == ORITAllias).ChildrenSpotsQuantity
                    + activeDepartments.FirstOrDefault(d => d.Allias == ORITDirtyAllias).ChildrenSpotsQuantity;
            }
            catch { ORITChildren = 0; }

            //Получаем список актуальных сводок из БД
            try
            {
                reports = (from report in context.DepReports
                           where ((report.date > startTime) && (report.date < endTime))
                           select report).ToList();
            }
            catch
            {
                reports = new();
            }
            //Передаем сводки из списка в переменные
            foreach (Department dep in activeDepartments) 
            {
                DepReport? _rep = reports.Find(rep => rep.depNumber == dep.Allias);
                if (_rep is null) _rep = new DepReport() { depNumber = dep.Allias };
                sortedReports.Add(_rep);
            }

            //данные по КДО и платным услугам
            KDOreport = reports.Find(p => p.depNumber == KDOallias);
            if(KDOreport is null) KDOreport = new DepReport();
            PayServiceReport = reports.Find(p => p.depNumber == PayServAllias);
            if(PayServiceReport is null) PayServiceReport = new DepReport();

            //получаем дневной стационар
            DayCareReport = reports.Find(p => p.depNumber == DCallias);


            //на выходных загружаем данные предыдущей сводки для дневного стационара
            if ((actualDate.DayOfWeek == DayOfWeek.Sunday || actualDate.DayOfWeek == DayOfWeek.Saturday) && (DCallias is not null))
            {
                //DayCareReport = reports.Find(p => p.depNumber == DCallias);
                if (DayCareReport is null)
                {
                    DepReport? report = DepReportServise.GetRepByNumberNoTracking(context, (int)DCallias, startTime.AddDays(-1), endTime.AddDays(-1));
                    if (report is not null)
                    {
                        DayCareReport = (DepReport)report.Clone();
                        //меняем дату на текущую и обнуляем ИД для сохранения новой записи в БД
                        DayCareReport.date = actualDate;
                        DayCareReport.Id = 0;
                        DayCareReport.depNumber = (int)DCallias;
                        DayCareReport.present = report.present;
                        DayCareReport.presentChildrens = report.presentChildrens;
                        DayCareReport.existed = report.present;
                        DayCareReport.existedChildren = report.presentChildrens;
                        DayCareReport.income = 0;
                        DayCareReport.incomeChildren = 0;
                        DayCareReport.outcome = 0;
                        DayCareReport.outcomeChildrens = 0;
                        DayCareReport.movedInDep = 0;
                        DayCareReport.movedOutDep = 0;
                        DayCareReport.movedInDepChildrens = 0;
                        DayCareReport.movedOutDepChildrens = 0;
                        DayCareReport.died = 0;
                        DayCareReport.diedChildrens = 0;
                        sortedReports[sortedReports.FindIndex(p => p.depNumber == DCallias)] = DayCareReport;
                        context.DepReports.Update(DayCareReport);
                        context.SaveChanges();
                    }
                }
            }
            if (DayCareReport is null) DayCareReport = new();
            if (finalReport is null) finalReport = new();
            //Считаем сумму по отделениям
            foreach (DepReport _rep in sortedReports)
            {
                if (_rep.depNumber != DCallias) //выводим из подсчета дневной стационар
                {
                    finalReport.existed += _rep.existed;
                    finalReport.existedChildren += _rep.existedChildren;
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
                    finalReport.optionalOxygen += _rep.optionalOxygen;
                    finalReport.optionalOxygenChildren += _rep.optionalOxygenChildren;
                    finalReport.optionalSocial += _rep.optionalSocial;
                    finalReport.optionalSocialChildren += _rep.optionalSocialChildren;
                    finalReport.pregnant += _rep.pregnant;
                    finalReport.pregnantChildren += _rep.pregnantChildrens;
                    finalReport.restZone += _rep.restZone;
                    finalReport.restZoneChildren += _rep.restZoneChildrens;
                    finalReport.outRegions += _rep.outRegions;
                    finalReport.outRegionsChildren += _rep.outRegionsChildrens;
                    finalReport.forein += _rep.forein;
                    finalReport.foreinChildren += _rep.foreinChildrens;
                    finalReport.LNR_DNR += _rep.LNR_DNR;
                    finalReport.LNR_DNRChildren += _rep.LNR_DNRChildrens;
                    finalReport.otherUkrane += _rep.otherUkrane;
                    finalReport.otherUkraneChildren += _rep.otherUkraneChildren;
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
                    finalReport.grippe += _rep.grippe;
                    finalReport.grippeChildren += _rep.grippeChildrens;
                    finalReport.pneumonia += _rep.pneumonia;
                    finalReport.pneumoniaChildren += _rep.pneumoniaChildrens;
                    finalReport.measles += _rep.measles;
                    finalReport.measlesChildren += _rep.measlesChildren;
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
                    finalReport.sepsis += _rep.sepsis;
                    finalReport.sepsisChildren += _rep.sepsisChildren;
                    finalReport.optionalNozology += _rep.optionalNozology;
                    finalReport.optionalNozologyChildren += _rep.optionalNozologyChildren;
                    finalReport.care += _rep.care;
                    finalReport.careDisodered += _rep.careDisodered;
                    finalReport.optionalCare += _rep.optionalCare;
                    
                }
            }
            
            foreach(DepReport rep in sortedReports)
            {
                diseaseSums.Add(rep.CountDiseases());
                diseaseSums.Add(rep.CountDiseasesChildren());
                oxygenSum.Add(rep.CountO2());
            }

            deseaseSumFinal = finalReport.CountDiseases();
            deseaseSumFinalChildren = finalReport.CountDiseasesChildren();


            //список доступных докторов стационара
            doctors = DutyServices.GetDoctorsList(context);

            try 
            { 
                depDocs = (from doc in context.DutyDocs
                        where ((doc.dutyDate > startTime) && (doc.dutyDate < endTime)) & (doc.type == DutyType.Department)
                        select doc).ToList();
            }
            catch
            {
            }
            try
            {
                oritDocs = (from doc in context.DutyDocs
                           where ((doc.dutyDate > startTime) && (doc.dutyDate < endTime)) & (doc.type == DutyType.Reanimanion)
                           select doc).ToList();
            }
            catch
            {
            }
            try
            {
                ktDocs = (from doc in context.DutyDocs
                            where ((doc.dutyDate > startTime) && (doc.dutyDate < endTime)) & (doc.type == DutyType.Rentgenology)
                            select doc).ToList();
            }
            catch
            {
            }
            try
            {
                patients = OutPatientService.GetOutPatientList(startTime, endTime, context);

                //todo исправить возможное отсутствие возрста
                if (patients != null)
                {
                    //Regex regex = new Regex(@"отказ(\w*)");
                    reject = patients.FindAll(p => int.Parse(p.AgeYears) > 17 & p.SubmitedTo.ToLower().Trim() == "отказался").Count();
                    rejectChildren = patients.FindAll(p => int.Parse(p.AgeYears) < 18 & p.SubmitedTo.ToLower().Trim() == "отказался").Count();

                    ambulance = patients.FindAll(p => float.Parse(p.AgeYears) >= 18 & p.SubmitedTo.ToLower().Trim() == "амбулаторно").Count();
                    ambulanceChildren = patients.FindAll(p => float.Parse(p.AgeYears) < 18 & p.SubmitedTo.ToLower().Trim() == "амбулаторно").Count();
                    
                    submitOtherHosp = patients.FindAll(p => float.Parse(p.AgeYears) >= 18 & p.SubmitedTo.ToLower().Trim() != "амбулаторно" 
                        & p.SubmitedTo.ToLower().Trim() != "отказался").Count();
                    submitOtherHospChildren = patients.FindAll(p => float.Parse(p.AgeYears) < 18 & p.SubmitedTo.ToLower().Trim() != "амбулаторно"
                        & p.SubmitedTo.ToLower().Trim() != "отказался").Count();
                    
                    sumReject = reject + rejectChildren;
                    sumAmbulance = ambulance + ambulanceChildren;
                    sumOther = submitOtherHosp + submitOtherHospChildren;
                    sumAdults = reject + ambulance + submitOtherHosp;
                    sumChildren = rejectChildren + ambulanceChildren + submitOtherHospChildren;
                    sumTotal = sumAdults + sumChildren;
                }
            }
            catch
            {
            }
        }
        
        /// <summary>
        /// сохранение данных смены через абстракцию сервисов
        /// </summary>
        /// <returns></returns>
        public IActionResult OnPostSaveDoc()
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Get");
            }
            newDoc.dutyDate = actualDate;
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
        /// <summary>
        /// Сохраняем пациента, метод с перезагрузкой страницы
        /// </summary>
        /// <returns></returns>
        public IActionResult OnPostSavePatients()
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Get");
            }
            newPatient.Date = actualDate;
            OutPatientService.AddPatient(newPatient, context);
            return RedirectToAction("Get");
        }
        /// <summary>
        /// Сохраняем пациента, метод без перезагрузки страницы
        /// </summary>
        /// <returns></returns>
        public IActionResult OnPostFetchSavePatients()
        {
            try
            {
                newPatient.Date = actualDate;
                OutPatientService.AddPatient(newPatient, context);
                OutcomingPatient p = OutPatientService.GetOutPatientById(newPatient.Id, context);
                if (p != null)
                {
                    //string pat = JsonConvert.SerializeObject(p);
                    return Content(JsonConvert.SerializeObject(p));
                }
                else
                {
                    return new NotFoundResult();
                }
            }
            catch
            {
                return new NotFoundResult();
            }
        }

        public IActionResult OnPostDeletePaient(int id)
        {
            OutPatientService.DeleteOutPatient(id, context);
            return RedirectToAction("Get");
        }
        /// <summary>
        /// Обновляем пациента, метод перезагружет страницу
        /// </summary>
        /// <returns></returns>
        public IActionResult OnPostUpdatePatient()
        {
            OutPatientService.UpdateOutPatient(newPatient, context);
            return RedirectToAction("Get");
        }
        /// <summary>
        /// Обновляем данные пациента, метод для скрытой загрузки на странице без обновления
        /// </summary>
        /// <returns></returns>
        public IActionResult OnPostFetchPatient()
        {
            try
            {
                OutPatientService.UpdateOutPatient(newPatient, context);
                OutcomingPatient p = OutPatientService.GetOutPatientById(newPatient.Id, context);
                if (p != null)
                {
                    string pat = JsonConvert.SerializeObject(p);
                    return Content(JsonConvert.SerializeObject(p));
                }
                else
                {
                    return new NotFoundResult();
                }
            }
            catch
            {
                return new NotFoundResult();
            }
        }
    
    
        private DepReport AddDCreport (DateTime startTime, DateTime endTime)
        {
            DepReport? _report = new DepReport();
            _report = DepReportServise.GetRepByNumber(context, (int)DCallias, startTime, endTime);
            if (_report is null)
            {
                //depReport8 = (DepReport)_report.Clone();
                ////меняем дату на текущую и обнуляем ИД для сохранения новой записи в БД
                //depReport8.date = actualDate;
                //depReport8.Id = 0;
                //depReport8.present = _report.present;
                //depReport8.presentChildrens = _report.presentChildrens;
                //depReport8.existed = _report.present;
                //depReport8.existedChildren = _report.presentChildrens;
                //depReport8.income = 0;
                //depReport8.incomeChildren = 0;
                //depReport8.outcome = 0;
                //depReport8.outcomeChildrens = 0;
                //depReport8.movedInDep = 0;
                //depReport8.movedOutDep = 0;
                //depReport8.movedInDepChildrens = 0;
                //depReport8.movedOutDepChildrens = 0;
                //depReport8.died = 0;
                //depReport8.diedChildrens = 0;
                //context.DepReports.Update(depReport8);
                //context.SaveChanges();
            }
            else
            {
                return _report;
            }

            return _report;
            //    }
        }
    }

}


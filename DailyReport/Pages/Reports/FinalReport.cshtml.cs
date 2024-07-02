using DailyReport.Models;
using DailyReport.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Composition;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace DailyReport.Pages.Reports
{
    [IgnoreAntiforgeryToken]
    public class FinalReportModel : PageModel
    {


        public FinalReport finalReport;
        public List<FinalReport> finalReports;
        public DepReport  depReport81, depReport82;
        ApplicationContext context;
        public FinalReportModel(ApplicationContext db)
        {
            context = db;
        }

        public List<Department> activeDepartments { get; set; } = new();
        public List<DepReport> reports { get; private set; } = new();
        public List<DepReport>  sortedReports = new ();
        public List<DepReport> filteredReports = new List<DepReport>();
        public DateTime actualDate = DateTime.Now, reportDate;
        public bool _onlyView;
        public int  deseaseSumFinal, deseaseSumFinalChildren;
        public int reject, rejectChildren, ambulance, ambulanceChildren, submitOtherHosp, submitOtherHospChildren, sumReject, 
            sumAmbulance, sumOther, sumAdults, sumChildren, sumTotal;
        //фактические места в отделениях
        //public DepartmentSpots departmentSpots; 
        //свободные места
        public FreeSpots freeSpots;
        public List<string> doctors;
        public OutcomingPatient savedPatient = new(); //поле для работы частичного представления формы, не использовать кроме вызова форм
        public int departmentCounter, AdultSpotsSum, ChildrenSpotsSum, AdultAdditionalSpots, ChildrenAdditionalSpots, AdultFullSpotsSum, ChildrenFullSpotsSum
            , ORITAdults, ORITChildren, AdditionalAdults, AdditionalChildren;
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

        public List<int> excludedDeps = new() {21, 90, 91 };
        public List<int> diseaseSums = new();
        public List<int> oxygenSum = new();


        public void OnGet(double dateOffset = 0, bool onlyView = false)
        {
            _onlyView = onlyView;
            actualDate = actualDate.AddDays(dateOffset);
            DateTime startTime = new DateTime(actualDate.Year, actualDate.Month, actualDate.Day, 8, 0, 0);
            DateTime endTime = new DateTime(actualDate.Year, actualDate.Month, actualDate.Day, 7, 59, 59).AddDays(1);
            if (actualDate.Hour < 8)
            {
                startTime = startTime.AddDays(-1);
                endTime = endTime.AddDays(-1);
                reportDate = actualDate.AddDays(-1);
            }
            //задаем дату отображения на сводке, устнавливть только после коррекции стартовой даты 
            else { reportDate = actualDate; }

            //получаем список актуальных отделений
            activeDepartments = DepartmentServices.GetSortedDepartments(context);
            departmentCounter = activeDepartments.Count;

            //подсчет свободных мест

            AdultSpotsSum = DepSpotsService.GetAdultSpots(activeDepartments, excludedDeps);
            ChildrenSpotsSum = DepSpotsService.GetChildrenSpots(activeDepartments, excludedDeps);
            AdultFullSpotsSum = DepSpotsService.GetFullAdultSpots(activeDepartments);
            ChildrenFullSpotsSum = DepSpotsService.GetFullChildrenSpots(activeDepartments);
            try
            {
                ORITAdults = activeDepartments.FirstOrDefault(d => d.Allias == 90).AdultSpotsQuantity
                    + activeDepartments.FirstOrDefault(d => d.Allias == 91).AdultSpotsQuantity;
            }
            catch { ORITAdults = 0; }
            try
            {
                ORITChildren = activeDepartments.FirstOrDefault(d => d.Allias == 90).ChildrenSpotsQuantity
                    + activeDepartments.FirstOrDefault(d => d.Allias == 91).ChildrenSpotsQuantity;
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
                if (_rep is null) _rep = new DepReport();
                sortedReports.Add(_rep);
            }


#pragma warning disable CS8601 // Возможно, назначение-ссылка, допускающее значение NULL.
            //данные по КДО и платным услугам
            depReport81 = reports.Find(p => p.depNumber == 81);
            depReport82 = reports.Find(p => p.depNumber == 82);

            //получаем пациентов

#pragma warning restore CS8601 // Возможно, назначение-ссылка, допускающее значение NULL.
            //if (depReport8 == null)
            //{
            //    //на выходных загружаем данные предыдущей сводки
            //    if (actualDate.DayOfWeek == DayOfWeek.Sunday || actualDate.DayOfWeek == DayOfWeek.Saturday)
            //    {
            //        DepReport report = (from r in context.DepReports
            //                            where (r.depNumber == 8) && (r.date > startTime.AddDays(-1)) && (r.date < endTime.AddDays(-1))
            //                            select r).AsNoTracking().FirstOrDefault();
            //        if (report != null)
            //        {
            //            depReport8 = (DepReport)report.Clone();
            //            //меняем дату на текущую и обнуляем ИД для сохранения новой записи в БД
            //            depReport8.date = actualDate;
            //            depReport8.Id = 0;
            //            depReport8.present = report.present;
            //            depReport8.presentChildrens = report.presentChildrens;
            //            depReport8.existed = report.present;
            //            depReport8.existedChildren = report.presentChildrens;
            //            depReport8.income = 0;
            //            depReport8.incomeChildren = 0;
            //            depReport8.outcome = 0;
            //            depReport8.outcomeChildrens = 0;
            //            depReport8.movedInDep = 0;
            //            depReport8.movedOutDep = 0;
            //            depReport8.movedInDepChildrens = 0;
            //            depReport8.movedOutDepChildrens = 0;
            //            depReport8.died = 0;
            //            depReport8.diedChildrens = 0;
            //            context.DepReports.Update(depReport8);
            //            context.SaveChanges();
            //        }
            //        else
            //        {
            //            depReport8 = new();
            //        }
            //    }

            //костыль - платные услуги и КДО, пока не входят в сводки, обработать в будущем
            if (depReport81 == null) depReport81 = new();
            if (depReport82 == null) depReport82 = new();

            if (finalReport == null) finalReport = new();

            //Считаем сумму по отделениям
            foreach (DepReport _rep in sortedReports)
            {
                if (_rep.depNumber != 21) //выводим из подсчета дневной стационар
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
                    finalReport.care += _rep.care;
                    finalReport.careDisodered += _rep.careDisodered;
                }
            }
            
            //filteredReports.Add(depReport8); //дневной стационар не входит в общий список, добавляем его в лист после вычисления общего количества

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
    }
}

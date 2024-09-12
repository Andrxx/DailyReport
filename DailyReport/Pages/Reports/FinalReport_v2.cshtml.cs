using DailyReport.Models;
using DailyReport.Models.PersonelFolder;
using DailyReport.Models.Reports;
using DailyReport.Services.Reports;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DailyReport.Pages.Reports
{
    public class FinalReport_v2Model : PageModel
    {
        public FinalReport finalReport;
        public List<FinalReport> finalReports;
        public DepReport depReport1, depReport11, depReport2, depReport3, depReport31, depReport4, depReport5, depReport51,
            depReport6, depReport7, depReport61, depReport71, depReport8, depReport90, depReport91, depReport81, depReport82;
        ApplicationContext context;
        public FinalReport_v2Model(ApplicationContext db)
        {
            context = db;
        }
        public List<DepReport> reports { get; private set; } = new();
        public List<DepReport> filteredReports = new List<DepReport>();
        public DateTime actualDate = DateTime.Now, reportDate;
        public bool _onlyView;
        public int oxygenSum1, oxygenSum11, oxygenSum91, oxygenSum90, deseaseSum1, deseaseSum11, deseaseSum2, deseaseSum3, deseaseSum31, deseaseSum4, deseaseSum5,
            deseaseSum51, deseaseSum6, deseaseSum7, deseaseSum61, deseaseSum71, deseaseSum8, deseaseSum90, deseaseSum91, deseaseSum1Children,
            deseaseSum11Children, deseaseSum2Children, deseaseSum3Children, deseaseSum31Children, deseaseSum4Children, deseaseSum5Children, deseaseSum51Children,
            deseaseSum6Children, deseaseSum61Children, deseaseSum7Children, deseaseSum71Children, deseaseSum8Children, deseaseSum90Children, deseaseSum91Children, deseaseSumFinal,
            deseaseSumFinalChildren, UkraneSum, UkraneSumChildren;
        public int reject, rejectChildren, ambulance, ambulanceChildren, submitOtherHosp, submitOtherHospChildren, sumReject,
            sumAmbulance, sumOther, sumAdults, sumChildren, sumTotal;
        //фактические места в отделениях
        public DepartmentSpots departmentSpots;
        //свободные места
        public FreeSpots freeSpots;
        public List<string> doctors;
        public OutcomingPatient savedPatient = new(); //поле для работы частичного представления формы, не использовать кроме вызова форм

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
        }
    }
}

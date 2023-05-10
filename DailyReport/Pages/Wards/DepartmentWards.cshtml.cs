using DailyReport.Models;
using DailyReport.Models.WardsModels;
using DailyReport.Services.WardServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DailyReport.Pages.Wards
{
    public class DepartmentWardsModel : PageModel
    {
        ApplicationContext context;
        public List<Ward> wards = new();
        [BindProperty]
        public Patient newPatient { get; set; } = new();
        public List<Patient> patients = new();
        public DepartmentWardsModel(ApplicationContext db)
        {
            context = db;
        }
        public void OnGet(int depNumber)
        {
            wards = WardServices.GetWardsByDepartment(context, depNumber);


            //wards.Add(WardServices.CreateTestWard("1", 3, true, 3, true));
            //wards.Add(WardServices.CreateTestWard("2", 3, true, 3, true));
            //wards.Add(WardServices.CreateTestWard("3", 3, false, 4, true));
            //wards.Add(WardServices.CreateTestWard("4", 3, true, 4, false));

            //patients.Add(PatientServices.CreateTestPatient(1, false, false, false, false));
            //patients.Add(PatientServices.CreateTestPatient(2, false, false, false, false));
            //patients.Add(PatientServices.CreateTestPatient(3, false, false, false, false));
            //patients.Add(PatientServices.CreateTestPatient(4, true, false, false, false));
            //patients.Add(PatientServices.CreateTestPatient(5, false, false, false, false));
            //patients.Add(PatientServices.CreateTestPatient(6, false, false, false, false));
            //patients.Add(PatientServices.CreateTestPatient(7, false, false, true, false));
            //patients.Add(PatientServices.CreateTestPatient(8, false, false, false, false));
            //patients.Add(PatientServices.CreateTestPatient(9, false, false, false, false));
            //patients.Add(PatientServices.CreateTestPatient(10, false, false, false, false));
            //patients.Add(PatientServices.CreateTestPatient(11, false, false, false, false));

            //добавление пациентов в палаты, сохраняем в неотслеживаемое в БД поле
            foreach (Ward ward in wards)
            {
                foreach (Patient patient in patients)
                {
                    if (patient.WardNumber == ward.Number) ward.PatientsInWard.Add(patient);
                }
            }

            //определяем доступность палаты в соответствии со статусом пациента
            foreach (Ward ward in wards)
            {
                foreach (Patient patient in ward.PatientsInWard)
                {
                    if (patient.HasCareRisk || patient.HasRash || patient.IsUntochable) ward.CanPut = false;
                }
            }
        }

        public IActionResult OnPostUpdateWard(Ward ward)
        {
            //TODO - приходит ошибка формы, почему?
            //if (!ModelState.IsValid)
            //{
            //    return RedirectToPage("DepartmentWards", new { depNumber = ward.Department });
            //}
            WardServices.UpdateWard(context, ward);
            return RedirectToPage("DepartmentWards", new { depNumber = ward.Department });
        }

        public IActionResult OnPostAddPatient(Patient patient)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToPage("DepartmentWards", new { depNumber = patient.Department });
            }
            PatientServices.AddPatient(context, patient);

            return RedirectToPage("DepartmentWards", new { depNumber = patient.Department });
        }
    }
}

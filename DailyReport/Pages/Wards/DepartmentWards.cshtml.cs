using DailyReport.Models.WardsModels;
using DailyReport.Services.WardServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DailyReport.Pages.Wards
{
    public class DepartmentWardsModel : PageModel
    {
        public List<Ward> wards = new();
        public List<Patient> patients = new();
        public void OnGet()
        {
            wards.Add(WardServices.CreateTestWard(1, 3, true, 3, false));
            wards.Add(WardServices.CreateTestWard(2, 3, true, 3, false));
            wards.Add(WardServices.CreateTestWard(3, 3, true, 4, false));
            wards.Add(WardServices.CreateTestWard(4, 3, true, 4, true));

            patients.Add(PatientServices.CreateTestPatient(1, false, false, false, false));
            patients.Add(PatientServices.CreateTestPatient(2, false, false, false, false));
            patients.Add(PatientServices.CreateTestPatient(3, false, false, false, false));
            patients.Add(PatientServices.CreateTestPatient(4, true, false, false, false));
            patients.Add(PatientServices.CreateTestPatient(5, false, false, false, false));
            patients.Add(PatientServices.CreateTestPatient(6, false, false, false, false));
            patients.Add(PatientServices.CreateTestPatient(7, false, false, true, false));
            patients.Add(PatientServices.CreateTestPatient(8, false, false, false, false));
            patients.Add(PatientServices.CreateTestPatient(9, false, false, false, false));
            patients.Add(PatientServices.CreateTestPatient(10, false, false, false, false));
            patients.Add(PatientServices.CreateTestPatient(11, false, false, false, false));

            //добавление пациентов в палаты
            foreach(Ward ward in wards)
            {
                foreach (Patient patient in patients)
                {
                    if(patient.WardNumber == ward.Number) ward.PatientsInWard.Add(patient);
                }
            }

            foreach (Ward ward in wards)
            {
                foreach (Patient patient in ward.PatientsInWard)
                {
                    if (patient.HasCareRisk || patient.HasRash || patient.IsUntochable) ward.CanPut = false;
                }
            }
        }
    }
}

using DailyReport.Models;
using DailyReport.Models.WardsModels;
using DailyReport.Services;
using DailyReport.Services.WardServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace DailyReport.Pages.Wards
{
    [IgnoreAntiforgeryToken]
    public class DepartmentWardsModel : PageModel
    {
        ApplicationContext context;
        //[BindProperty]
        public Ward ward { get; set; }
        [BindProperty]
        public List<Ward> wards { get; set; } = new();
        [BindProperty]
        public Patient newPatient { get; set; } = new();
        [BindProperty]
        public List<Patient> patients { get; set; } = new();
        public int departmentNumber;
        public DepartmentWardsModel(ApplicationContext db)
        {
            context = db;
        }
        public void OnGet(int depNumber)
        {
            departmentNumber = depNumber;
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

            patients = PatientServices.GetPatientsByDepartment(context, depNumber);

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

        //public IActionResult OnPostUpdateWard()
        //{
        //    //TODO - приходит ошибка формы, почему?
        //    //if (!ModelState.IsValid)
        //    //{
        //    //    return RedirectToPage("DepartmentWards", new { depNumber = ward.Department });
        //    //}
        //    WardServices.UpdateWard(context, ward);
        //    return RedirectToPage("DepartmentWards", new { depNumber = ward.Department });
        //}



        //public IActionResult OnPostAddPatient()
        //{
        //    //if (!ModelState.IsValid)
        //    //{
        //    //    return RedirectToPage("DepartmentWards", new { depNumber = newPatient.Department });
        //    //}
        //    PatientServices.AddPatient(context, newPatient);
        //    return RedirectToPage("DepartmentWards", new { depNumber = newPatient.Department });
        //}

        //public IActionResult OnPostUpdatePatient(Patient newPatient)
        //{
        //    //if (!ModelState.IsValid)
        //    //{
        //    //    return RedirectToPage("DepartmentWards", new { depNumber = newPatient.Department });
        //    //}
        //    PatientServices.UpdatePatient(context, newPatient);
        //    return RedirectToPage("DepartmentWards", new { depNumber = newPatient.Department });
        //}

        //public IActionResult OnPostDeletePatient()
        //{
        //    //if (!ModelState.IsValid)
        //    //{
        //    //    return RedirectToPage("DepartmentWards", new { depNumber = newPatient.Department });
        //    //}
        //    PatientServices.DeletePatient(context, newPatient.Id);

        //    return RedirectToPage("DepartmentWards", new { depNumber = newPatient.Department });
        //}

        // возврат данных для fetch методов

        /// <summary>
        /// Обновление палаты, метод для fetch вызова 
        /// </summary>
        /// <param name="ward"></param>
        /// <returns></returns>
        public IActionResult OnPostUpdateWard(Ward ward)
        {
            try
            {
                WardServices.UpdateWard(context, ward);
                return new OkResult();
            }
            catch
            {
                return new NotFoundResult();
            }
        }

        /// <summary>
        /// возвращаем список палат по номеру отделения 
        /// </summary>
        /// <param name="depNumber"></param>
        /// <returns></returns>
        public IActionResult OnGetWardsList(int depNumber)
        {
            departmentNumber = depNumber;
            wards = WardServices.GetWardsByDepartment(context, depNumber);

            //добавление пациентов в палаты, сохраняем в неотслеживаемое в БД поле
            foreach (Ward ward in wards)
            {
                foreach (Patient patient in patients)
                {
                    if (patient.WardNumber == ward.Number) ward.PatientsInWard.Add(patient);
                }
            }

            if (wards != null)
            {
                //string ward = JsonConvert.SerializeObject(wards);
                return Content(JsonConvert.SerializeObject(wards));
            }
            else
            {
                return new NotFoundResult();
            }
        }

        /// <summary>
        /// возвращаем список пациентов отделениия
        /// </summary>
        /// <param name="depNumber"></param>
        /// <returns></returns>
        public IActionResult OnGetPatientsList(int depNumber)
        {
            departmentNumber = depNumber;
            patients = PatientServices.GetPatientsByDepartment(context, depNumber);
            if (patients != null)
            {
                //string ward = JsonConvert.SerializeObject(patients);
                return Content(JsonConvert.SerializeObject(patients));
            }
            else
            {
                return new NotFoundResult();
            }
        }

        /// <summary>
        /// Добавляем пациента в БД, возвращаем сохраненного пациента
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        public IActionResult OnPostAddPatient(Patient patient)
        {
            //try
            //{
                PatientServices.AddPatient(context, patient);
                return Content(JsonConvert.SerializeObject(patient));
            //}
            //catch
            //{
                //return new NotFoundResult();
            //}
        }

        /// <summary>
        /// обновляем пациента и возвращаем как json объект, метод для fetch вызова
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        public IActionResult OnPostUpdatePaient(Patient patient)
        {

            patient = PatientServices.UpdatePatient(context, patient);
            if (patient != null)
            {
                //string ward = JsonConvert.SerializeObject(patients);
                return Content(JsonConvert.SerializeObject(patient));
            }
            else
            {
                return new NotFoundResult();
            }
        }


        public IActionResult OnPostDeletePatient(Patient patient)
        {
            try
            {
                if (patient == null || patient.Id == 0) 
                { 
                    return new NotFoundResult();
                }
                PatientServices.DeletePatient(context, patient.Id);
                Patient nPatient = PatientServices.GetPatientById(context, patient.Id);
                if (nPatient != null) { return new NotFoundResult(); }   //проверка удаления
                else
                {
                    return new OkResult();
                }
            }
            catch { return new NotFoundResult(); }
            //return RedirectToPage("DepartmentWards", new { depNumber = newPatient.Department });
        }
    }
}
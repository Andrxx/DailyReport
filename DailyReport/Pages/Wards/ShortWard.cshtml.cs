using DailyReport.Models.WardsModels;
using DailyReport.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DailyReport.Services.WardServices;
using Newtonsoft.Json;

namespace DailyReport.Pages.Wards
{
    public class ShortWardModel : PageModel
    {
        ApplicationContext context;
        public Ward ward { get; set; }
        [BindProperty]
        public List<Ward> wards { get; set; } = new();
        [BindProperty]
        public Patient newPatient { get; set; } = new();
        [BindProperty]
        public List<Patient> patients { get; set; } = new();
        public int departmentAllias;
        public ShortWardModel(ApplicationContext db)
        {
            context = db;
        }
        public void OnGet(int depAllias)
        {
            departmentAllias = depAllias;
            wards = WardServices.GetWardsByDepartment(context, depAllias);

            patients = PatientServices.GetPatientsByDepartment(context, depAllias);

            //добавление пациентов в палаты, сохран€ем в неотслеживаемое в Ѕƒ поле
            foreach (Ward ward in wards)
            {
                foreach (Patient patient in patients)
                {
                    if (patient.WardNumber == ward.Number) ward.PatientsInWard.Add(patient);
                }
            }

            //определ€ем доступность палаты в соответствии со статусом пациента
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

        // возврат данных дл€ fetch методов

        /// <summary>
        /// ќбновление палаты, метод дл€ fetch вызова 
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
        /// возвращаем список палат по номеру отделени€ 
        /// </summary>
        /// <param name="depNumber"></param>
        /// <returns></returns>
        //public IActionResult OnGetWardsList(int depNumber)
        //{
        //    departmentAllias = depNumber;
        //    wards = WardServices.GetWardsByDepartment(context, depNumber);

        //    //добавление пациентов в палаты, сохран€ем в неотслеживаемое в Ѕƒ поле
        //    foreach (Ward ward in wards)
        //    {
        //        foreach (Patient patient in patients)
        //        {
        //            if (patient.WardNumber == ward.Number) ward.PatientsInWard.Add(patient);
        //        }
        //    }

        //    if (wards != null)
        //    {
        //        //string ward = JsonConvert.SerializeObject(wards);
        //        return Content(JsonConvert.SerializeObject(wards));
        //    }
        //    else
        //    {
        //        return new NotFoundResult();
        //    }
        //}
    }
}

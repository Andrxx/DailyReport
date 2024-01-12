using DailyReport.Models.WardsModels;
using DailyReport.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DailyReport.Services.WardServices;
using DailyReport.Services;

namespace DailyReport.Pages.Wards
{
    public class WardsSummaryModel : PageModel
    {
        ApplicationContext context;
        public Ward ward { get; set; }
        public List<Ward> wards { get; set; } = new();
        public Patient newPatient { get; set; } = new();
        public List<Patient> patients { get; set; } = new();
        public List<string> sDepartments { get; set; } = new();
        public List<int> iDepartments { get; set; } = new();
        public List<Department> departments { get; set; } = new();
        public int departmentNumber;

        public WardsSummaryModel(ApplicationContext db)
        {
            context = db;
        }


        public void OnGet()
        {
            //������ �� ���������� � �������

            patients = PatientServices.GetPatients(context);        //�������� ��������� �� �� 
            wards = WardServices.GetWards(context);                 //������� ������ �� ��
            departments = DepartmentServices.GetWDepartments(context);  //�������� ��������� �� ��


            foreach (var department in departments)
            {
                foreach (Ward w in wards)
                {
                    if (w.Department == department.Number)
                    {
                        w.PatientsInWard = patients.FindAll(p => (p.Department == department.Number)&&(p.WardNumber == w.Number));
                        department.Wards.Add(w);
                    }
                }
            }
        }
    }
}

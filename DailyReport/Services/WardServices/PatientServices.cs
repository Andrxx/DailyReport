using System;
using DailyReport.Models;
using DailyReport.Models.WardsModels;

namespace DailyReport.Services.WardServices
{
    public static class PatientServices
    {
        /// <summary>
        /// получаем всех пациентов
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static List<Patient> GetPatients(ApplicationContext context)
        {
            List<Patient> patients = new List<Patient>();
            patients = (from p in context.Patients
                        select p).ToList(); 
            return patients;
        }

        /// <summary>
        /// Получаем пациентов по номеру отделения, сортировка по номеру палаты
        /// </summary>
        /// <param name="context"></param>
        /// <param name="depNumber"></param>
        /// <returns></returns>
        public static List<Patient> GetPatientsByDepartment(ApplicationContext context, int depNumber)
        {
            List<Patient> patients = new List<Patient>();
            patients = (from p in context.Patients
                        where p.Department == depNumber
                        orderby p.WardNumber
                        select p).ToList();
            return patients;
        }

        /// <summary>
        /// Получаем список пацинтов по номеру отделения и палаты
        /// </summary>
        /// <param name="context"></param>
        /// <param name="depNumber"></param>
        /// <param name="wardNumber"></param>
        /// <returns></returns>
        public static List<Patient> GetPatientsByDepartmentAndWard(ApplicationContext context, int depNumber, string wardNumber)
        {
            List<Patient> patients = new List<Patient>();
            patients = (from p in context.Patients
                        where p.Department == depNumber && p.WardNumber == wardNumber
                        select p).ToList();
            return patients;
        }

        /// <summary>
        /// Выбор пациента по ИД
        /// </summary>
        /// <param name="context"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Patient GetPatientById(ApplicationContext context, int id)
        {
            Patient patient = new();
            patient = (from p in context.Patients
                       where p.Id == id
                       select p).FirstOrDefault();
            return patient;
        }
        /// <summary>
        /// Сохраняем пациентаа
        /// </summary>
        /// <param name="context"></param>
        /// <param name="patient"></param>
        public static void AddPatient(ApplicationContext context, Patient patient)
        {
            context.Patients.Add(patient);
            context.SaveChanges();
        }

        /// <summary>
        /// Обновляем пациента
        /// </summary>
        /// <param name="context"></param>
        /// <param name="newPatient"></param>
        public static Patient UpdatePatient(ApplicationContext context, Patient newPatient)
        {
            Patient patient = GetPatientById(context, newPatient.Id);
            if(patient != null)
            {
                patient.HospitalisationDate = newPatient.HospitalisationDate;
                patient.Name = newPatient.Name;
                patient.WardNumber = newPatient.WardNumber;
                patient.Department = newPatient.Department;
                patient.Diagnos = newPatient.Diagnos;
                patient.IsDisodered = newPatient.IsDisodered;
                patient.HasCareRisk = newPatient.HasCareRisk;
                patient.HasRash = newPatient.HasRash;
                patient.IsUntochable = newPatient.IsUntochable;
                patient.Age = newPatient.Age;
                patient.AgeMonts = newPatient.AgeMonts;
                patient.sAge = newPatient.sAge;
                patient.Male = newPatient.Male;
                context.SaveChanges();
                return patient;
            }
            else { return null; }
        }

        /// <summary>
        /// удаляем пациента, метод не подтверждает удаление
        /// </summary>
        /// <param name="context"></param>
        /// <param name="id"></param>
        public static void DeletePatient(ApplicationContext context, int id)
        {
            Patient newPatient = GetPatientById(context, id);
            if (newPatient != null)
            {
                context.Remove(newPatient);
                //context.SaveChanges();
            }
        }

        public static Patient CreateTestPatient(int id, bool untoch, bool rash, bool disodered, bool risk)
        {
            BooleanGenerator booleanGenerator = new BooleanGenerator();
            Random random = new Random();
            Patient patient = new();

            patient.Id = id;
            //patient.WardNumber = random.Next(1, 5);
            patient.Name = "John Doe";
            patient.Male = booleanGenerator.NextBoolean() ? "М" : "Ж";
            patient.Age = random.Next(1, 80);
            patient.AgeMonts = random.Next(1, 12);
            patient.HospitalisationDate = new DateTime();
            patient.Diagnos = "J06.9";
            patient.HasRash = rash;
            patient.IsUntochable = untoch;
            patient.IsDisodered = disodered;
            patient.HasCareRisk = risk;
            return patient;
        }
        public class BooleanGenerator
        {
            Random rnd;
            public BooleanGenerator()
            {
                rnd = new Random();
            }
            public bool NextBoolean()
            {
                return rnd.Next(0, 2) == 1;
            }
        }
    }
}

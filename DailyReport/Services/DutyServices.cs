using DailyReport.Models;
using Microsoft.EntityFrameworkCore;
using DailyReport.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Cryptography;
using System.Composition;

namespace DailyReport.Services
{
    public static class DutyServices
    {
        /// <summary>
        /// Тестовый список для отладки
        /// </summary>
        /// <returns></returns>
        public static List<string> GetDoctorsList()
        {
            List<string> doctors = new List<string>();
            doctors.Add("Вакулина Татьяна Сергеевна");
            doctors.Add("Ковалев Андрей Николаевич");
            doctors.Add("Мурашова Елена ");
            doctors.Add("Чумакова Юлия");
            doctors.Add("Британова Анастасия ");
            doctors.Add("Британов Виталий Сергеевич");
            doctors.Add("Демченко Ростислав");
            doctors.Add("Варнавская Анна Александровна");
            doctors.Add("Матушкина Валерия ");
            doctors.Add("Нурбалина Айлана Маратовна");
            doctors.Add("Водянина Дарья ");
            doctors.Add("Овчаров Юрий Владимирович");
            doctors.Add("Голенковская Юлия ");
            doctors.Add("Моисеева Полина Алексеевна");
            doctors.Add("Козлова Юлия Игоревна");
            doctors.Add("Кравцов ");
            //doctors.Add("");
            //doctors.Add("");
            //doctors.Add("");
            //doctors.Add("");
            //doctors.Add("");
            return doctors;
        }

        /// <summary>
        /// Получаем список врачей из БД, null если пусто
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static List<string> GetDoctorsList(ApplicationContext context)
        {
            List<Personel> personels = new();
            List<string> _doctors = new();
            try
            {
                personels = (from personel in context.Personels
                            where (personel.PersType == "Врач")
                            orderby personel.Name, personel.Name.Substring(0, 1)
                            select personel).ToList();
            }
            catch { }
            foreach(Personel p in personels)
            {
                _doctors.Add(p.Name);
            }
            return _doctors;
        }

        public static void AddDutyDoc(DutyDoc dutyDoc, ApplicationContext context)
        {
            context.DutyDocs.Add(dutyDoc);
            context.SaveChanges();
        }
        public static void DeleteDutyDoc(int id, ApplicationContext context)
        {
            DutyDoc _doc = (from doc in context.DutyDocs
                            where (doc.Id == id)
                            select doc).FirstOrDefault();
            if (_doc != null) context.DutyDocs.Remove(_doc);
            context.SaveChanges();
        }
        public static void UpdateDutyDoc(DutyDoc doc, ApplicationContext context)
        {
            DutyDoc _doc = (from d in context.DutyDocs
                            where (d.Id == doc.Id)
                            select d).FirstOrDefault();
            if (_doc != null)
            {
                _doc.dutyDoc = doc.dutyDoc;
                _doc.type = doc.type;
                _doc.departments = doc.departments;
                context.SaveChanges();
            }   
        }

        /// <summary>
        /// Получаем список медсестер из БД персонала
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static List<Personel> GetNursesList(ApplicationContext context)
        {
            List<Personel> nurses = new();
            try
            {
                nurses = (from personel in context.Personels
                          where (personel.PersType == "Медсестра")
                          orderby personel.Name, personel.Name.Substring(0, 1)
                          select personel).ToList();
            }
            catch { }
            return nurses;
        }
        /// <summary>
        /// Получаем список дежурных медсестер с текущей датой
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static List<DutyNurse> GetDutyNurses(ApplicationContext context)
        {
            DateTime actualDate = DateTime.Now;
            DateTime startTime = new DateTime(actualDate.Year, actualDate.Month, actualDate.Day, 8, 0, 0);
            DateTime endTime = new DateTime(actualDate.Year, actualDate.Month, actualDate.Day, 7, 59, 59).AddDays(1);
            if (actualDate.Hour < 8)
            {
                startTime = startTime.AddDays(-1);
                endTime = endTime.AddDays(-1);
            }
            List<DutyNurse> nurses = new();
            try
            {
                nurses = (from n in context.DutyNurses
                          where ((n.dutyDate > startTime) && (n.dutyDate < endTime))
                          select n).ToList();
            }
            catch { }
            return nurses;
        }
        /// <summary>
        /// получаем список дежурных медсестер заданного отделения
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static List<DutyNurse> GetDutyNurses(int depNmber, ApplicationContext context)
        {
            DateTime actualDate = DateTime.Now;
            DateTime startTime = new DateTime(actualDate.Year, actualDate.Month, actualDate.Day, 8, 0, 0);
            DateTime endTime = new DateTime(actualDate.Year, actualDate.Month, actualDate.Day, 7, 59, 59).AddDays(1);
            if (actualDate.Hour < 8)
            {
                startTime = startTime.AddDays(-1);
                endTime = endTime.AddDays(-1);
            }
            List<DutyNurse> nurses = new();
            try
            {
                nurses = (from n in context.DutyNurses
                          where (n.department == depNmber) && ((n.dutyDate > startTime) && (n.dutyDate < endTime))
                          select n).ToList();
            }
            catch { }
            return nurses;
        }
       

        public static void AddDutyNurse(DutyNurse nurse, ApplicationContext context)
        {
            context.DutyNurses.Add(nurse);
            context.SaveChanges();
        }
        public static void DeleteDutyNurse(int id, ApplicationContext context)
        {
            DutyNurse _nurse = (from nurse in context.DutyNurses
                            where (nurse.Id == id)
                            select nurse).FirstOrDefault();
            if (_nurse != null) context.DutyNurses.Remove(_nurse);
            context.SaveChanges();
        }
        public static void UpdateDutyNurse(DutyNurse nurse, ApplicationContext context)
        {
            DutyNurse _nurse = (from d in context.DutyNurses
                              where (d.Id == nurse.Id)
                            select d).FirstOrDefault();
            if (_nurse != null)
            {
                _nurse.name = nurse.name;
                _nurse.department = nurse.department;
                _nurse.Phone = nurse.Phone;
                context.SaveChanges();
            }
        }
    }
}

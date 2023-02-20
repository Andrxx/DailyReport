using DailyReport.Models;
using Microsoft.EntityFrameworkCore;
using DailyReport.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Cryptography;

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
        /// Получаем список персонала из БД, null если пусто
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

        //static List<DutyDoc> ConvertPersToDoc(List<Personel> personels) 
        //{ 

        //    List<DutyDoc> docs = new List<DutyDoc>();
        //    return docs;
        //}
    }
}

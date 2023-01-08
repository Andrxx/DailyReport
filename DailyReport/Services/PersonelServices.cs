using DailyReport.Models;
using Microsoft.Build.Evaluation;
using System.Numerics;

namespace DailyReport.Services
{
    public static class PersonelServices
    {
        public static List<string> GetPType()
        {
            List<string> PType = new();
            PType.Add("Врач");
            PType.Add("Медсестра");
            PType.Add("Оператор ПК");
            PType.Add("Санитар");
            return PType;
        }
        public static void AddPersonel(Personel personel, ApplicationContext context)
        {
            context.Personels.Add(personel);
            context.SaveChanges();
        }

        public static void DeletePersonel(int id, ApplicationContext context)
        {
            Personel personel = (from p in context.Personels
                                        where (p.Id == id)
                                        select p).FirstOrDefault();
            if (personel != null) context.Personels.Remove(personel);
            context.SaveChanges();
        }

        public static void UpdatePersonel(Personel personel, ApplicationContext context)
        {
            Personel _personel = (from p in context.Personels
                                         where (p.Id == personel.Id)
                                         select p).FirstOrDefault();
            if (_personel != null)
            {
                _personel.Name = personel.Name;
                _personel.PersType = personel.PersType;
                _personel.Phone = personel.Phone;
                _personel.Department = personel.Department;
                context.SaveChanges();
            }
        }
    }
}

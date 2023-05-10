using DailyReport.Models;
using DailyReport.Models.WardsModels;
using static DailyReport.Services.WardServices.PatientServices;

namespace DailyReport.Services.WardServices
{
    public static class WardServices
    {
        public static Ward CreateTestWard(string number, int dep, bool can, int capacity, bool dirty)
        {
            BooleanGenerator booleanGenerator = new BooleanGenerator();
            Random random = new Random();
            Ward ward = new();
            ward.Number = number;
            ward.Department = dep;
            ward.CanPut = can;
            ward.Capacity = capacity;
            ward.IsDirtyZone = dirty;
            
            return ward;
        }

        /// <summary>
        /// получаем список всех палат
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static List<Ward> GetWards(ApplicationContext context)
        {
            List<Ward> wards = new List<Ward>();
            wards = (from ward in context.Wards
                     select ward).ToList();
            return wards;
        }

        /// <summary>
        /// получаем палаты для заданного отделения и сортируем по имени палаты
        /// </summary>
        /// <param name="context"></param>
        /// <param name="depNumber"></param>
        /// <returns></returns>
        public static List<Ward> GetWardsByDepartment(ApplicationContext context, int depNumber)
        {
            List<Ward> wards = new List<Ward>();
            wards = (from ward in context.Wards
                     where ward.Department == depNumber
                     orderby ward.Number, ward.Number.Substring(0, 1)
                     select ward).ToList();
            return wards;
        }
        /// <summary>
        /// получаем палату по ид
        /// </summary>
        /// <param name="context"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Ward GetWardById(ApplicationContext context, int id)
        {
            Ward ward = new Ward();
            ward = (from w in context.Wards
                     where w.Id == id
                     select w).FirstOrDefault();
            return ward;
        }

        public static void AddWard(ApplicationContext context, Ward ward)
        {
            context.Wards.Add(ward);
            context.SaveChanges();
        }

        public static void UpdateWard(ApplicationContext context, Ward ward)
        {
            Ward newWard = GetWardById(context, ward.Id);
            if(newWard != null){
                newWard.Capacity = ward.Capacity;
                newWard.IsDirtyZone = ward.IsDirtyZone;
                newWard.CanPut = ward.CanPut;
                newWard.Number = ward.Number;
                context.SaveChanges();
            }
        }

        public static void DeleteWard(ApplicationContext context, int id)
        {

            Ward ward = GetWardById(context, id);
            if (ward != null)
            {
                context.Wards.Remove(ward);
                context.SaveChanges();
            }
        }
    }
}

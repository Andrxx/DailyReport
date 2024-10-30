using DailyReport.Models;
using DailyReport.Models.Reports;
using Microsoft.EntityFrameworkCore;

namespace DailyReport.Services.Reports
{
    public static class LineTypesServices
    {
        public static List<LineType> GetHardcodedTypes()
        {
            List<LineType> types = new List<LineType>();

            types.Add(new LineType() { Id = 1, Name = "Кислород", Order = 1 });
            types.Add(new LineType() { Id = 2, Name = "Социальный раздел", Order = 2 });
            types.Add(new LineType() { Id = 3, Name = "Нозолгии", Order = 3 });

            return types;
        }


        public static void AddType(LineType lineType, ApplicationContext context)
        {
            //context.LineTypes.Add(lineType);
            //context.SaveChanges();
        }

        public static void DeleteType(int id, ApplicationContext context)
        {
            //LineType? type = (from t in context.LineTypes
            //                  where t.Id == id
            //                    select t).FirstOrDefault();
            //if (type != null) context.LineTypes.Remove(type);
            //context.SaveChanges();
        }

        public static void UpdateType(LineType lineType, ApplicationContext context)
        {
            //LineType? type = (from l in context.LineTypes
            //                   where l.Id == lineType.Id
            //                     select l).AsNoTracking().FirstOrDefault();
            //if (type != null)
            //{
            //    context.LineTypes.Update(lineType);
            //    context.SaveChanges();
            //}
        }

        /// <summary>
        /// Получаес список типов строк, сортированный по порядку
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        //public static List<LineType> GetOrderedTypes(ApplicationContext context)
        //{
        //    List<LineType> types = (from t in context.LineTypes
        //                              orderby t.Order
        //                              select t).ToList();
        //    return types;
        //}

    }
}
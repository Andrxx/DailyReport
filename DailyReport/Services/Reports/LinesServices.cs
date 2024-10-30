using DailyReport.Models;
using DailyReport.Models.Reports;
using Microsoft.EntityFrameworkCore;

namespace DailyReport.Services.Reports
{
    public static class LinesServices
    {
        public static void AddLine(LineEntity lineEntity, ApplicationContext context)
        {
            //context.Lines.Add(lineEntity);
            //context.SaveChanges();
        }

        public static void DeleteLine(int id, ApplicationContext context)
        {
            //LineEntity? line = (from l in context.Lines
            //                    where l.Id == id
            //                    select l).FirstOrDefault();
            //if (line != null) context.Lines.Remove(line);
            //context.SaveChanges();
        }

        /// <summary>
        /// Редактируем строку
        /// </summary>
        /// <param name="lineEntity"></param>
        /// <param name="context"></param>
        public static void UpdateLine(LineEntity lineEntity, ApplicationContext context)
        {
            //LineEntity? _line = (from l in context.Lines
            //                     where l.Id == lineEntity.Id
            //                     select l).AsNoTracking().FirstOrDefault();
            //if (_line != null)
            //{
            //    context.Lines.Update(lineEntity);
            //    context.SaveChanges();
            //}
        }

        /// <summary>
        /// Возвращает все строки из БД, без сортировки
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        //public static List<LineEntity> GetLines(ApplicationContext context)
        //{

        //    //List<LineEntity> lines = (from l in context.Lines
        //    //                          orderby l.EntityType, l.Order                             
        //    //                          select l).ToList();
        //    //return lines;
        //}

        /// <summary>
        /// Возвращает список строк сортированый по типам, потом по порядку строк, не работает при отсутствии типов
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        //public static List<LineEntity> GetOrderedLines(ApplicationContext context)
        //{
        //    //List<LineEntity> lines = (from l in context.Lines
        //    //                          join t in context.LineTypes on l.EntityType equals t.Name
        //    //                          orderby t.Order, l.Order
        //    //                          select l).ToList();
        //    //return lines;
        //}
    }
}
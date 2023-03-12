using DailyReport.Models;

namespace DailyReport.Services
{
    public static class DepartmentServices
    {
        public static void AddDepartment(Department department, ApplicationContext context)
        {
            context.Departments.Add(department);
            context.SaveChanges();
        }

        public static void DeleteDepartment(int id, ApplicationContext context)
        {
            Department department = (from d in context.Departments
                                 where (d.Id == id)
                                 select d).FirstOrDefault();
            if (department != null) context.Departments.Remove(department);
            context.SaveChanges();
        }

        public static void UpdateDepartment(Department department, ApplicationContext context)
        {
            Department _department = (from d in context.Departments
                                  where (d.Id == department.Id)
                                  select d).FirstOrDefault();
            if (_department != null)
            {
                _department.Number = department.Number;
                _department.WardQuantity = department.WardQuantity;
                _department.AdultSpotsQuantity = department.AdultSpotsQuantity;
                _department.ChildrenSpotsQuantity = department.ChildrenSpotsQuantity;
                context.SaveChanges();
            }
        }

        //public static List<string> GetDepNumber(ApplicationContext context)
        //{
        //    List<string> depNumbers = new List<string>();

        //}

    }
}

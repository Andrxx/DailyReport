using DailyReport.Models;
using DailyReport.Models.DTO;

namespace DailyReport.Services
{
    public static class DepSpotsService
    {
        /// <summary>
        /// Считаем места для взрослых и детей в стационаре по списку полных отчетов. Не уточняется ДС и ОРИТ
        /// </summary>
        /// <param name="FRdepartments"></param>
        /// <returns></returns>
        public static HospitalSpots GetHospitalSpots (List<FullReportData> FRdepartments)
        {
            HospitalSpots hospitalSpots = new HospitalSpots ();
            foreach (FullReportData repData in FRdepartments) 
            {
                if (repData.CountSpots)
                {
                    hospitalSpots.Adult += repData.Department.AdultSpotsQuantity;
                    hospitalSpots.Children += repData.Department.ChildrenSpotsQuantity;
                }
            }


            return hospitalSpots;
        }


        /// <summary>
        /// Считает все взрослые места во всех отделениях с учетом списка коррекции 
        /// </summary>
        /// <param name="departments"></param>
        /// <returns></returns>
        public static int GetFullAdultSpots(List<Department> departments, List<int> correction) 
        {
            int sum = 0;
            if (departments == null) return 0; 
            foreach(Department dep in departments)
            {
                sum += dep.AdultSpotsQuantity;
            }

            try
            {
                foreach (int i in correction)
                {
                    sum -= departments.Find(d => d.Allias == i).AdultSpotsQuantity;
                }
            }
            catch { }
            return sum;
        }
        /// <summary>
        /// Считает все детские места во всех отделениях с учетом списка коррекции 
        /// </summary>
        /// <param name="departments"></param>
        /// <returns></returns>
        public static int GetFullChildrenSpots(List<Department> departments, List<int> correction)
        {
            int sum = 0;
            if (departments == null) return 0;
            foreach (Department dep in departments)
            {
                sum += dep.ChildrenSpotsQuantity;
            }
            try
            {
                foreach (int i in correction)
                {
                    sum -= departments.Find(d => d.Allias == i).ChildrenSpotsQuantity;
                }
            }
            catch { }
            return sum;
        }

        /// <summary>
        /// Считает все взрослые места во всех отделениях
        /// </summary>
        /// <param name="departments"></param>
        /// <returns></returns>
        public static int GetFullAdultSpots(List<Department> departments)
        {
            int sum = 0;
            if (departments == null) return 0;
            foreach (Department dep in departments)
            {
                sum += dep.AdultSpotsQuantity;
            }
            return sum;
        }

        /// <summary>
        /// Считает все детские места во всех отделениях 
        /// </summary>
        /// <param name="departments"></param>
        /// <returns></returns>
        public static int GetFullChildrenSpots(List<Department> departments)
        {
            int sum = 0;
            if (departments == null) return 0;
            foreach (Department dep in departments)
            {
                sum += dep.ChildrenSpotsQuantity;
            }
            return sum;
        }


        /// <summary>
        /// Считает взрослые места по отделениям, за исключением отделений из списка исключения
        /// </summary>
        /// <param name="departments"></param>
        /// <param name="excludedDeps"></param>
        /// <returns></returns>
        public static int GetAdultSpots(List<Department> departments, List<int> excludedDeps)
        {
            int sum = 0;
            if (departments == null) return 0;

            foreach (Department department in departments)
            {
                if (department.Allias != excludedDeps.Find(i => i == department.Allias))
                {
                    sum += department.AdultSpotsQuantity;
                }
            }

            return sum;
        }
        /// <summary>
        /// Считает детские места по отделениям, за исключением отделений из списка исключения
        /// </summary>
        /// <param name="departments"></param>
        /// <param name="excludedDeps"></param>
        /// <returns></returns>
        public static int GetChildrenSpots(List<Department> departments, List<int> excludedDeps)
        {
            int sum = 0;
            if (departments == null) return 0;

            foreach (Department department in departments)
            {
                if (department.Allias != excludedDeps.Find(i => i == department.Allias))
                {
                    sum += department.ChildrenSpotsQuantity;
                }
            }
            return sum;
        }
        /// <summary>
        /// Считает взрослые места по отделениям используя FullReportData
        /// </summary>
        /// <param name="FRdepartments"></param>
        /// <returns></returns>
        public static int GetAdultSpots(List<FullReportData> FRdepartments)
        {
            int sum = 0;
            if (FRdepartments == null) return 0;

            foreach (FullReportData frd in FRdepartments)
            {
                if (frd.CountSpots)
                {
                    try
                    {
                        sum += frd.Department.AdultSpotsQuantity;
                    }
                    catch { sum += 0; }
                }
            }

            return sum;
        }


        /// <summary>
        /// legacy
        /// </summary>

        static DepartmentSpots departmentSpots;
       
        /// <summary>
        /// получаем список мест из БД
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        static DepartmentSpots ReadSpots(ApplicationContext context)
        {
            DepartmentSpots _departmentSpots = new DepartmentSpots();
            List<Department> departments = (from dep in context.Departments
                                          select dep).ToList();
            try
            {
                //подсчет мест чистой зоны 1 отд
                _departmentSpots.dep1 = departments.Find(p => p.Allias == 1).AdultSpotsQuantity;
                _departmentSpots.dep1Children = departments.Find(p => p.Allias == 1).ChildrenSpotsQuantity;
            }
            catch
            {
                _departmentSpots.dep1 = 0;
                _departmentSpots.dep1Children = 0;
            }
            try
            {
                _departmentSpots.dep11 = departments.Find(p => p.Allias == 11).AdultSpotsQuantity;
                _departmentSpots.dep11Children = departments.Find(p => p.Allias == 11).ChildrenSpotsQuantity;
            }
            catch
            {
                _departmentSpots.dep11 = 0;
                _departmentSpots.dep11Children = 0;
            }
            //try
            //{
            //    _departmentSpots.dep2 = departments.Find(p => p.Allias == 2).AdultSpotsQuantity;
            //    _departmentSpots.dep2Children = departments.Find(p => p.Allias == 2).ChildrenSpotsQuantity;
            //}
            //catch
            //{
            //    _departmentSpots.dep2 = 0;
            //    _departmentSpots.dep2Children = 0;
            //}
            try
            {
                _departmentSpots.dep3 = departments.Find(p => p.Allias == 3).AdultSpotsQuantity;
                _departmentSpots.dep3Children = departments.Find(p => p.Allias == 3).ChildrenSpotsQuantity;
            }
            catch
            {
                _departmentSpots.dep3 = 0;
                _departmentSpots.dep3Children = 0;
            }
            //try
            //{
            //    _departmentSpots.dep31 = departments.Find(p => p.Allias == 31).AdultSpotsQuantity;
            //    _departmentSpots.dep31Children = departments.Find(p => p.Allias == 31).ChildrenSpotsQuantity;
            //}
            //catch
            //{
            //    _departmentSpots.dep31 = 0;
            //    _departmentSpots.dep31Children = 0;
            //}
            try
            {
                _departmentSpots.dep4 = departments.Find(p => p.Allias == 4).AdultSpotsQuantity;
                _departmentSpots.dep4Children = departments.Find(p => p.Allias == 4).ChildrenSpotsQuantity;
            }
            catch
            {
                _departmentSpots.dep4 = 0;
                _departmentSpots.dep4Children = 0;
            }
            try
            {
                _departmentSpots.dep5 = departments.Find(p => p.Allias == 5).AdultSpotsQuantity;
                _departmentSpots.dep5Children = departments.Find(p => p.Allias == 5).ChildrenSpotsQuantity;
            }
            catch
            {
                _departmentSpots.dep5 = 0;
                _departmentSpots.dep5Children = 0;
            }
            //try
            //{
            //    //грязная зона 5 отд
            //    _departmentSpots.dep51 = departments.Find(p => p.Allias == 51).AdultSpotsQuantity;
            //    _departmentSpots.dep51Children = departments.Find(p => p.Allias == 51).ChildrenSpotsQuantity;
            //}
            //catch
            //{
            //    _departmentSpots.dep51 = 0;
            //    _departmentSpots.dep51Children = 0;
            //}
            try
            {
                _departmentSpots.dep6 = departments.Find(p => p.Allias == 6).AdultSpotsQuantity;
                _departmentSpots.dep6Children = departments.Find(p => p.Allias == 6).ChildrenSpotsQuantity;
            }
            catch
            {
                _departmentSpots.dep6 = 0;
                _departmentSpots.dep6Children = 0;
            }
            //try
            //{
            //    _departmentSpots.dep61 = departments.Find(p => p.Allias == 61).AdultSpotsQuantity;
            //    _departmentSpots.dep61Children = departments.Find(p => p.Allias == 61).ChildrenSpotsQuantity;
            //}
            //catch
            //{
            //    _departmentSpots.dep61 = 0;
            //    _departmentSpots.dep61Children = 0;
            //}
            try
            {
                _departmentSpots.dep7 = departments.Find(p => p.Allias == 7).AdultSpotsQuantity;
                _departmentSpots.dep7Children = departments.Find(p => p.Allias == 7).ChildrenSpotsQuantity;
            }
            catch
            {
                _departmentSpots.dep7 = 0;
                _departmentSpots.dep7Children = 0;
            }
            //try
            //{
            //    _departmentSpots.dep71 = departments.Find(p => p.Allias == 71).AdultSpotsQuantity;
            //    _departmentSpots.dep71Children = departments.Find(p => p.Allias == 71).ChildrenSpotsQuantity;
            //}
            //catch
            //{
            //    _departmentSpots.dep71 = 0;
            //    _departmentSpots.dep71Children = 0;
            //}
            try
            {
                _departmentSpots.dep8 = departments.Find(p => p.Allias == 8).AdultSpotsQuantity;
                _departmentSpots.dep8Children = departments.Find(p => p.Allias == 8).ChildrenSpotsQuantity;
            }
            catch
            {
                _departmentSpots.dep8 = 0;
                _departmentSpots.dep8Children = 0;
            }
            try
            {
                _departmentSpots.dep90 = departments.Find(p => p.Allias == 90).AdultSpotsQuantity;
                _departmentSpots.dep90Children = departments.Find(p => p.Allias == 90).ChildrenSpotsQuantity;
            }
            catch
            {
                _departmentSpots.dep90 = 0;
                _departmentSpots.dep90Children = 0;
            }
            try
            {
                _departmentSpots.dep91 = departments.Find(p => p.Allias == 91).AdultSpotsQuantity;
                _departmentSpots.dep91Children = departments.Find(p => p.Allias == 91).ChildrenSpotsQuantity;
            }
            catch
            {
                _departmentSpots.dep91 = 0;
                _departmentSpots.dep91Children = 0;
            }

            return _departmentSpots;
        }

        /// <summary>
        /// Подсчет суммы взрослых мест. Считать после инициализации остальных полей.
        /// </summary>
        /// <returns></returns>
        public static int CountSum()
        {
            int sum = departmentSpots.dep1 + departmentSpots.dep11 + departmentSpots.dep3 /*+ departmentSpots.dep31*/ + departmentSpots.dep4 + 
                departmentSpots.dep5 + departmentSpots.dep51 + departmentSpots.dep6 /*+ departmentSpots.dep61*/ + departmentSpots.dep7 
                /* +departmentSpots.dep71*/ /*+ departmentSpots.dep91 + departmentSpots.dep90*/;

            return sum;
        }

        /// <summary>
        /// Подсчет суммы детских мест. Считать после инициализации остальных полей.
        /// </summary>
        /// <returns></returns>
        public static int CountSumChildren()
        {
            int sum = departmentSpots.dep1Children + departmentSpots.dep11Children + departmentSpots.dep3Children /*+ departmentSpots.dep31Children*/ + 
                departmentSpots.dep4Children + departmentSpots.dep5Children + departmentSpots.dep51Children + departmentSpots.dep6Children 
                 /*+ departmentSpots.dep61Children*/ + departmentSpots.dep7Children  /*departmentSpots.dep71Children*/ /*+ departmentSpots.dep90Children + departmentSpots.dep91Children*/;

            return sum;
        }

        /// <summary>
        /// места вместе с дневным стационаром
        /// </summary>
        /// <returns></returns>
        internal static int CountSumOC()
        {
            int sum = CountSum() + departmentSpots.dep8;
            return sum;
        }

        /// <summary>
        /// места вместе с дневным стационаром
        /// </summary>
        /// <returns></returns>
        public static int CountSumOCChildren()
        {
            int sum = CountSumChildren() + departmentSpots.dep8Children;
            return sum;
        }
        
        /// <summary>
        /// получаем места после иницилизации в конструкторе - хардкодный метод, для тестов
        /// </summary>
        /// <returns></returns>
        public static DepartmentSpots GetSpots()
        {
            return departmentSpots;
        }

        /// <summary>
        /// получаем места из БД после иницилизации в конструкторе
        /// </summary>
        /// <returns></returns>
        public static DepartmentSpots GetSpots(ApplicationContext context)
        {
            departmentSpots = ReadSpots(context);
            return departmentSpots;
        }


        /// <summary>
        /// Возвращет список коек отделений. Порядок списка должен соответствовть порядку отделений в сводке, захрдкоженый тестовый метод
        /// </summary>
        /// <returns></returns>
        static DepartmentSpots CreateSpots()
        {
            DepartmentSpots _departmentSpots = new();
            _departmentSpots.dep1 = 11;
            _departmentSpots.dep1Children = 11;
            _departmentSpots.dep11 = 16;
            _departmentSpots.dep11Children = 2;
            //_departmentSpots.dep2 = 15;   второе отделение не работает
            //_departmentSpots.dep2Children = 5;
            _departmentSpots.dep3 = 1;
            _departmentSpots.dep3Children = 39;
            _departmentSpots.dep4 = 28;
            _departmentSpots.dep4Children = 2;
            _departmentSpots.dep5 = 1;
            _departmentSpots.dep5Children = 54;
            _departmentSpots.dep6 = 30;
            _departmentSpots.dep6Children = 20;
            _departmentSpots.dep7 = 36;
            _departmentSpots.dep7Children = 9;
            _departmentSpots.dep8 = 24;
            _departmentSpots.dep8Children = 1;
            _departmentSpots.dep91 = 6;
            _departmentSpots.dep91Children = 1;
            _departmentSpots.dep90 = 9;
            _departmentSpots.dep90Children = 4;


            return _departmentSpots;
        }

    }
}

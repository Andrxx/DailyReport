using DailyReport.Models;

namespace DailyReport.Services
{
    public static class DepSpotsService
    {
        static DepartmentSpots departmentSpots;

        //static DepSpotsService()
        //{
        //    departmentSpots = ReadSpots(context);
        //}

        /// <summary>
        /// Возвращет список коек отделений. Порядок списка должен соответствовть порядку отделений в сводке
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
                _departmentSpots.dep1 = departments.Find(p => p.Number == 1).AdultSpotsQuantity;
                _departmentSpots.dep1Children = departments.Find(p => p.Number == 1).ChildrenSpotsQuantity;
            }
            catch
            {
                _departmentSpots.dep1 = 0;
                _departmentSpots.dep1Children = 0;
            }
            try
            {
                _departmentSpots.dep11 = departments.Find(p => p.Number == 11).AdultSpotsQuantity;
                _departmentSpots.dep11Children = departments.Find(p => p.Number == 11).ChildrenSpotsQuantity;
            }
            catch
            {
                _departmentSpots.dep11 = 0;
                _departmentSpots.dep11Children = 0;
            }
            //try
            //{
            //    _departmentSpots.dep2 = departments.Find(p => p.Number == 2).AdultSpotsQuantity;
            //    _departmentSpots.dep2Children = departments.Find(p => p.Number == 2).ChildrenSpotsQuantity;
            //}
            //catch
            //{
            //    _departmentSpots.dep2 = 0;
            //    _departmentSpots.dep2Children = 0;
            //}
            try
            {
                _departmentSpots.dep3 = departments.Find(p => p.Number == 3).AdultSpotsQuantity;
                _departmentSpots.dep3Children = departments.Find(p => p.Number == 3).ChildrenSpotsQuantity;
            }
            catch
            {
                _departmentSpots.dep3 = 0;
                _departmentSpots.dep3Children = 0;
            }
            try
            {
                _departmentSpots.dep4 = departments.Find(p => p.Number == 4).AdultSpotsQuantity;
                _departmentSpots.dep4Children = departments.Find(p => p.Number == 4).ChildrenSpotsQuantity;
            }
            catch
            {
                _departmentSpots.dep4 = 0;
                _departmentSpots.dep4Children = 0;
            }
            try
            {
                _departmentSpots.dep5 = departments.Find(p => p.Number == 5).AdultSpotsQuantity;
                _departmentSpots.dep5Children = departments.Find(p => p.Number == 5).ChildrenSpotsQuantity;
            }
            catch
            {
                _departmentSpots.dep5 = 0;
                _departmentSpots.dep5Children = 0;
            }
            try
            {
                _departmentSpots.dep6 = departments.Find(p => p.Number == 6).AdultSpotsQuantity;
                _departmentSpots.dep6Children = departments.Find(p => p.Number == 6).ChildrenSpotsQuantity;
            }
            catch
            {
                _departmentSpots.dep6 = 0;
                _departmentSpots.dep6Children = 0;
            }
            try
            {
                _departmentSpots.dep7 = departments.Find(p => p.Number == 7).AdultSpotsQuantity;
                _departmentSpots.dep7Children = departments.Find(p => p.Number == 7).ChildrenSpotsQuantity;
            }
            catch
            {
                _departmentSpots.dep7 = 0;
                _departmentSpots.dep7Children = 0;
            }
            try
            {
                _departmentSpots.dep8 = departments.Find(p => p.Number == 8).AdultSpotsQuantity;
                _departmentSpots.dep8Children = departments.Find(p => p.Number == 8).ChildrenSpotsQuantity;
            }
            catch
            {
                _departmentSpots.dep8 = 0;
                _departmentSpots.dep8Children = 0;
            }
            try
            {
                _departmentSpots.dep90 = departments.Find(p => p.Number == 90).AdultSpotsQuantity;
                _departmentSpots.dep90Children = departments.Find(p => p.Number == 90).ChildrenSpotsQuantity;
            }
            catch
            {
                _departmentSpots.dep90 = 0;
                _departmentSpots.dep90Children = 0;
            }
            try
            {
                _departmentSpots.dep91 = departments.Find(p => p.Number == 91).AdultSpotsQuantity;
                _departmentSpots.dep91Children = departments.Find(p => p.Number == 91).ChildrenSpotsQuantity;
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
            int sum = departmentSpots.dep1 + departmentSpots.dep11 + departmentSpots.dep3 + departmentSpots.dep4 + departmentSpots.dep5 +
                departmentSpots.dep6 + departmentSpots.dep7 + departmentSpots.dep91 + departmentSpots.dep90;

            return sum;
        }

        /// <summary>
        /// Подсчет суммы детских мест. Считать после инициализации остальных полей.
        /// </summary>
        /// <returns></returns>
        public static int CountSumChildren()
        {
            int sum = departmentSpots.dep1Children + departmentSpots.dep11Children + departmentSpots.dep3Children + departmentSpots.dep4Children + departmentSpots.dep5Children + 
                departmentSpots.dep6Children + departmentSpots.dep7Children + departmentSpots.dep90Children + departmentSpots.dep91Children;

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

    }
}

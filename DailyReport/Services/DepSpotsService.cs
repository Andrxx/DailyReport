

using DailyReport.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace DailyReport.Services
{
    public static class DepSpotsService
    {
        static DepartmentSpots departmentSpots;


        static DepSpotsService()
        {
            departmentSpots = CreateSpots();

        }
        /// <summary>
        /// Возвращет список коек отделений. Порядок списка должен соответствовть порядку отделений в сводке
        /// </summary>
        /// <returns></returns>
        static DepartmentSpots CreateSpots()
        {
            DepartmentSpots _departmentSpots = new();
            _departmentSpots.dep1 = 11;
            _departmentSpots.dep1Children = 11;
            _departmentSpots.dep11 = 15;
            _departmentSpots.dep11Children = 3;
            //_departmentSpots.dep2 = 15;   второе отделение не работает
            //_departmentSpots.dep2Children = 5;
            _departmentSpots.dep3 = 1;
            _departmentSpots.dep3Children = 39;
            _departmentSpots.dep4 = 38;
            _departmentSpots.dep4Children = 2;
            _departmentSpots.dep5 = 1;
            _departmentSpots.dep5Children = 54;
            _departmentSpots.dep6 = 43;
            _departmentSpots.dep6Children = 12;
            _departmentSpots.dep7 = 37;
            _departmentSpots.dep7Children = 8;
            _departmentSpots.dep8 = 7;
            _departmentSpots.dep8Children = 3;
            _departmentSpots.dep91 = 1;
            _departmentSpots.dep91Children = 1;
            _departmentSpots.dep90 = 9;
            _departmentSpots.dep90Children = 9;
            

            return _departmentSpots;
        }

        /// <summary>
        /// Подсчет суммы взрослых мест. Считать после инициализации остальных полей. По текущей политике вся грязная ОРИТ идет во взрослое
        /// </summary>
        /// <returns></returns>
        public static int CountSum()
        {
            int sum = departmentSpots.dep1 + departmentSpots.dep11 + departmentSpots.dep3 + departmentSpots.dep4 + departmentSpots.dep5 +
                departmentSpots.dep6 + departmentSpots.dep7 +  departmentSpots.dep91 + departmentSpots.dep91Children;

            return sum;
        }

        /// <summary>
        /// Подсчет суммы детских мест. Считать после инициализации остальных полей. По текущей политике вся чистая ОРИТ идет в детское
        /// </summary>
        /// <returns></returns>
        public static int CountSumChildren()
        {
            int sum = departmentSpots.dep1Children + departmentSpots.dep11Children + departmentSpots.dep3Children + departmentSpots.dep4Children + departmentSpots.dep5Children + 
                departmentSpots.dep6Children + departmentSpots.dep7Children + departmentSpots.dep90 + departmentSpots.dep90Children ;

            return sum;
        }

        //места вместе с дневным стационаром
        internal static int CountSumOC()
        {
            int sum = CountSum() + departmentSpots.dep8;
            return sum;
        }

        public static int CountSumOCChildren()
        {
            int sum = CountSumChildren() + departmentSpots.dep8Children;
            return sum;
        }
        
        /// <summary>
        /// получаем места после иницилизации в конструкторе
        /// </summary>
        /// <returns></returns>
        public static DepartmentSpots GetSpots()
        {
            return departmentSpots;
        }

        
    }
}

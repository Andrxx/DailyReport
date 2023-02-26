namespace DailyReport.Services
{
    public static class DepartmentServices
    {
        public static List<string> Get()
        {
            List<string> PType = new();
            PType.Add("Врач");
            PType.Add("Медсестра");
            PType.Add("Оператор ПК");
            PType.Add("Санитар");
            return PType;
        }

        //public static Enum DepNumbers { get; }
        //{
        //    first = 0
        //    "Первое" = 1
        //}
    }
}

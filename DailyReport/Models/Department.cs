namespace DailyReport.Models
{
    public class Department
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int WardQuantity { get; set; }
        public int AdultSpotsQuantity { get; set; }
        public int ChildrenSpotsQuantity { get; set; }

        public string ToDepName()
        {
            string name;
            switch (Number)
            {
                case 1:
                    {
                        name = "Первое отделение";
                        return name;
                    }
                case 11:
                    {
                        name = "Первое отделение грязная зона";
                        return name;
                    }
                case 2:
                    {
                        name = "Второе отделение";
                        return name;
                    }
                case 3:
                    {
                        name = "Третье отделение";
                        return name;
                    }
                case 4:
                    {
                        name = "Четвертое отделение";
                        return name;

                    }
                case 5:
                    {
                        name = "Пятое отделение";
                        return name;
                    }
                case 6:
                    {
                        name = "Шестое отделение";
                        return name;
                    }
                case 7:
                    {
                        name = "Седьмое отделение";
                        return name;
                    }
                case 8:
                    {
                        name = "Дневной стационар";
                        return name;
                    }
                case 90:
                    {
                        name = "ОРИТ";
                        return name;

                    }
                case 91:
                    {
                        name = "ОРИТ грязная зона";
                        return name;

                    }
                default:
                    {
                        name = "";
                        return name;
                    }
            }
        }
    }
}

namespace DailyReport.Models
{
    public class Personel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public Type PersType { get; set; }
        public string Department { get; set; }
    }

    public enum Type
    {
        Doctor,
        Nurse,
        Operator,
        Orderly
    }
}

namespace DailyReport.Models
{
    public class DutyDoc
    {
        public int Id { get; set; }
        public string? dutyDoc { get; set; }
        public string? departments { get; set; }
        public DateTime dutyDate { get; set; } = DateTime.Now.Date.AddDays(-1);
        public  DutyType type { get; set; }
    }

    public enum DutyType 
    {
        Department,
        Reanimanion,
        Rentgenology
    }
}

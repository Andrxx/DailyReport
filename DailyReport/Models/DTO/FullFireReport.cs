namespace DailyReport.Models.DTO
{
    public class FullFireReport
    {
        public FireReport? FireReport { get; set; }
        public List<DutyNurse> Nurses { get; set; } = new List<DutyNurse>();
        public Department Department { get; set; } 
    }
}

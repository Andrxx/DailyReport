namespace DailyReport.Models
{
    public class OutcomingPatient
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Gender { get; set; }
        public string? AgeYears { get; set; }
        public string? AgeMonth { get; set; }
        public string? Shipped { get; set; }
        public string? Diagnos { get; set; }
        public string? SubmitedFrom { get; set; }
        public string? SubmitedTo { get; set; }
        public DateTime Date { get; set; }
    }
}

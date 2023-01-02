namespace DailyReport.Models
{
    public class OutcomingPatietnt
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Gender { get; set; }
        public int? Age { get; set; }
        public string? Shipped { get; set; }
        public string? Diagnos { get; set; }
        public string? SubmitedFrom { get; set; }
        public string? SubmitedTo { get; set; }
    }

}

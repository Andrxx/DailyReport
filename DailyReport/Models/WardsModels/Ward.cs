namespace DailyReport.Models.WardsModels
{
    public class Ward
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int Department { get; set; }
        public int Capacity { get; set; }
        public List<int>? PatientsId { get; set; }
        public bool CanPut { get; set; }
        public bool IsDirtyZone { get; set; }

    }
}

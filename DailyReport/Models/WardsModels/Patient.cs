namespace DailyReport.Models.WardsModels
{
    public class Patient
    {
        public int Id { get; set; }
        public int WardNumber { get; set; }
        public string Name { get; set; }
        public string Male { get; set; }
        public int Age { get; set; }
        public int? AgeMonts { get; set; }
        public string Diagnos { get; set; }
        public DateTime HospitalisationDate { get; set; }
        public bool HasRash { get; set; }
        public bool IsUntochable { get; set; }
        public bool IsDisodered { get; set; }
        public bool HasCareRisk { get; set; }

    }
}

namespace DailyReport.Models
{
    public class FinalReport
    {
        public int Id { get; set; }
        public DateTime date { get; set; } = DateTime.Now.Date.AddDays(-1);
        public int existed { get; set; }
        public int existedChildren { get; set; }
        public int income { get; set; }
        public int incomeChildren { get; set; }
        public int outcome { get; set; }
        public int outcomeChildren { get; set; }
        public int attachedToORIT { get; set; }
        public int attachedToORITChildren { get; set; }
        public int movedOutDep { get; set; }
        public int movedOutDepChildren { get; set; }
        public int movedInDep { get; set; }
        public int movedInDepChildren { get; set; }
        public int died { get; set; }
        public int diedChildren { get; set; }
        public int present { get; set; }
        public int presentChildren { get; set; }
        public int oIVL { get; set; }
        public int oIVLChildren { get; set; }
        public int oNIVL { get; set; }
        public int oNIVLChildren { get; set; }
        public int oNIVLVPO { get; set; }
        public int oNIVLVPOChildren { get; set; }
        public int oNIVLMask { get; set; }
        public int oNIVLMaskChildren { get; set; }
        public int oMask { get; set; }
        public int oMaskChildren { get; set; }
        public int oBrease { get; set; }
        public int oBreaseChildren { get; set; }
        public int pregnant { get; set; }
        public int pregnantChildren { get; set; }
        public int restZone { get; set; }
        public int restZoneChildren { get; set; }
        public int outRegions { get; set; }
        public int outRegionsChildren { get; set; }
        public int forein { get; set; }
        public int foreinChildren { get; set; }
        public int LNR_DNR { get; set; }
        public int LNR_DNRChildren { get; set; }
        public int incomeHospital { get; set; }
        public int incomeHospitalChildren { get; set; }
        public int outcomeHospital { get; set; }
        public int outcomeHospitalChildren { get; set; }
        public int U071 { get; set; }
        public int U071Children { get; set; }
        public int U072 { get; set; }
        public int U072Children { get; set; }
        public int ORVI { get; set; }
        public int ORVIChildren { get; set; }
        public int pneumonia { get; set; }
        public int pneumoniaChildren { get; set; }
        public int OKI { get; set; }
        public int OKIChildren { get; set; }
        public int meningit { get; set; }
        public int meningitChildren { get; set; }
        public int hepatit { get; set; }
        public int hepatitChildren { get; set; }
        public int HIV { get; set; }
        public int HIVCildren { get; set; }
        public int other { get; set; }
        public int otherChildren { get; set; }
        public int oSummary { get; set; }
        public int oSummaryChildren { get; set; }
        public int nozSummary { get; set; }
        public int nozSummaryChildren { get; set; }
    }
}

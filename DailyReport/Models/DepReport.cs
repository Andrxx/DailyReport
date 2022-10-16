using System.ComponentModel.DataAnnotations;

namespace DailyReport.Models
{
    public class DepReport
    {
        public int Id { get; set; }
        public DateTime date { get; set; } = DateTime.Now.Date.AddDays(-1);
        [Range(0 , 7)]
        public int depNumber { get; set; }
        public int existed { get; set; }
        public int existedChildrens { get; set; }
        public int income { get; set; }
        public int incomeChildrens { get; set; }
        public int outcome { get; set; }
        public int outcomeChildrens { get; set; }
        public int movedOutDep { get; set; }
        public int movedOutDepChildrens { get; set; }
        public int movedInDep { get; set; }
        public int movedInDepChildrens { get; set; }
        public int died { get; set; }
        public int diedChildrens { get; set; }
        public int present { get; set; }
        public int presentChildrens { get; set; }
        public int oIVL { get; set; }
        public int oIVLChildrens { get; set; }
        public int oNIVL { get; set; }
        public int oNIVLChildrens { get; set; }
        public int oNIVLVPO { get; set; }
        public int oNIVLVPOChildrens { get; set; }
        public int oNIVLMask { get; set; }
        public int oNIVLMaskChildrens { get; set; }
        public int oMask { get; set; }
        public int oMaskChildren { get; set; }
        public int oBrease { get; set; }
        public int oBreaseChildrens { get; set; }
        public int pregnant { get; set; }
        public int pregnantChildrens { get; set; }
        public int restZone { get; set; }
        public int restZoneChildrens { get; set; }
        public int outRegions { get; set; }
        public int outRegionsChildrens { get; set; }
        public int forein { get; set; }
        public int foreinChildrens { get; set; }
        public int LNR_DNR { get; set; }
        public int LNR_DNRChildrens { get; set; }
        public int incomeHospital { get; set; }
        public int incomeHospitalChildrens { get; set; }
        public int outcomeHospital { get; set; }
        public int outcomeHospitalChildrens { get; set; }
        public int U071 { get; set; }
        public int U071Childrens { get; set; }
        public int U072 { get; set; }
        public int U072Childrens { get; set; }
        public int ORVI { get; set; }
        public int ORVIChildrens { get; set; }
        public int pneumonia { get; set; }
        public int pneumoniaChildrens { get; set; }
        public int OKI { get; set; }
        public int OKIChildrens { get; set; }
        public int meningit { get; set; }
        public int meningitChildrens { get; set; }
        public int hepatit { get; set; }
        public int hepatitChildrens { get; set; }
        public int HIV { get; set; }
        public int HIVCildrens { get; set; }
        public int other { get; set; }
        public int otherChildrens { get; set; }

    }
}

using DailyReport.Models.WardsModels;
using static DailyReport.Services.WardServices.PatientServices;

namespace DailyReport.Services.WardServices
{
    public static class WardServices
    {
        public static Ward CreateTestWard(int number, int dep, bool can, int capacity, bool dirty)
        {
            BooleanGenerator booleanGenerator = new BooleanGenerator();
            Random random = new Random();
            Ward ward = new();
            ward.Number = number;
            ward.Department = dep;
            ward.CanPut = can;
            ward.Capacity = capacity;
            ward.IsDirtyZone = dirty;
            
            return ward;
        }
    }
}

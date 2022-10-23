using DailyReport.Models;
using Microsoft.EntityFrameworkCore;

namespace DailyReport.Services
{
    public class FinalReprortServise
    {
        ApplicationContext _context;
        FinalReport finalReport;
        
        List<DepReport> depReports = new List<DepReport>();
        public List<FinalReport> Reports { get; private set; } = new();

        //public FinalReprortServise() { }

        public void Initialaze(ApplicationContext  db)
        {
            _context = db;
        }

        void GetDepReports()
        {
            depReports = _context.DepReports.AsNoTracking().ToList();

        }


    }
}

using Microsoft.EntityFrameworkCore;
using DailyReport.Models;

namespace DailyReport.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<DepReport> DepReports { get; set; } = null!;
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }
        public DbSet<DailyReport.Models.FinalReport> FinalReport { get; set; }
       
    }
}

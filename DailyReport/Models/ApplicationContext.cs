using Microsoft.EntityFrameworkCore;
using DailyReport.Models;

namespace DailyReport.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }
        public DbSet<DepReport> DepReports { get; set; } = null!;
        public DbSet<FinalReport> FinalReports { get; set; }

    }
}

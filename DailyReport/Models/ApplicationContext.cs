using Microsoft.EntityFrameworkCore;

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
       
    }
}

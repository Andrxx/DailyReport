using Microsoft.EntityFrameworkCore;
using DailyReport.Models;

namespace DailyReport.Models
{
    public class ApplicationContext : DbContext
    {

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            //Database.EnsureDeleted();   // удаляем бд со старой схемой
            //Database.EnsureCreated();   // создаем базу данных при первом обращении
        }
        public DbSet<DepReport> DepReports { get; set; } = null!;
        public DbSet<FinalReport> FinalReports { get; set; } = null!;
        public DbSet<DutyDoc> DutyDocs { get; set; } = null!;
        public DbSet<OutcomingPatient> OutcomingPatients { get; set; } = null!;
        public DbSet<Personel> Personels { get; set; } = null!;

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //    => options.UseSqlite(@"Data Source=departmentsdb.db");



       
    }
}

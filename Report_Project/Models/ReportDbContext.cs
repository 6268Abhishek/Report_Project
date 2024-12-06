using Microsoft.EntityFrameworkCore;

namespace Report_Project.Models
{

    public class ReportDbContext: DbContext
    {
        public ReportDbContext(DbContextOptions<ReportDbContext>options):base(options) 
        
        {
            
        }
        public DbSet<Report> reports { get; set; }
        public DbSet<MeetingSchedule> MeetingSchedules { get; set; }


    }
}

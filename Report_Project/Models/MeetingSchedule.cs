using System.ComponentModel.DataAnnotations;

namespace Report_Project.Models
{
    public class MeetingSchedule
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string RecurrenceType { get; set; } // Daily, Weekly, Monthly, Yearly

        [Required]
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; } // Optional for recurring events

        [Required]
        public TimeSpan Time { get; set; }
    }
}

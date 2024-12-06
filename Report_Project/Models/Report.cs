using System.ComponentModel.DataAnnotations;

namespace Report_Project.Models
{
    public class Report
    {
        [Key]
        public int  Report_id{ get; set; }
        [Required]
        public string Report_Name   { get; set; }
        [Required]    
        public string Receiver_Email { get; set; }
        [Required]    
        public string Receiver_Name   { get; set; }
        [Required]    
        public bool Receiver_active_Inactive {  get; set; }

    }
}

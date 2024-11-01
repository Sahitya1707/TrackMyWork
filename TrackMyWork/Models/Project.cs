using System.ComponentModel.DataAnnotations;

namespace TrackMyWork.Models
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }
       

        // Foreign Key
        [Required]
        [Display(Name = "Client")]
        public int ClientId { get; set; }

        public Client? Client { get; set; }

        
        [Display(Name = "Start Date")]
        [DataType(DataType.Date)] 
        [Required]
        public DateTime StartDate { get; set; }

        // I am removing this, insted I am adding deadline date
        //[Display(Name = "Days to Complete")]
        //[Range(1, 60)] 
        //public int DaysToComplete { get; set; }
        /* 
         * 
         ----------------------
         */
        // Deadline Date
        [Required]
        [Display(Name ="Deadline Date")]
        [DataType(DataType.Date)]



        
        public DateTime DeadlineDate { get; set; }

/* 
 * 
 ----------------------
 */
        [Required]
        [Display(Name = "Urgency")]
        // 1 is higher urgency, 2 is medium and 3 is low
        [Range(1, 3)] 
        public int Urgency { get; set; }

        [Required]
        [Display(Name ="Project Status")]
        // 1 is active, 2 is hold & 3 is completed
        [Range(1,3)]
     
        public int Status { get; set; }

        // Navigation Properties
        public ICollection<TimeEntry>? TimeEntries { get; set; } // One project can have different time entries
        public ICollection<Invoice>? Invoices { get; set; } // One project can have different invoices
        public ICollection<Message>? Messages { get; set; } // One project can have different messages
    }
}

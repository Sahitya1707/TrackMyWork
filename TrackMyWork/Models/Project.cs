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

        [Display(Name = "Days to Complete")]
        [Range(1, 60)] 
        public int DaysToComplete { get; set; }

        [Display(Name = "Urgency")]
        // 1 is higher urgency, 2 is medium and 3 is low
        [Range(1, 3)] 
        public int Urgency { get; set; }

        // Navigation Properties
        public ICollection<TimeEntry>? TimeEntries { get; set; } // One project can have different time entries
        public ICollection<Invoice>? Invoices { get; set; } // One project can have different invoices
        public ICollection<Message>? Messages { get; set; } // One project can have different messages
    }
}

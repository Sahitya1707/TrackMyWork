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
        [Display(Name = "Client")] // creates a one-to-many relationship, where each project belongs to one client, but a client can have multiple projects.
        public int ClientId {  get; set; }

        public Client? Client { get; set; }



        // I am using Icollection thinking this can provide more flexiblity and this application might need upgrade in future.
        public ICollection<TimeEntry> TimeEntries { get; set; } // one projects can have different time entries
        public ICollection<Invoice> Invoices { get; set; } // one project can have different invoices
        public ICollection<Message> Message { get; set; } // one projedct can have different message
    }
}

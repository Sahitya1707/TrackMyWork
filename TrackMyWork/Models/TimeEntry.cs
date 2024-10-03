
using System.ComponentModel.DataAnnotations;
namespace TrackMyWork.Models
{
    public class TimeEntry
    {
        [Key]
        public int TimeEntryId { get; set; }

        [Required]
        [Display(Name = "Entry Date")]
        public DateTime EntryDate { get; set; }  // this is to set the date of the time entry

        [Required]
        [Display(Name = "Hours Worked")]
        public double Hours { get; set; } // to set the data worked

        // Foreign Key
        [Display(Name = "Project")]  //  one project can have multiple timesheets
        public int ProjectId { get; set; }

        public Project? Project { get; set; }


        // Adding user as a foreign key
        [Display(Name = "User")]  
        public int UserId {  get; set; }

        public User? User { get; set; }
    }
}

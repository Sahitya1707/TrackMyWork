using System.ComponentModel.DataAnnotations;
namespace TrackMyWork.Models
{
    public class Client
    {
        [Key]
        public int ClientId { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [MaxLength(50)]
        public string FirstName { get; set; }


        [Required]
        [Display(Name = "Last Name")]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        public ICollection<Project> Projects { get; set; }  // there can be multiple projects from one client
        public ICollection<Invoice> Invoices { get; set; } // there can be multiple invoices for one clients
    }
}

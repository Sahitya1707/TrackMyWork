using System.ComponentModel.DataAnnotations;
namespace TrackMyWork.Models
{
    public class Client
    {
        [Key]
       
        public int ClientId { get; set; }
       

        // added error message, and required error message
        [Required(ErrorMessage = "First Name is required.")]
        [Display(Name = "First Name")]
        [MaxLength(50)]
       
        public string FirstName { get; set; }


        [Required(ErrorMessage = "Last Name is required.")]
        [Display(Name = "Last Name")]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        public ICollection<Project>? Projects { get; set; }  // there can be multiple projects from one client
        public ICollection<Invoice>? Invoices { get; set; } // there can be multiple invoices for one clients
    }
}

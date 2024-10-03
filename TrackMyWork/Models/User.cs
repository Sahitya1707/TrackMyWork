using System.ComponentModel.DataAnnotations;  // Provides attribute classes that are used to define metadata for ASP.NET MVC and ASP.NET data controls. (https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations?view=net-8.0)

namespace TrackMyWork.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; } // primary key

        [Required]
        [Display(Name = "First Name")]
        [MaxLength(50)]
        public String FirstName{get; set;}

        [Required]
        [Display(Name = "Last Name")]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

    }
}

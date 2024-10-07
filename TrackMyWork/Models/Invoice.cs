
using System.ComponentModel.DataAnnotations;

namespace TrackMyWork.Models
{
    public class Invoice
    {
        [Key]
        public int InvoiceId { get; set; }  

        [Required]
        public decimal Amount { get; set; }  

        public DateTime IssueDate { get; set; }  // it contains the date of issue for the invoice

        // adding client as a foreign key so that client data can be used in invoice
        [Display(Name = "Client") ] 
        public int ClientId { get; set; }
        public Client? Client { get; set; }

        // adding project id as a foreign key inorder ot include it
        [Display(Name = "Project")]
        public int ProjectId { get; set; }
        public Project? Project { get; set; }

    }
}

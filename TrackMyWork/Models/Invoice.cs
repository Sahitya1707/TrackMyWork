
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

      
    }
}

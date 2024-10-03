using System.ComponentModel.DataAnnotations;
using TrackMyWork.Models;


public class Message
{
    [Key]
    public int MessageId { get; set; } 

    [Required]
    public string Content { get; set; }  // Message content

    public DateTime SentDate { get; set; }  // Date the message was sent

    // we will use user id and project id for the foreign key in order to use that 
        [Display(Name = "User")]  
        public int UserId {  get; set; }

        public User? User { get; set; }


        [Display(Name = "Client")]
        public string ClientId { get; set; }
        public Client? Client { get; set; }

  




}
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

    [Required]
    public int ProjectId { get; set; }
    public Project Project { get; set; } // we need project so that message can related to specific project.


    [Required]
    public int SenderId { get; set; }
    public User Sender { get; set; }

    [Required]
    public String SenderMail { get; set; } // this is to get/show the user email in messaging system.

    // Status to check if the message has been read
    public bool IsRead { get; set; } = false;






}
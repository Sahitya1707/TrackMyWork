using System.ComponentModel.DataAnnotations;


public class Message
{
    [Key]
    public int MessageId { get; set; } 

    [Required]
    public string Content { get; set; }  // Message content

    public DateTime SentDate { get; set; }  // Date the message was sent

 
}
﻿using System.ComponentModel.DataAnnotations;
using TrackMyWork.Models;


public class Message
{
    [Key]
    public int MessageId { get; set; } 

  
    [Display(Name = "Message")]
    public string Content { get; set; }  // Message content

    public DateTime SentDate { get; set; }  // Date the message was sent, I will want it to be captured automatically when create/send  button is clicked

    // we will use project id for the foreign key in order to use that 

    public int ProjectId { get; set; }
    [Display(Name ="Project Name")]
    public Project? Project { get; set; } // we need project so that message can related to specific project.


  

    
    public String SenderMail { get; set; } // this is to get/show the user email in messaging system.

  // my approach for filter the send message. I mean client should be only able to send message their own project not on other's project

    //public int ClientId { get; set; }
    //public Client? Client { get; set; }






}
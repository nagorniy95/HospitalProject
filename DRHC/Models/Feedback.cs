using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DRHC.Models
{
    public class Feedback
    {
        [Key]
        public int FeedbackID { get; set; }

        [Required, StringLength(255), Display(Name = "First Name")]
        public string AuthorFName { get; set; }

        [Required, StringLength(255), Display(Name = "Last Name")]
        public string AuthorLName { get; set; }

        [Required, StringLength(255), Display(Name = "Email")]
        public string AuthorEmail { get; set; }

        // this one is not required
        [StringLength(255), Display(Name = "Phone")]
        public string AuthorPhone { get; set; }

        [Required, StringLength(1000), Display(Name = "Message")]
        public string AuthorMessage { get; set; }

        // Should I use authorId like a FK?
        //Becauser author shouldn't be register to be able to add a new feedback
    }
}

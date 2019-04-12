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
    public class ContactForm
    {
        [Key]
        public int ContactID { get; set; }

        [Required, StringLength(255), Display(Name = "Your name")]
        public string Name { get; set; }

        [Required, StringLength(255), Display(Name = "Your email")]
        public string Email { get; set; }

        [Required, StringLength(255), Display(Name = "Your phone number")]
        public string Phone { get; set; }

        [StringLength(1000), Display(Name = "Your message")]
        public string Message { get; set; }
    }
}

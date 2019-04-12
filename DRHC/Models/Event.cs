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
    public class Event
    {
        [Key]
        public int EventID { get; set; }

        [Required, StringLength(255), Display(Name = "Image")]
        public string EventImage { get; set; }

        [Required, StringLength(255), Display(Name = "Title")]
        public string EventTitle { get; set; }

        [Required, StringLength(255), Display(Name = "Description")]
        public string EventDescription { get; set; }

        [Required, Display(Name = "Date")]
        public DateTime EventDate { get; set; }
    }
}

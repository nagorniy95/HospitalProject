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
    public class Alerts
    {
        [Key]
        public int AlertID { get; set; }

        [Required, StringLength(255), Display(Name = "Title")]
        public string AlertTitle { get; set; }

        [Required, StringLength(1000), Display(Name = "Message")]
        public string AlertMessage { get; set; }

        //public virtual Exercise exercise { get; set; }
        // I need to use FK for admin. Only admin will be able to add new alert message

    }
}

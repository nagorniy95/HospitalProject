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
    public class Admin
    {
        [Key]
        public int AdminID { get; set; }

        //This is a one to one relationship between admin and users
        //In this case the adminID is a string in AspNetUsers
        [ForeignKey("UserID")]
        public string UserID { get; set; }

        public virtual ApplicationUser user { get; set; }

    }
}

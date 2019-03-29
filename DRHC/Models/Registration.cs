using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;



namespace DRHC.Models
{
    public class Registration
    {
        [Key, ScaffoldColumn(false)]
        public int UserID { get; set; }

        //u fname
        [Required, StringLength(500), Display(Name = "First Name")]
        public string UserFName { get; set; }

        //u lname
        [Required, StringLength(500), Display(Name = "Last Name")]
        public string UserLName { get; set; }

        //email
        [Required, StringLength(500), Display(Name = "Email")]
        public string UserEmail { get; set; }



   
    }
}

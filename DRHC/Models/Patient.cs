﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace DRHC.Models
{
    [Table("Patient")]
    public class Patient
    {
        [Key]
        public int PatientID { get; set; }

        [Required, StringLength(255)]
        public string Fname { get; set; }

        [Required, StringLength(255)]
        public string Lname { get; set; }

        [Required, StringLength(255)]
        public DateTime DateAdmitted { get; set; }

        [Required, StringLength(255)]
        public string RoomNumber { get; set; }

        [ForeignKey("DietaryRestrictionID")]
        public int DietaryRestrictionID { get; set; }

        public virtual DietaryRestriction dietaryrestriction { get; internal set; }
    }
}

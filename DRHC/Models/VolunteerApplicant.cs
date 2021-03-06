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
    [Table("VolunteerApplicant")]
    public class VolunteerApplicant
    {
        [Key]
        public int ApplicantID { get; set; }

        [Required, StringLength(255)]
        public string Fname { get; set; }

        [Required, StringLength(255)]
        public string Lname { get; set; }

        [Required, StringLength(255)]
        public string Address { get; set; }

        [Required, StringLength(255)]
        public string City { get; set; }

        [Required, StringLength(255)]
        public string Postal { get; set; }

        [Required, StringLength(255)]
        public string Province { get; set; }

        public string Phone { get; set; }

        [Required, StringLength(255)]
        public string Email { get; set; }

        [Required, StringLength(500)]
        public string Experience { get; set; }

        [Required, StringLength(255)]
        public DateTime ApplicationDate { get; set; }

        [Required, StringLength(255)]
        public Boolean Approval { get; set; }

        //a volunteerapplicant can apply for one position
        [ForeignKey ("VolunteerPositionID")]
        public int VolunteerPositionID { get; set; }
        
        //an applicant can only apply for one position
        public virtual VolunteerPosition volunteerposition { get; set; }
    }
}

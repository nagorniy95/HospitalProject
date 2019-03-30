using System;
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
        public string PatientID { get; set; }

        [Required, StringLength(255)]
        public string Fname { get; set; }

        [Required, StringLength(255)]
        public string Lname { get; set; }

        [Required, StringLength(255)]
        public DateTime DateAdmitted { get; set; }

        [Required, StringLength(255)]
        public string RoomNumber { get; set; }

        [ForeignKey("DietaryRestrictionsID")]
        public int DietaryRestrictionsID { get; set; }

    }
}

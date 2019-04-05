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
        [Table("VolunteerPosition")]
    public class VolunteerPosition
    {
        [Key]
        public int VolunteerPostingID { get; set; }

        [Required, StringLength(255)]
        public string PostTitle { get; set; }

        public string Department { get; set; }

        public static DateTime Now { get; }

        [Required, StringLength(500)]
        public string Description { get; set; }

        public string AboutOrg { get; set; }

        [Required, StringLength(500)]
        public string Experience { get; set; }

        public string Education {get; set;}
    }
}

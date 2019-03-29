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
        [Display(Name = "Deadline to Apply")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DealineToApply { get; set; }
        public string Description { get; set; }
        public string AboutOrg { get; set; }
        public string AboutPosition { get; set; }
        public string Experience { get; set; }
        public string Education {get; set;}
    }
}

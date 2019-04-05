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
    [Table("DietaryRestriction")]
    public class DietaryRestriction
    {
        [Key]
        public int DietaryRestrictionsID { get; set; }

        [Required, StringLength(255)]
        public string FoodType { get; set; } //solid, semi-solid, liquid, checkbox

        [Required, StringLength(255)]
        public string Fasting { get; set; } // yes no radio buttons

        [Required]
        public DateTime FinishTime { get; set; }

        [Required, StringLength(255)]
        public string Preference { get; set; } // Patient can change

        [Required, StringLength(255)]
        public string  Diabetic { get; set; } // yes no radio buttons

        [Required, StringLength(255)]
        public string ClearLiquid { get; set; } // yes no radio buttons

        [Required, StringLength(255)]
        public string LowFiber { get; set; } // yes no radio buttons

        [Required, StringLength(255)]
        public string LowFat { get; set; } // yes no radio buttons

        [Required, StringLength(255)]
        public string LowCholesterol { get; set; } // yes no radio buttons

        [ForeignKey("PatientID")]
        public int PatientID { get; set; }


    }
}

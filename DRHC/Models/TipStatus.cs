using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DRHC.Models
{
    public class TipStatus
    {

        [Key, ScaffoldColumn(false)]
        public int TipStatusID { get; set; }

        [Required, StringLength(255), Display(Name = "Name")]
        public string TipStatusName { get; set; }

        [InverseProperty("TipStatus")]
        public virtual List<TipAndLetter> TipAndLetters { get; set; }
    }
}

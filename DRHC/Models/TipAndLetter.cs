using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DRHC.Models
{
    public class TipAndLetter
    {

        [Key, ScaffoldColumn(false)]
        public int TipAndLetterID { get; set; }

        [Required, StringLength(255), Display(Name = "Title")]
        public string Title { get; set; }

        [Required, StringLength(1000), Display(Name = "Message")]
        public string Message { get; set; }

        [Required,  Display(Name = "Date Created")]
        public DateTime DateCreated { get; set; }

        [ForeignKey("TagID")]
        public int TagID { get; set; }
        public virtual Tag Tag { get; set; }

        [ForeignKey("TipStatusID")]
        public int TipStatusID { get; set; }
        public virtual TipStatus TipStatus { get; set; }
    }
}

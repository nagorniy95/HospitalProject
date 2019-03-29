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


        //email
        [Required, StringLength(255), Display(Name = "Title")]
        public string Title { get; set; }

        //email
        [Required, StringLength(1000), Display(Name = "Message")]
        public string Message { get; set; }

        [ForeignKey("TagID")]
        public int TagID { get; set; }
        //One TestimonialStatus to many Testimonials
        public virtual Tag Tag { get; set; }

        [ForeignKey("TipStatusID")]
        public int TipStatusID { get; set; }
        //One TestimonialStatus to many Testimonials
        public virtual TipStatus TipStatus { get; set; }
    }
}

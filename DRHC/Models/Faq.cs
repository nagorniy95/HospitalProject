using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DRHC.Models
{
    public class Faq
    {
        public int FaqID { get; set; }

        
        //[Required, StringLength(1000), Display(Name = "Question")]
        public string Questions { get; set; }

        
        //[Required, StringLength(1000), Display(Name = "Answer")]
        public string Answers { get; set; }

    }
}

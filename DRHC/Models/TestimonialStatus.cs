using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DRHC.Models
{
    public class TestimonialStatus
    {
        [Key, ScaffoldColumn(false)]
        public int TestimonialStatusID { get; set; }

        [Required, StringLength(255), Display(Name = "Name")]
        public string TestimonialStatusName { get; set; }

        [InverseProperty("TestimonialStatus")]
        public virtual List<Testimonial> Testimonials { get; set; }

    }
}

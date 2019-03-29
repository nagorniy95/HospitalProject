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

        //This is how we can represent a one (blog) to many (pages) relation
        //notice how if we were using a relational database this column
        //would be included as a foreign of authorid in the pages table.
        [InverseProperty("TestimonialStatus")]
        public virtual List<Testimonial> Testimonials { get; set; }

    }
}

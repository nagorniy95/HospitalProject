using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DRHC.Models
{
    public class Testimonial
    {
        [Key, ScaffoldColumn(false)]
        public int TestimonialID { get; set; }

        //u fname
        [Required, StringLength(255), Display(Name = "First Name")]
        public string UserFName { get; set; }

        //u lname
        [Required, StringLength(255), Display(Name = "Last Name")]
        public string UserLName { get; set; }

        //email
        [Required, StringLength(255), Display(Name = "Title")]
        public string Title { get; set; }

        //email
        [Required, StringLength(1000), Display(Name = "Story")]
        public string Story { get; set; }

        [ForeignKey("TestimonialStatusID")]
        public int TestimonialStatusID { get; set; }
        //One TestimonialStatus to many Testimonials
        public virtual TestimonialStatus TestimonialStatus { get; set; }

    }
}

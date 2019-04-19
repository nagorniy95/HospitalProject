using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DRHC.Models.ViewModels
{
    public class TestimonialEdit
    {

        //Empty constructor
        public TestimonialEdit()
        {

        }

        public virtual Testimonial Testimonial { get; set; }

        public IEnumerable<TestimonialStatus> TestimonialStatuss { get; set; }


    }
}

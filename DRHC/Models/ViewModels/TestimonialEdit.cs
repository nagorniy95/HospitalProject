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

        //Raw page information (in Models/Page.cs)
        public virtual Testimonial Testimonial { get; set; }

        //need information about the different blogs this page COULD be
        //assigned to
        public IEnumerable<TestimonialStatus> TestimonialStatuss { get; set; }


    }
}

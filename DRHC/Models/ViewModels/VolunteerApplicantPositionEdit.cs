using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DRHC.Models.ViewModels
{
    public class VolunteerApplicantPositionEdit
    {
        public VolunteerApplicantPositionEdit()
        {

        }


        public virtual VolunteerApplicant VolunteerApplicant { get; set;}

        public virtual VolunteerPosition VolunteerPosition { get; set; }
    }
}

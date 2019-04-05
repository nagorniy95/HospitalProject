using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DRHC.Models.ViewModels
{
    public class PatientDietEdit
    {
        public PatientDietEdit()
        {

        }

        public virtual Patient Patient {get; set;}

        public virtual DietaryRestriction Restrictions { get; set; }

    }
}

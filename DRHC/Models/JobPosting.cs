using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DRHC.Models
{
    public class JobPosting
    {
        [Key]
        public int JobPostingID { get; set; }

        [Required, StringLength(255), Display(Name = "Job Title")]
        public string JobTitle { get; set; }
        public string Department { get; set; }
        public DateTime Now { get; }
        public DateTime DeadlineToApply { get; set; }
        public string Description { get; set; }
        public string AboutOrg { get; set; }
        public string AboutPosition { get; set; }
        public string Experience { get; set; }
        public string Education { get; set; }

        //what is the difference between Ilist and Icollection

        //public IList<JobApplication> JobApplications { get; set; }


        //[InverseProperty("JobPosting")]
        //public List<JobApplication> JobApplications { get; set; }
        public ICollection<JobApplication> JobApplication{ get; set; }



    }
}



using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DRHC.Models
{
    public class JobApplication
    {
        [Key]
        public int JobApplicationID { get; set; }

        [Required, StringLength(255), Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required, StringLength(255), Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required, StringLength(255), Display(Name = "Email")]
        public string Email { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Province { get; set; }

        public string PostalCode { get; set; }

        public string Phone { get; set; }

        public DateTime AppDate { get; set; }

        public Boolean Status { get; set; }                                       

        [Required, StringLength(500)]
        public string Resume { get; set; }

        [Required, StringLength(500)]
        public string Coverletter { get; set; }

        [ForeignKey("JobPostingId")]
        public int JobPostingId { get; set; }
        //One jobposting to many job applicant 
        
        public virtual JobPosting JobPosting { get; set; }



    }
}


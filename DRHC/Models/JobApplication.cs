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
        /*public string Address { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public DateTime AppDate { get; set; }
        public string Status { get; set; }
        public string Position { get; set; }
        public string Resume { get; set; }
        public string Coverletter { get; set; }*/

        [ForeignKey("JobPostingId")]
        public int JobPostingId { get; set; }
        //One jobposting to many job applicant 
        //meaning of virtual - The virtual keyword is used to modify a method, property, indexer, or event declaration and allow for it to be overridden in a derived class. For example, this method can be overridden by any class that inherits it:
        public virtual JobPosting JobPostings { get; set; }


       
    }
}

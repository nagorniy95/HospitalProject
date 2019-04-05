using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DRHC.Models
{
    public class Department
    {
        [Key]
        public int DepartmentID { get; set; }

        [Required, StringLength(255)]
        public string DepartmentName { get; set; }

        //one to many relationship (department to position)

        [InverseProperty("Department")]
        public List<JobPosting> JobPostings { get; set; }
    }
}

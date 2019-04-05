using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DRHC.Models
{
    public class ERWaitTime
    {
        
        public int ERWaitTimeId { get; set; }
        [Required, StringLength(255), Display(Name = "ER Wait Times")]
        public string WaitTime { get; set; }
        public string Description { get; set; }
    }
}

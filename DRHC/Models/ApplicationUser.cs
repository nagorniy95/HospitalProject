using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DRHC.Models
{
    public class ApplicationUser : IdentityUser
    {
        //Configure one to one relationship between user and admin
        [ForeignKey("AdminID")]
        public int? AdminID { get; set; }

        //An Application User is tied to an admin.
        public virtual Admin admin { get; set; }
    }
}

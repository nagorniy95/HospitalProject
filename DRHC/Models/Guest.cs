using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DRHC.Models
{
    public class Guest
    {
        [Key, ScaffoldColumn(false)]
        public int GuestID { get; set; }

        [Required, StringLength(255), Display(Name = "Number Of Guest")]
        public string NumberOfGuest { get; set; }

        [InverseProperty("Guests")]
        public virtual List<Order> Orders { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace DRHC.Models
{   

    [Table("RecRoomBooking")]
    public class RecRoomBooking
    {
        [Key]
        public int BookingID { get; set; }

        [Required, StringLength(255)]
        public string Fname { get; set; }

        [Required, StringLength(255)]
        public string Lname { get; set; }

        [Required, StringLength(255)]
        public string Day { get; set; }

        [Required, StringLength(255)]
        public string Week { get; set; }

        [Required, StringLength(255)]
        public string Month { get; set; }

        [Required, StringLength(255)]
        public string Email { get; set; }

        public string Phone { get; set; }

    }
}

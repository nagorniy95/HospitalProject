using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DRHC.Models
{
    public class Donation
    {
        [Key]
        public int DonationId { get; set; }

        [DataType(DataType.Date)]
        public DateTime AppDate { get; set; }

        [Required, Display(Name = "Donation Amount")]
        public decimal Amount { get; set; }



        [ForeignKey("DonorId")]
        public int DonorId { get; set; }
        //One donor to many donations
        public virtual Donor Donors { get; set; }

       

    }
}
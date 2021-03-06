﻿using System;
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

        public string Title { get; set; }

        [Required, StringLength(255), Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required, StringLength(255), Display(Name = "Last Name")]
        public string LastName { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Province { get; set; }

        public string PostalCode { get; set; }

        [Required, StringLength(255), Display(Name = "Email")]
        public string Email { get; set; }

        public string Phone { get; set; }

        [Required, Display(Name = "Donation Amount")]  
        public double Amount { get; set; }            

        


    }
}
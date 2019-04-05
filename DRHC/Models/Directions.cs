using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DRHC.Models
{
    public class Directions
    {
        [Key]
        public int DirectionID { get; set; }

        [Required, StringLength(255), Display(Name = "Latitude")]
        public string Latitude { get; set; }

        [Required, StringLength(255), Display(Name = "Longitude")]
        public string Longitude { get; set; }

        [Required, StringLength(255), Display(Name = "Name")]
        public string DirectionName { get; set; }
    }
}

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
    public class SearchCategory
    {
        [Key]
        public int SearchCategoryID { get; set; }

        [Required, StringLength(255), Display(Name = "Title")]
        public string SearchCategoryTitle { get; set; }

        // this one is not required
        [StringLength(1000), Display(Name = "Description")]
        public string SearchCategoryDescriptioin { get; set; }

        // I do not need to use FK for this feature
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DRHC.Models
{
    public class Tag
    {
        [Key, ScaffoldColumn(false)]
        public int TagID { get; set; }

        [Required, StringLength(255), Display(Name = "Name")]
        public string TagName { get; set; }

        //This is how we can represent a one (blog) to many (pages) relation
        //notice how if we were using a relational database this column
        //would be included as a foreign of authorid in the pages table.
        [InverseProperty("Tag")]
        public virtual List<TipAndLetter> TipAndLetters { get; set; }
    }
}

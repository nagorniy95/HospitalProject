using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DRHC.Models
{
    public class Menu
    {
       [Key, ScaffoldColumn(false)]
        public int ItemID { get; set; }


        [Required, StringLength(255), Display(Name = "Food Item Name")]
        public string ItemName { get; set; }

        [Required, StringLength(255), Display(Name = "Food Type")]
        public string Type { get; set; }

        [Required, StringLength(255), Display(Name = "Price")]
        public string Price { get; set; }

        //many orders to many menu  food items
        public virtual ICollection<OrderXMenu> Ordersxmenus { get; set; }

    
    }
}

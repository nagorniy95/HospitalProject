using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DRHC.Models
{
    public class Order
    {
        [Key, ScaffoldColumn(false)]
        public int OrderID { get; set; }


        [Required, StringLength(255), Display(Name = "First Name")]
        public string UserFName { get; set; }

        //u lname
        [Required, StringLength(255), Display(Name = "Last Name")]
        public string UserLName { get; set; }

        //email
        [Required, StringLength(255), Display(Name = "Email")]
        public string Email { get; set; }

        //email
        [Required, StringLength(255), Display(Name = "Number")]
        public string Number { get; set; }

        //DATE
        [Required, StringLength(255), Display(Name = "Date")]
        public string Date { get; set; }

        //TIME
        [Required, StringLength(255), Display(Name = "Time")]
        public string Time { get; set; }


        //veg
        [Required, StringLength(255), Display(Name = "Vegetarian")]
        public float Veg { get; set; }

        //veg
        [Required, StringLength(255), Display(Name = "Non egetarian")]
        public float NonVeg { get; set; }

        [ForeignKey("GuestID")]
        public int GuestID { get; set; }
        public virtual Guest Guests { get; set; }

        [InverseProperty("Order")]
        public virtual List<OrderXMenu> Ordersxmenus { get; set; }

   






       
    }
}

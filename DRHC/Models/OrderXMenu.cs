using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DRHC.Models
{
    public class OrderXMenu
    {
        //standard bridging table, just required to be implemented in EF core
        public int OrderID { get; set; }
        public Order Order { get; set; }

        public int ItemID { get; set; }
        public Menu Menu { get; set; }
        
    }
}

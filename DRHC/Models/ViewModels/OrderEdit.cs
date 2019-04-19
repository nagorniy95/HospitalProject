using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DRHC.Models.ViewModels
{
    public class OrderEdit
    {
        public OrderEdit()
        {

        }

        
        public virtual Order Order { get; set; }

        public IEnumerable<Guest> Guests { get; set; }

        public IEnumerable<Menu> Menus { get; set; }
    }
}

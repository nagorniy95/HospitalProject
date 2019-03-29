using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DRHC.Models.ViewModels
{
    public class TipAndLetterEdit
    { //Empty constructor
        public TipAndLetterEdit()
        {

        }

        //Raw page information (in Models/Page.cs)
        public virtual TipAndLetter TipAndLetter { get; set; }

        //need information about the different blogs this page COULD be
        //assigned to
        public IEnumerable<TipStatus> TipStatuss { get; set; }

        //need information about the different blogs this page COULD be
        //assigned to
        public IEnumerable<Tag> Tags { get; set; }

    }
}

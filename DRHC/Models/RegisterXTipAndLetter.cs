using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DRHC.Models
{
    public class RegisterXTipAndLetter
    {
        // bridging table, each register user can have a Health tip and letter or vise a versa
        public int UserID { get; set; }
        public Registration Registration { get; set; }

        public int TipAndLetterID { get; set; }
        public TipAndLetter TipAndLetter { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DRHC.Models
{
    public class Ecard
    {
        [Key]
        public int EcardID { get; set; }

        // [Required, StringLength(255), Display(Name = "Patient Name")]
        public string PatientName { get; set; }

        //[Required, StringLength(255), Display(Name = "Departent/Unit")]
        public string Department { get; set; }

        public int RoomNo { get; set; }

        //[Required, StringLength(255), Display(Name = "Sender Name")]
        public string SenderName { get; set; }

        //[Required, StringLength(255), Display(Name = "Sender Email")]
        public string SenderEmail { get; set; }

        //[StringLength(int.MaxValue), Display(Name = "Messaage")]
        public string Message { get; set; }


    }
}
